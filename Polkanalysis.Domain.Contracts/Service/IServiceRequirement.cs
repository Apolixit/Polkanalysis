using Polkanalysis.Domain.Contracts.Secondary.Contracts;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IServiceRequirement
    {
        public IEnumerable<IPalletStorage?> RequiredStorage { get; }
    }
}
