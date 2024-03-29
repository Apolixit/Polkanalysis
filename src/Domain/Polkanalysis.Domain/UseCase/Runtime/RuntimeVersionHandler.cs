﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Runtime
{
    public class RuntimeVersionHandler : Handler<RuntimeModulesHandler, IEnumerable<SpecVersionDto>, RuntimeVersionQuery>
    {
        private readonly IModuleInformation _moduleRepository;

        public RuntimeVersionHandler(ILogger<RuntimeModulesHandler> logger, IModuleInformation moduleRepository) : base(logger)
        {
            _moduleRepository = moduleRepository;
        }

        public async override Task<Result<IEnumerable<SpecVersionDto>, ErrorResult>> Handle(RuntimeVersionQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _moduleRepository.GetRuntimeVersionsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
