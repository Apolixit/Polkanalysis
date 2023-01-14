using Ajuna.NetApi.Model.Meta;
using Substats.Domain.Contracts.Runtime;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Runtime
{
    public class PalletInformation : IPalletInformation
    {
        private readonly ICurrentMetaData _metaData;
        private readonly ILogger<PalletInformation> _logger;
        private readonly INode _node;

        public PalletInformation(ICurrentMetaData metaData, ILogger<PalletInformation> logger, INode node)
        {
            _metaData = metaData;
            _logger = logger;
            _node = node;
        }

        public INode GetModuleCalls(string palletName, CancellationToken cancellationToken)
        {
            var palletModule = _metaData.GetPalletModule(palletName);
            var typeInfo = _metaData.GetPalletType(palletModule.Calls.TypeId);
            
            return _node.Create();
        }

        public INode GetModuleConstants(string palletName, CancellationToken cancellationToken)
        {
            var palletModule = _metaData.GetPalletModule(palletName);

            var constantTab = _node.Create();
            foreach (var constant in palletModule.Constants)
            {
                var constantItem = _node.Create();
                constantItem.AddName(constant.Name);
                constantItem.AddHumanData(constant.Value);
                constantItem.AddDocumentation(constant.Docs);
                constantTab.AddChild(constantItem);
            }

            return constantTab;
        }

        public INode GetModuleErrors(string palletName, CancellationToken cancellationToken)
        {
            var palletModule = _metaData.GetPalletModule(palletName);
            var typeInfo = _metaData.GetPalletType(palletModule.Calls.TypeId);

            return _node.Create();
        }

        public INode GetModuleEvents(string palletName, CancellationToken cancellationToken)
        {
            var palletModule = _metaData.GetPalletModule(palletName);
            var typeInfo = _metaData.GetPalletType(palletModule.Calls.TypeId);

            return _node.Create();
        }

        public INode GetModuleStorage(string palletName, CancellationToken cancellationToken)
        {
            var palletModule = _metaData.GetPalletModule(palletName);
            //var typeInfo = _metaData.GetPalletType(palletModule.Storage.);

            return _node.Create();
        }
    }
}
