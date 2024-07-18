using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Extrinsics
{
    public class ExtrinsicsInformationModel : BlockchainModel
    {
        [Key]
        public uint Id { get; set; }
        public required uint BlockNumber { get; set; }
        public required uint ExtrinsicIndex { get; set; }
        public required DateTime BlockDate { get; set; }
        public required EraLifetimeModel? Lifetime { get; set; }
        public required string Method { get; set; }
        public required string Event { get; set; }
        public string? AccountAddress { get; set; }
        public double? Charge { get; set; }
        public bool IsSigned { get; set; }
        public string? Signature { get; set; }
        public int TransactionVersion { get; set; }
        public string Status { get; set; } = string.Empty;
        public string StatusMessage { get; set; } = string.Empty;
        public double? Fees { get; set; }
    }
}
