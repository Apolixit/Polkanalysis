﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Informations;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Informations;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Domain.UseCase.Parachain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Informations
{
    public class BlockchainInformationsHandler : Handler<BlockchainInformationsHandler, BlockchainDetailsDto, BlockchainDetailsQuery>
    {
        private readonly IParachainService _parachainRepository;
        public BlockchainInformationsHandler(
            IParachainService parachainRepository,
            ILogger<BlockchainInformationsHandler> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<BlockchainDetailsDto, ErrorResult>> Handle(BlockchainDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _parachainRepository.GetCurrentBlockchainDetailProjectAsync(cancellationToken);
            
            return Helpers.Ok(result);
        }
    }
}
