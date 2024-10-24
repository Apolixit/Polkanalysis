using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;

namespace Polkanalysis.Domain.Contracts
{
    public record DispatchInfoDto(Pays PaysFee, DispatchClass Class, ulong Weight)
    {
    }
}
