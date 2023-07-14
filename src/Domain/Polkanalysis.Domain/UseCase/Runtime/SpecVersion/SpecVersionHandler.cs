using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.UseCase.Runtime.PalletVersion;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.UseCase.Runtime.SpecVersion
{
    /// <summary>
    /// Get all Substrate runtime version
    /// </summary>
    public class SpecVersionHandler : Handler<SpecVersionHandler, IEnumerable<SpecVersionDto>, SpecVersionsQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public SpecVersionHandler(SubstrateDbContext dbContext, ILogger<SpecVersionHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<IEnumerable<SpecVersionDto>, ErrorResult>> Handle(SpecVersionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<SpecVersionModel> dbRes = _dbContext.SpecVersionModels;

            if(!string.IsNullOrEmpty(request.BlockchainName))
            {
                dbRes = dbRes.Where(x => x.BlockchainName == request.BlockchainName);
            }

            return await dbRes.Select(x => new SpecVersionDto()
            {
                SpecVersion = x.SpecVersion,

            }).ToListAsync(cancellationToken);

        }
    }

    /// <summary>
    /// Insert a new Substrate version in database
    /// </summary>
    public class SpecVersionCommandHandler : Handler<SpecVersionCommandHandler, bool, SpecVersionCommand>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateService _substrateService;

        public SpecVersionCommandHandler(SubstrateDbContext dbContext, ILogger<SpecVersionCommandHandler> logger, ISubstrateService substrateService) : base(logger)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(SpecVersionCommand request, CancellationToken cancellationToken)
        {
            var startBlockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(request.BlockStart), cancellationToken);
            var metadata = await _substrateService.Rpc.State.GetMetaDataAtAsync(startBlockHash.Value, cancellationToken);

            var model = new SpecVersionModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                SpecVersion = request.SpecVersion,
                BlockStart = request.BlockStart,
                BlockEnd = request.BlockEnd,
                Metadata = metadata ?? string.Empty,
            };

            await _dbContext.AddAsync(model, cancellationToken);
            var nbRows = _dbContext.SaveChanges();
            if (nbRows != 1)
                throw new InvalidOperationException("Inserted rows are inconsistent");

            return true;
        }
    }
}
