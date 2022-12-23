using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Blazscan.Infrastructure.DirectAccess.Runtime
{
    public class PalletBuilder : IPalletBuilder
    {
        private readonly ISubstrateNodeRepository _substrateRepository;

        public PalletBuilder(ISubstrateNodeRepository substrateRepository)
        {
            _substrateRepository = substrateRepository;
        }

        private enum TypeBuilder
        {
            Call,
            Error,
            Event,
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
            var palletModule = _substrateRepository.Client.MetaData.NodeMetadata.Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;

            if (palletModule == null)
                throw new ArgumentException($"{nameof(palletModule)} has not been found in current Metadata");

            if (method == null || method.Parameters == null || method.Parameters.Length == 0)
                throw new ArgumentNullException($"BuildCall parameters are empty");

            NodeType? palletError = null;
            string dynamicCall = string.Empty;
            string dynamicEnum = string.Empty;
            switch(typeBuilder)
            {
                case TypeBuilder.Call:
                    palletError = _substrateRepository.Client.MetaData.NodeMetadata.Types[palletModule.Calls.TypeId];
                    dynamicCall = $"{palletError.Path[0]}.{palletError.Path[1]}.EnumCall";
                    dynamicEnum = $"{palletError.Path[0]}.{palletError.Path[1]}.Call";
                    break;
                case TypeBuilder.Error:
                    palletError = _substrateRepository.Client.MetaData.NodeMetadata.Types[palletModule.Errors.TypeId];
                    dynamicCall = $"{palletError.Path[0]}.{palletError.Path[1]}.EnumError";
                    dynamicEnum = $"{palletError.Path[0]}.{palletError.Path[1]}.Error";
                    break;
                case TypeBuilder.Event:
                    palletError = _substrateRepository.Client.MetaData.NodeMetadata.Types[palletModule.Events.TypeId];
                    dynamicCall = $"{palletError.Path[0]}.{palletError.Path[1]}.EnumEvent";
                    dynamicEnum = $"{palletError.Path[0]}.{palletError.Path[1]}.Event";
                    break;
            }

            Assembly assembly = typeof(NetApiExt.Generated.SubstrateClientExt).Assembly;
            Type? palletType = assembly.GetType($"Blazscan.NetApiExt.Generated.Model.{dynamicCall}");
            if (palletType == null) throw new FormatException($"Dynamic call to EnumCall for pallet {palletName} has failed");

            Type? enumType = assembly.GetType($"Blazscan.NetApiExt.Generated.Model.{dynamicEnum}");
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
                    "Generated", 
                    string baseNamespace, 
                    ..
                ])
            {
                arguments = splittedNamespace.Skip(4).ToList();

                var nodeType = _substrateRepository.Client.MetaData.NodeMetadata.Types
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
                var variantType = nodeTypeVariant.Variants[Convert.ToInt32(type)];
                if(variantType == null || variantType.Docs == null) return null;

                return string.Join("\n", variantType.Docs);
            }
            return null;
        }
    }
}
