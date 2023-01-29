using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Runtime.Module;
using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Substats.Domain.Runtime.Module
{
    public class PalletBuilder : IPalletBuilder
    {
        private readonly ISubstrateRepository _substrateRepository;
        private readonly ICurrentMetaData _currentMetaData;

        public PalletBuilder(ISubstrateRepository substrateRepository, ICurrentMetaData currentMetaData)
        {
            _substrateRepository = substrateRepository;
            _currentMetaData = currentMetaData;
        }

        private enum TypeBuilder
        {
            Call,
            Error,
            Event,
        }

        public string GenerateDynamicNamespaceBase(IEnumerable<string> nodeTypePath)
        {
            if(nodeTypePath == null)
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
        private IType BuildGeneric(string palletName, Method method, TypeBuilder typeBuilder)
        {
            var palletModule = _currentMetaData.GetPalletModule(palletName);

            if (palletModule == null)
                throw new ArgumentException($"{nameof(palletModule)} has not been found in current Metadata");

            if (method == null || method.Parameters == null)
                throw new ArgumentNullException($"BuildCall parameters are empty");

            NodeType? currentType = null;
            string dynamicCall = string.Empty;
            string dynamicEnum = string.Empty;
            string namespaceBase = string.Empty;

            switch (typeBuilder)
            {
                case TypeBuilder.Call:
                    currentType = _substrateRepository.Client.Core.MetaData.NodeMetadata.Types[palletModule.Calls.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumCall";
                    dynamicEnum = $"{namespaceBase}.Call";
                    break;
                case TypeBuilder.Error:
                    currentType = _substrateRepository.Client.Core.MetaData.NodeMetadata.Types[palletModule.Errors.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumError";
                    dynamicEnum = $"{namespaceBase}.Error";
                    break;
                case TypeBuilder.Event:
                    currentType = _substrateRepository.Client.Core.MetaData.NodeMetadata.Types[palletModule.Events.TypeId];
                    namespaceBase = GenerateDynamicNamespaceBase(currentType.Path);
                    dynamicCall = $"{namespaceBase}.EnumEvent";
                    dynamicEnum = $"{namespaceBase}.Event";
                    break;
            }

            Assembly assembly = typeof(Polkadot.NetApiExt.Generated.SubstrateClientExt).Assembly;
            Type? palletType = assembly.GetType($"Substats.Polkadot.NetApiExt.Generated.Model.{dynamicCall}");
            if (palletType == null) throw new FormatException($"Dynamic call to EnumCall for pallet {palletName} has failed");

            Type? enumType = assembly.GetType($"Substats.Polkadot.NetApiExt.Generated.Model.{dynamicEnum}");
            if (enumType == null) throw new FormatException($"Dynamic call to enum for pallet {palletName} has failed");

            IType? callInstance = (IType?)Activator.CreateInstance(palletType);
            if (callInstance == null) throw new FormatException($"Dynamic create instance for EnumCall {palletName} has failed");

            Enum? enumCall = (Enum?)Enum.ToObject(enumType, method.CallIndex);
            if (enumCall == null) throw new FormatException($"Dynamic create enum instance for {palletName} has failed");

            callInstance.Create(Encode(enumCall, method.Parameters));
            return callInstance;
        }

        public IType BuildCall(string palletName, Method method)
        {
            return BuildGeneric(palletName, method, TypeBuilder.Call);
        }

        public IType BuildError(string palletName, Method method)
        {
            return BuildGeneric(palletName, method, TypeBuilder.Error);
        }

        public IType BuildEvent(string palletName, Method method)
        {
            return BuildGeneric(palletName, method, TypeBuilder.Event);
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
                    string globalProjectName, 
                    string projectName,
                    "NetApiExt",
                    "Generated", 
                    string baseNamespace, 
                    ..
                ])
            {
                arguments = splittedNamespace.Skip(5).ToList();

                var nodeType = _substrateRepository.Client.Core.MetaData.NodeMetadata.Types
                    .Where(t => t.Value.Path != null && t.Value.Path.SequenceEqual(arguments))
                    .FirstOrDefault().Value;

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
            if(nodeType.Docs == null) return null;
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
            if(nodeType == null) return null;

            if(nodeType is NodeTypeVariant nodeTypeVariant)
            {
                var variantType = nodeTypeVariant.Variants
                    .FirstOrDefault(x => x.Name == type.ToString());
                if(variantType == null || variantType.Docs == null) return null;

                return string.Join("\n", variantType.Docs);
            }
            return null;
        }
    }
}
