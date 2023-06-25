using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Era
{
    public class CurrentEraDto
    {
        public uint EraId { get; set; }
        public uint EraBlockNumberStart { get; set; }

        public uint SessionCurrentIndex { get; set; }
        public uint SessionStartIndex { get; set; }
        public uint NbSessionPerEra { get; set; }

        public uint NbActiveValidators { get; set; }
        public uint NbInactiveValidators { get; set;}
        public uint NbTotalValidators { get; set; }
        public uint NbIdealActiveValidators { get; set; }
        public double MinAmountBondValidator { get; set; }
        public uint NbMaxValidators { get; set; }

        public uint NbMaxNominators { get; set; }
        //public uint NbActiveNominators { get; set; }
        public uint NbTotalNominators { get; set; }
        public double MinAmountBondNominator { get; set; }
        //public uint NbIdealActiveValidators { get; set; }
    }
}
