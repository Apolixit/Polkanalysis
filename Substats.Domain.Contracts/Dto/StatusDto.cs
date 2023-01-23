using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto
{
    public class GlobalStatusDto
    {
        public enum BlockStatusDto
        {
            Broadcasted,
            InBlock,
            Finalized,
            FinalityTimeout,
            Retracted,
            Usurped
        }

        public enum AliveStatusDto
        {
            Active,
            Inactive,
        }

        public enum NominationPoolStatusDto
        {
            Open = 0,
            Blocked = 1,
            Destroying = 2,
        }
    }
    
}
