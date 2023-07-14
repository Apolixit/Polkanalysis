using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Runtime.PalletVersion
{
    /// <summary>
    /// Get all pallet version for given pallet
    /// </summary>
    public class PalletVersionHandler : Handler<PalletVersionHandler, IEnumerable<PalletVersionDto>, PalletVersionsQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public PalletVersionHandler(SubstrateDbContext dbContext, ILogger<PalletVersionHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<IEnumerable<PalletVersionDto>, ErrorResult>> Handle(PalletVersionsQuery request, CancellationToken cancellationToken)
        {
            var res = await _dbContext.PalletVersionModels
                .Where(x => x.PalletName == request.PalletName)
                .Select(x => new PalletVersionDto()
                {
                    PalletName = x.PalletName,
                    PalletVersion = x.PalletVersion
                })
                .ToListAsync(cancellationToken);

            return res;
        }
    }

    /// <summary>
    /// Insert a new pallet version for a given pallet in database
    /// </summary>
    public class PalletVersionCommandHandler : Handler<PalletVersionCommandHandler, bool, PalletVersionCommand>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateService _substrateService;

        public PalletVersionCommandHandler(SubstrateDbContext dbContext, ILogger<PalletVersionCommandHandler> logger, ISubstrateService substrateService) : base(logger)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(PalletVersionCommand request, CancellationToken cancellationToken)
        {
            var model = new PalletVersionModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                PalletId = request.PalletId,
                PalletName = _substrateService.RuntimeMetadata.NodeMetadata.Modules.SingleOrDefault(x => x.Value.Index == request.PalletId).Value.Name,
                PalletVersion = request.PalletVersion,
                BlockStart = request.BlockStart,
                BlockEnd = request.BlockEnd,
            };

            await _dbContext.AddAsync(model, cancellationToken);

            var nbRows = _dbContext.SaveChanges();
            if (nbRows != 1)
                throw new InvalidOperationException("Inserted rows are inconsistent");

            return true;
        }
    }
}
