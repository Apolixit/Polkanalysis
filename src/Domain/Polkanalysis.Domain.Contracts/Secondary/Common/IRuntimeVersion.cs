using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common
{
    public interface IRuntimeVersion
    {
        public object[][] Apis { get; }

        public int AuthoringVersion { get; }

        public string ImplName { get; }

        public uint ImplVersion { get; }

        public string SpecName { get; }

        public uint SpecVersion { get; }

        public uint TransactionVersion { get; }
    }
}
