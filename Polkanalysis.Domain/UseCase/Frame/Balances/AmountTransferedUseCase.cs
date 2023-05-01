using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Frame.Balances;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Frame.Balances
{
    public class AmountTransferedUseCase : UseCase<AmountTransferedUseCase, double, AmountTransferedQuery>
    {
        private readonly BalancesTransferRepository _balancesTransferRepository;
        public AmountTransferedUseCase(
            ILogger<AmountTransferedUseCase> logger,
            BalancesTransferRepository balancesTransferRepository) : base(logger)
        {
            _balancesTransferRepository = balancesTransferRepository;
        }

        public override Task<Result<double, ErrorResult>> Handle(AmountTransferedQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
