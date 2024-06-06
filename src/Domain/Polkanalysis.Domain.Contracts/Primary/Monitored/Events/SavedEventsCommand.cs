using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Primary.Monitored.Events
{
    public class SavedEventsCommand : IRequest<Result<bool, ErrorResult>>
    {
        public SavedEventsCommand(BlockNumber blockNumber, DateTime currentDate, int eventIndex, EventRecord ev, IEventNode eventNode)
        {
            this.BlockNumber = blockNumber;
            this.CurrentDate = currentDate;
            this.EventIndex = eventIndex;
            this.Ev = ev;
            this.EventNode = eventNode;
        }

        public BlockNumber BlockNumber { get; set; }
        public DateTime CurrentDate { get; set; }
        public int EventIndex { get; set; }
        public EventRecord Ev { get; set; }
        public IEventNode EventNode { get; set;}
    }
}
