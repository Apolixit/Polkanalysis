using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IServiceRequirement
    {
        public IEnumerable<IPalletStorage?> RequiredStorage { get; }
    }
}
