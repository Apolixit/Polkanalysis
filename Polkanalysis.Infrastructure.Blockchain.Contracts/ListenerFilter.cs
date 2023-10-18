using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts
{
    public class ListenerFilter
    {
        public RuntimeEvent PalletName { get; internal set; }
        public Enum EventName { get; internal set; }
        public IEnumerable<SubstrateAccount> IncludeAccount { get; internal set; }


        public ListenerFilter FromPalletName(RuntimeEvent palletName)
        {
            PalletName = palletName;
            return this;
        }

        public ListenerFilter FromEventName(Enum eventName)
        {
            EventName = eventName;
            return this;
        }

        public ListenerFilter WithAccount(SubstrateAccount account)
        {
            IncludeAccount = new List<SubstrateAccount>() { account };
            return this;
        }

        public ListenerFilter WithAccounts(IEnumerable<SubstrateAccount> accounts)
        {
            IncludeAccount = accounts;
            return this;
        }
    }

    internal class ArithmeticFilter
    {
        public enum Operator
        {
            Lower,
            LowerOrEqual,
            Equal,
            UpperOrEqual,
            Upper
        }
    }
}
