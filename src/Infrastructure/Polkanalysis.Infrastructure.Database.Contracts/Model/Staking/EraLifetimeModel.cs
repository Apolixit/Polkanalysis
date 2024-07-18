using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Staking
{
    public class EraLifetimeModel : BlockchainModel
    {
        [Key]
        public uint Id { get; set; }
        public bool IsImmortal { get; set; }
        public uint? StartBlock { get; set; }
        public uint? EndBlock { get; set; }
    }
}
