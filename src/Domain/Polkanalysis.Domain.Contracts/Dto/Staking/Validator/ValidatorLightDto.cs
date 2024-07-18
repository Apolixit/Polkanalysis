using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Validator
{
    public class ValidatorLightDto
    {
        public required UserIdentityDto StashAddress { get; set; }
        public required double SelfBonded { get; set; }
        public required double TotalBonded { get; set; }
        public required double Commission { get; set; }
        public required double NbNominatorsVote { get; set; }
    }
}
