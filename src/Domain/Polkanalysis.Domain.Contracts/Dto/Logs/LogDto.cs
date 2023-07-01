using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Logs
{
    public class LogDto
    {
        public ulong BlockNumber { get; set; }
        public int LogIndex { get; set; }
        public Secondary.Pallet.SystemCore.Enums.DigestItem LogType { get; set; }
        public string ConsensusName { get; set; } = string.Empty;
        public string DateHex { get; set; } = string.Empty;
    }
}
