using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Versionning
{
    public class PalletVersionning
    {
        public PalletVersionning(PalletVersionAttribute version, IType storage)
        {
            Version = version;
            Storage = storage;
        }

        public PalletVersionAttribute Version { get; set; }
        public IType Storage { get; set; }
    }
}
