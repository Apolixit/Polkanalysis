using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using System.Reflection;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Polkanalysis.Domain.Runtime.Module
{
    public class PalletBuilder : IPalletBuilder
    {
        private readonly ISubstrateService _substrateRepository;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ILogger<PalletBuilder> _logger;

        public PalletBuilder(ISubstrateService substrateRepository, ICurrentMetaData currentMetaData, ILogger<PalletBuilder> logger)
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
        private IType? BuildGeneric(string palletName, Method method, TypeBuilder typeBuilder)
        {
            var palletModule = _currentMetaData.GetPalletModule(palletName);

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
                    currentType = _substrateRepository.RuntimeMetadata.NodeMetadata.Types[palletModule.Calls.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumCall";
                    dynamicEnum = $"{namespaceBase}.Call";
                    break;
                case TypeBuilder.Error:
                    currentType = _substrateRepository.RuntimeMetadata.NodeMetadata.Types[palletModule.Errors.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumError";
                    dynamicEnum = $"{namespaceBase}.Error";
                    break;
                case TypeBuilder.Event:
                    currentType = _substrateRepository.RuntimeMetadata.NodeMetadata.Types[palletModule.Events.TypeId];
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

        public IType? BuildCall(string palletName, Method method)
        {
            return BuildGeneric(palletName, method, TypeBuilder.Call);
        }

        public IType? BuildError(string palletName, Method method)
        {
            return BuildGeneric(palletName, method, TypeBuilder.Error);
        }

        public IType? BuildEvent(string palletName, Method method)
        {
            return BuildGeneric(palletName, method, TypeBuilder.Event);
        }

        private string ParseComplexPalletName(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var regex = new Regex("([a-z0-9])([A-Z])");
            var kebabCase = regex.Replace(input, "$1_$2").ToLower();

            return kebabCase;
        }

        /// <summary>
        /// Try to find documentation of the associated type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public NodeType? FindNodeType(Type type)
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

                arguments[0] = $"pallet_{palletName.ToLowerInvariant()}";
                arguments[1] = $"pallet";

                NodeType? nodeType = null;
                nodeType = _substrateRepository.RuntimeMetadata.NodeMetadata.Types
                    .Where(t => t.Value.Path != null && t.Value.Path.SequenceEqual(arguments))
                    .FirstOrDefault().Value;

                if (nodeType is null)
                {
                    arguments.Insert(1, "pallet"); // Sorry ...

                    nodeType = _substrateRepository.RuntimeMetadata.NodeMetadata.Types
                    .Where(t => t.Value.Path != null && t.Value.Path.SequenceEqual(arguments))
                    .FirstOrDefault().Value;
                }

                return nodeType;
            }

            return null;
        }

        public NodeType? FindNodeType(IType type)
        {
            return FindNodeType(type.GetType());
        }

        public string? FindDocumentation(NodeType nodeType)
        {
            if (nodeType.Docs == null) return null;
            return string.Join("\n", nodeType.Docs);
        }
        public string? FindDocumentation(Type type)
        {
            var nodeType = FindNodeType(type);
            if (nodeType == null) return null;

            return FindDocumentation(nodeType);
        }

        public string? FindDocumentation(IType type)
        {
            var nodeType = FindNodeType(type);
            if (nodeType == null) return null;

            return FindDocumentation(nodeType);
        }

        public string? FindDocumentation(Enum type)
        {
            var nodeType = FindNodeType(type.GetType());
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

        public TypeProperty[]? FindProperty(Enum type)
        {
            var properties = new List<TypeProperty>();

            var nodeType = FindNodeType(type.GetType());
            if (nodeType == null) return null;

            if (nodeType is NodeTypeVariant nodeTypeVariant)
            {
                var variantType = nodeTypeVariant.Variants
                    .FirstOrDefault(x => x.Name == type.ToString());
                if (variantType == null || variantType.Docs == null) return null;

                if (variantType.TypeFields is null) return new List<TypeProperty>().ToArray();

                foreach (var field in variantType.TypeFields)
                {
                    var typeId = _substrateRepository.RuntimeMetadata.NodeMetadata.Types[field.TypeId];
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
                    ExtractProperty(properties, name, typeName, _substrateRepository.RuntimeMetadata.NodeMetadata.Types[compact.TypeId]);
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
                            ExtractProperty(prop.SubProperties, compositeField.Name, compositeField.TypeName, _substrateRepository.RuntimeMetadata.NodeMetadata.Types[compositeField.TypeId]);
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
                    ExtractProperty(properties, name, typeName, _substrateRepository.RuntimeMetadata.NodeMetadata.Types[array.TypeId]);
                }
            }
        }
    }
}
