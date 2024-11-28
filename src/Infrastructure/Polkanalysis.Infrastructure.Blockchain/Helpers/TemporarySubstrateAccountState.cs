using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Helpers
{
    public class TemporarySubstrateAccountState : IDisposable
    {
        private readonly bool _originalValue;

        public TemporarySubstrateAccountState(bool newValue)
        {
            _originalValue = SubstrateAccount.IsSubstrate;
            SubstrateAccount.IsSubstrate = newValue;
        }

        public void Dispose()
        {
            SubstrateAccount.IsSubstrate = _originalValue;
        }
    }
}
