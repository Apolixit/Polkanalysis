using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using System.Reflection;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Runtime.Module
{
    public class PalletBuilder : IPalletBuilder
    {
        private readonly ISubstrateService _substrateRepository;
        private readonly IMetadataService _currentMetaData;
        private readonly ILogger<PalletBuilder> _logger;

        public PalletBuilder(ISubstrateService substrateRepository, IMetadataService currentMetaData, ILogger<PalletBuilder> logger)
        {
            _substrateRepository = substrateRepository;
            _currentMetaData = currentMetaData;
            _logger = logger;
        }

        private enum TypeBuilder
        {
            Call,
            Error,
            Event,
        }

        public string GenerateDynamicNamespaceBase(IEnumerable<string> nodeTypePath)
        {
            if (nodeTypePath == null)
                throw new ArgumentNullException($"{nameof(nodeTypePath)} is null");

            return string.Join(".", nodeTypePath.Take(nodeTypePath.Count() - 1));
        }

        protected byte[] Encode<T>(T enumPallet, byte[] param) where T : Enum
        {
            var result = new List<byte>();
            var r = new byte[] { Convert.ToByte(enumPallet) };
            result.AddRange(r);
            result.AddRange(param);
            return result.ToArray();
        }

        /// <summary>
        /// Create and instanciate dynamically the call from pallet name and method arguments
        /// </summary>
        /// <param name="dynamicCall"></param>
        /// <param name="dynamicEnum"></param>
        /// <returns></returns>
        private IType? BuildGeneric(MetaData metadata, string palletName, Method method, TypeBuilder typeBuilder)
        {
            var palletModule = _currentMetaData.GetPalletModuleByName(metadata, palletName, CancellationToken.None);

            if (palletModule == null)
                throw new ArgumentException($"{nameof(palletModule)} has not been found in current Metadata");

            if (method == null || method.ParametersBytes == null)
                throw new ArgumentNullException($"BuildCall parameters are empty");

            NodeType? currentType = null;
            string dynamicCall = string.Empty;
            string dynamicEnum = string.Empty;
            string namespaceBase = string.Empty;

            switch (typeBuilder)
            {
                case TypeBuilder.Call:
                    currentType = metadata.NodeMetadata.Types[palletModule.Calls.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumCall";
                    dynamicEnum = $"{namespaceBase}.Call";
                    break;
                case TypeBuilder.Error:
                    currentType = metadata.NodeMetadata.Types[palletModule.Errors.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumError";
                    dynamicEnum = $"{namespaceBase}.Error";
                    break;
                case TypeBuilder.Event:
                    currentType = metadata.NodeMetadata.Types[palletModule.Events.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumEvent";
                    dynamicEnum = $"{namespaceBase}.Event";
                    break;
            }

            Assembly assembly = Assembly.Load("Polkanalysis.Polkadot.NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"); //typeof(Polkadot.NetApiExt.Generated.SubstrateClientExt).Assembly;
            Type? palletType = assembly.GetType($"Polkanalysis.Polkadot.NetApiExt.Generated.Model.v{_currentMetaData.NodeVersion}.{dynamicCall}");
            if (palletType == null) throw new FormatException($"Dynamic call to EnumCall for pallet {palletName} has failed");

            Type? enumType = assembly.GetType($"Polkanalysis.Polkadot.NetApiExt.Generated.Model.v{_currentMetaData.NodeVersion}.{dynamicEnum}");
            if (enumType == null) throw new FormatException($"Dynamic call to enum for pallet {palletName} has failed");

            IType? callInstance = (IType?)Activator.CreateInstance(palletType);
            if (callInstance == null) throw new FormatException($"Dynamic create instance for EnumCall {palletName} has failed");

            Enum? enumCall = (Enum?)Enum.ToObject(enumType, method.CallIndex);
            if (enumCall == null) throw new FormatException($"Dynamic create enum instance for {palletName} has failed");

            try
            {
                callInstance.Create(Encode(enumCall, method.ParametersBytes));
                return callInstance;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Unable to create instance of {palletName} - {enumCall} {typeBuilder} {method}", palletName, enumCall.ToString(), typeBuilder, method);
            }

            return null;
        }

        private IType? BuildGeneric(Hash blockHash, string palletName, Method method, TypeBuilder typeBuilder)
        {
            var metadata = _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None).Result;
            return BuildGeneric(metadata, palletName, method, typeBuilder);
        }

        public IType? BuildCall(MetaData metadata, string palletName, Method method)
        {
            return BuildGeneric(metadata, palletName, method, TypeBuilder.Call);
        }

        public IType? BuildCall(Hash blockHash, string palletName, Method method)
        {
            var metadata = _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None).Result;
            return BuildCall(metadata, palletName, method);
        }

        public IType? BuildError(MetaData metadata, string palletName, Method method)
        {
            return BuildGeneric(metadata, palletName, method, TypeBuilder.Error);
        }
        public IType? BuildError(Hash blockHash, string palletName, Method method)
        {
            var metadata = _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None).Result;
            return BuildError(metadata, palletName, method);
        }

        public IType? BuildEvent(MetaData metadata, string palletName, Method method)
        {
            
            return BuildGeneric(metadata, palletName, method, TypeBuilder.Event);
        }
        public IType? BuildEvent(Hash blockHash, string palletName, Method method)
        {
            var metadata = _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None).Result;
            return BuildEvent(metadata, palletName, method);
        }

        private string ParseComplexPalletName(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var regex = new Regex("([a-z0-9])([A-Z])", RegexOptions.None, TimeSpan.FromMilliseconds(100));
            var kebabCase = regex.Replace(input, "$1_$2").ToLower();

            return kebabCase;
        }

        private MetaData getMetadataOrDefault(Hash? blockHash)
        {
            return blockHash == null ?
                                _substrateRepository.GetMetadataAsync(CancellationToken.None).Result :
                                _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None).Result;
        }

        /// <summary>
        /// Try to find documentation of the associated type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public NodeType? FindNodeType(Type type, MetaData metadata)
        {
            if (type.FullName == null)
                throw new ArgumentException($"{nameof(type.FullName)} is null (type = {type.Name})");

            var splittedNamespace = type.FullName.Split(".");
            IList<string> arguments = new List<string>();

            //Let's use the new pattern matching !
            if (splittedNamespace is [
                    "Polkanalysis",
                    "Infrastructure",
                    "Blockchain",
                    "Contracts",
                    "Pallet",
                    ..
                ])
            {
                arguments = splittedNamespace.Skip(5).ToList();

                var palletName = ParseComplexPalletName(arguments[0]);

                arguments[0] = palletName.ToLowerInvariant() == "system" ? "frame_system" : $"pallet_{palletName.ToLowerInvariant()}";
                arguments[1] = $"pallet";

                NodeType? nodeType = null;
                nodeType = metadata.NodeMetadata.Types
                    .FirstOrDefault(t => t.Value.Path != null && t.Value.Path.SequenceEqual(arguments)).Value;

                if (nodeType is null)
                {
                    arguments.Insert(1, "pallet"); // Sorry ...

                    nodeType = metadata.NodeMetadata.Types
                    .FirstOrDefault(t => t.Value.Path != null && t.Value.Path.SequenceEqual(arguments)).Value;
                }

                return nodeType;
            }

            return null;
        }
        public NodeType? FindNodeType(Type type, Hash? blockHash = null)
        {
            MetaData metadata = getMetadataOrDefault(blockHash);
            return FindNodeType(type, metadata);
        }

        

        public NodeType? FindNodeType(IType type, Hash? blockHash = null)
        {
            var metadata = blockHash == null ?
                    _substrateRepository.GetMetadataAsync(CancellationToken.None).Result :
                    _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None).Result;

            return FindNodeType(type.GetType(), metadata);
        }

        public NodeType? FindNodeType(IType type, MetaData metadata) => FindNodeType(type.GetType(), metadata);


        public string? FindDocumentation(NodeType nodeType)
        {
            if (nodeType.Docs == null) return null;
            return string.Join("\n", nodeType.Docs);
        }

        public string? FindDocumentation(Type type, MetaData metadata)
        {
            var nodeType = FindNodeType(type, metadata);
            if (nodeType == null) return null;

            return FindDocumentation(nodeType);
        }

        public string? FindDocumentation(Type type, Hash? blockHash = null) 
            => FindDocumentation(type, getMetadataOrDefault(blockHash));

        public string? FindDocumentation(IType type, MetaData metadata)
        {
            var nodeType = FindNodeType(type.GetType(), metadata);
            if (nodeType == null) return null;

            return FindDocumentation(nodeType);
        }


        public string? FindDocumentation(IType type, Hash? blockHash = null) 
            => FindDocumentation(type, getMetadataOrDefault(blockHash));

        public string? FindDocumentation(Enum type, MetaData metadata)
        {
            var nodeType = FindNodeType(type.GetType(), metadata);
            if (nodeType == null) return null;

            if (nodeType is NodeTypeVariant nodeTypeVariant)
            {
                var variantType = nodeTypeVariant.Variants
                    .FirstOrDefault(x => x.Name == type.ToString());
                if (variantType == null || variantType.Docs == null) return null;

                return string.Join("\n", variantType.Docs);
            }
            return null;
        }

        public string? FindDocumentation(Enum type, Hash? blockHash = null) 
            => FindDocumentation(type, getMetadataOrDefault(blockHash));

        public TypeProperty[]? FindProperty(Enum type, MetaData metadata)
        {
            var properties = new List<TypeProperty>();

            var nodeType = FindNodeType(type.GetType(), metadata);
            if (nodeType == null) return null;

            if (nodeType is NodeTypeVariant nodeTypeVariant)
            {
                var variantType = nodeTypeVariant.Variants
                    .FirstOrDefault(x => x.Name == type.ToString());
                if (variantType == null || variantType.Docs == null) return null;

                if (variantType.TypeFields is null) return new List<TypeProperty>().ToArray();

                foreach (var field in variantType.TypeFields)
                {
                    var typeId = metadata.NodeMetadata.Types[field.TypeId];
                    ExtractProperty(properties, field.Name, field.TypeName, typeId);
                }

                return properties.ToArray();
            }
            return null;

            void ExtractProperty(List<TypeProperty> properties, string name, string typeName, NodeType typeId)
            {
                if (typeId is NodeTypePrimitive primitive)
                {
                    properties.Add(new TypeProperty(name, primitive.Primitive.ToString(), TypeProperty.ParamType.Primitive));
                }
                if (typeId is NodeTypeCompact compact)
                {
                    ExtractProperty(properties, name, typeName, metadata.NodeMetadata.Types[compact.TypeId]);
                }
                if (typeId is NodeTypeComposite composite)
                {
                    if (composite.TypeFields != null)
                    {
                        var fieldType = TypeProperty.ParamType.Composite;
                        if (typeName == "T::AccountId") fieldType = TypeProperty.ParamType.AccountId;

                        var prop = new TypeProperty(name, typeName, fieldType);
                        foreach (var compositeField in composite.TypeFields)
                        {
                            ExtractProperty(prop.SubProperties, compositeField.Name, compositeField.TypeName, metadata.NodeMetadata.Types[compositeField.TypeId]);
                        }
                        properties.Add(prop);
                    }
                }
                if (typeId is NodeTypeVariant variant)
                {
                    bool isSimpleEnum = variant.Variants.All(x => x.TypeFields is null);
                    properties.Add(new TypeProperty(name, typeName, isSimpleEnum ? TypeProperty.ParamType.EnumSimple : TypeProperty.ParamType.EnumComplex));
                }

                if (typeId is NodeTypeArray array)
                {
                    ExtractProperty(properties, name, typeName, metadata.NodeMetadata.Types[array.TypeId]);
                }
            }
        }

        public TypeProperty[]? FindProperty(Enum type, Hash? blockHash = null)
            => FindProperty(type, getMetadataOrDefault(blockHash));
    }
}
