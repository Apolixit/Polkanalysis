using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemException = System.Exception;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Exception
{
    public class StakingEraStakerException : SystemException
    {
        public uint EraId { get; set; }
        public string ValidatorAddress { get; set; }

        public StakingEraStakerException(uint eraId, string validatorAddress, string message) : base(message)
        {
            EraId = eraId;
            ValidatorAddress = validatorAddress;
        }
    }
}
