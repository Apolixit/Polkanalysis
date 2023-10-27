using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;

namespace Polkanalysis.Domain.Contracts.Dto.Logs
{
    public class LogDto
    {
        public ulong BlockNumber { get; set; }
        public int LogIndex { get; set; }
        public DigestItem LogType { get; set; }
        public string ConsensusName { get; set; } = string.Empty;
        public string DateHex { get; set; } = string.Empty;
    }
}
