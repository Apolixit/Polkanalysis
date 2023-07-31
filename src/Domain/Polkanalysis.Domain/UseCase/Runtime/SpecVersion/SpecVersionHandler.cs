using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Polkanalysis.Domain.Helper.Enumerables;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Substrate.NET.Metadata;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.Base;

namespace Polkanalysis.Domain.UseCase.Runtime.SpecVersion
{
    /// <summary>
    /// Get all Substrate runtime version
    /// </summary>
    public class SpecVersionHandler : Handler<SpecVersionHandler, IEnumerable<SpecVersionDto>, SpecVersionsQuery>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateService _substrateService;

        public SpecVersionHandler(
            SubstrateDbContext dbContext,
            ISubstrateService substrateService,
            ILogger<SpecVersionHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<IEnumerable<SpecVersionDto>, ErrorResult>> Handle(SpecVersionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<SpecVersionModel> dbRes = _dbContext.SpecVersionModels;

            if(!string.IsNullOrEmpty(request.BlockchainName))
            {
                dbRes = dbRes.Where(x => x.BlockchainName == request.BlockchainName);
            }

            var specVersionExtended = await dbRes
                .ExtendWith(x => _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(x.BlockStart), cancellationToken))
                .WaitAllAndGetResultAsync();

            return specVersionExtended.Select(x => new SpecVersionDto()
            {
                SpecVersion = x.Item1.SpecVersion,
                BlockStart = x.Item1.BlockStart,
                BlockStartHash = x.Item2.Value,
                BlockEnd = x.Item1.BlockEnd,
                BlockEndHash = "",
                MetadataVersion = x.Item1.MetadataVersion
            }).ToList();

        }
    }

    /// <summary>
    /// Insert a new Substrate version in database
    /// </summary>
    public class SpecVersionCommandHandler : Handler<SpecVersionCommandHandler, bool, SpecVersionCommand>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateService _substrateService;
        private readonly IMetadataService _metadataService;


        public SpecVersionCommandHandler(
            SubstrateDbContext dbContext, 
            ISubstrateService substrateService,
            IMetadataService metadataService,
            ILogger<SpecVersionCommandHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
            _metadataService = metadataService;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(SpecVersionCommand request, CancellationToken cancellationToken)
        {
            var startBlockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(request.BlockStart), cancellationToken);
            var newMetadata = await _substrateService.Rpc.State.GetMetaDataAtAsync(startBlockHash.Value, cancellationToken);

            if(string.IsNullOrEmpty(newMetadata))
                throw new InvalidOperationException($"Metadata from block {request.BlockStart} is empty...");

            var metadataInfo = new CheckRuntimeMetadata(newMetadata);

            var model = new SpecVersionModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                SpecVersion = request.SpecVersion,
                BlockStart = request.BlockStart,
                BlockEnd = request.BlockEnd,
                MetadataVersion = metadataInfo.MetaDataInfo.Version.Value,
                Metadata = newMetadata,
            };

            await _dbContext.AddAsync(model, cancellationToken);
            var nbRows = _dbContext.SaveChanges();
            if (nbRows != 1)
                throw new InvalidOperationException("Inserted rows are inconsistent");

            // Now let's check pallet changed and also insert them in database to keep try of every

            if(request.BlockStart > 0)
            {
                var previousBlock = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(request.BlockStart - 1), cancellationToken);
                var previousMetadata = await _substrateService.Rpc.State.GetMetaDataAtAsync(previousBlock.Value, cancellationToken);

                if (string.IsNullOrEmpty(previousMetadata))
                    throw new InvalidOperationException($"Metadata from block {request.BlockStart - 1} is empty...");

                // Just ensure previous block was on previous Metadata, otherwise we got a huge problem
                var previousVersion = new CheckRuntimeMetadata(previousMetadata);
                if (previousVersion.MetaDataInfo.Version.Value != metadataInfo.MetaDataInfo.Version.Value - 1)
                    throw new InvalidOperationException($"Metadata (v{previousVersion.MetaDataInfo.Version.Value}) from previous block is not previous from current metadata block (v{metadataInfo.MetaDataInfo.Version.Value})");

                await OnUpgradeVersionCheckPalletChangedAsync(previousMetadata, newMetadata, MetadataVersion.V14);
            }

            return true;
        }

        /// <summary>
        /// Check pallets which changed when a new spec version is release and increment their version in database
        /// </summary>
        /// <returns></returns>
        public async Task OnUpgradeVersionCheckPalletChangedAsync(
            string oldMetadata, string newMetadata, MetadataVersion version)
        {


            // Loop on every pallet and check

        }
    }
}
