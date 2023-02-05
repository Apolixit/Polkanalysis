using Ajuna.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary
{
    public class ISubstrateRepository
    {
        public SubstrateClient Client { get; }
        public IStorage Storage { get; }
        public IRpc Rpc { get; }
        public IConstants Constants { get; }
        public ICalls Calls { get; }
        public IEvents Events { get; }
        public IErrors Errors { get; }
        //public IExtrinsic Extrinsics { get; }
    }
}
