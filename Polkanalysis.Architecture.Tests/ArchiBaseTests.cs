using Polkanalysis.Api.Controllers;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.WebApp;
using Polkanalysis.Worker.Tasks;
using System.Reflection;

namespace Polkanalysis.Architecture.Tests
{
    public abstract class ArchiBaseTests
    {
        public static readonly Assembly ApiAssembly = typeof(AccountController).Assembly;
        public static readonly Assembly WebAppAssembly = typeof(App).Assembly;
        public static readonly Assembly WorkerAssembly = typeof(EventsWorker).Assembly;

        public static readonly Assembly DomainAssembly = typeof(AccountDetailHandler).Assembly;
        public static readonly Assembly DomainContractAssembly = typeof(AccountDetailQuery).Assembly;

        public static readonly Assembly InfrastructureDatabaseAssembly = typeof(DatabaseServiceCollectionsExtensions).Assembly;
        public static readonly Assembly InfrastructureBlockchainAssembly = typeof(PolkadotService).Assembly;
    }
}
