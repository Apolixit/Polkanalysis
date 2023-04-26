using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.UseCase.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Nominator
{
    public class NominatorDetailUseCase : UseCase<NominatorDetailUseCase, NominatorDto, NominatorCommand>
    {
        public NominatorDetailUseCase(ILogger<NominatorDetailUseCase> logger) : base(logger)
        {
        }

        public override async Task<Result<NominatorDto, ErrorResult>> Handle(NominatorCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            return null;
        }
    }
}
