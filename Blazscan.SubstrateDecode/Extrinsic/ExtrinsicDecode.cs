using Blazscan.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Extrinsic
{
    public class ExtrinsicDecode
    {
        private readonly ISubstrateNodeRepository _substrateService;
        public ExtrinsicDecode(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateService = substrateNodeRepository;
        }

        public void ReadExtrinsic(Ajuna.NetApi.Model.Extrinsics.Extrinsic extrinsic)
        {
            var nodeMetadata = _substrateService.Client.MetaData.NodeMetadata;
            var metadataModules = _substrateService.Client.MetaData.NodeMetadata.Modules;
            var metadataExtrinsic = _substrateService.Client.MetaData.NodeMetadata.Extrinsic;
            var moduleName = metadataModules.FirstOrDefault(x => x.Value.Index == extrinsic.Method.ModuleIndex);

            //var moduleError = (ModuleError)input;
            //moduleError.Index
            //MetaData.CreateModuleDict()
            var pallet = _substrateService.Client.MetaData.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];
            var palletCall = nodeMetadata.Types[pallet.Calls.TypeId];

            var realCall = new Blazscan.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras_inherent.pallet.EnumCall();
            realCall.Create(extrinsic.Method.Parameters);


            var fullQualifiedName = $"Blazscan_NetApiExt.Generated.Storage.{pallet.Name}Errors, Blazscan_NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            Type palletErrorType = Type.GetType(fullQualifiedName);
            var palletInstance = Activator.CreateInstance(palletErrorType);

            //var callName = metadataExtrinsic. extrinsic.Method.CallIndex);
            //_substrateService.Client.MetaData.NodeMetadata.Types
            var callName = true;


        }
    }
}
