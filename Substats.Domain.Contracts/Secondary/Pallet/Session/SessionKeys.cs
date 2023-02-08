using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Session
{
    public class SessionKeys
    {
        public PublicEd25519 Grandpa { get; set; }
        public PublicSr25519 Babe{ get; set; }
        public PublicSr25519 ImOnline { get; set; }
        public PublicSr25519 ParaValidator { get; set; }
        public PublicSr25519 ParaAssignment { get; set; }
    }
}
