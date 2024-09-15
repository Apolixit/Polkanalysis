using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Helper;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V10;
using Substrate.NET.Metadata.V11;
using Substrate.NET.Metadata.V12;
using Substrate.NET.Metadata.V13;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Metadata.V9;
using Substrate.NetApi;

namespace Polkanalysis.Domain.UseCase.Runtime.SpecVersion
{
    public class CompareSpecVersionHandler : Handler<CompareSpecVersionHandler, CompareSpecVersionDto, CompareSpecVersionsQuery>
    {
        private readonly ISubstrateService _substrateService;
        private readonly SubstrateDbContext _dbContext;

        public CompareSpecVersionHandler(
            SubstrateDbContext dbContext,
            ISubstrateService substrateService,
            ILogger<CompareSpecVersionHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<CompareSpecVersionDto, ErrorResult>> HandleInnerAsync(CompareSpecVersionsQuery request, CancellationToken cancellationToken)
        {
            var metadataSource = string.Empty;
            var metadataTarget = string.Empty;

            if(request.SpecVersionSource is not null)
            {
                var specVersionSource = _dbContext.SpecVersionModels.SingleOrDefault(x => x.SpecVersion == request.SpecVersionSource);
                var specVersionTarget = _dbContext.SpecVersionModels.SingleOrDefault(x => x.SpecVersion == request.SpecVersionTarget);

                if(specVersionSource is null || specVersionTarget is null)
                    return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"No spec version is inserted in database for tuple ({request.SpecVersionSource}, {request.SpecVersionTarget}). Please use '/versions/{{blockStartHash}}/{{blockEndHash}}' to get data from Substrate");

                metadataSource = specVersionSource.Metadata;
                metadataTarget = specVersionTarget.Metadata;

            } else if(request.BlockNumberSource is not null && request.BlockNumberTarget is not null)
            {
                var sourceBlockHashTask = _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(request.BlockNumberSource.Value), cancellationToken);
                var targetBlockHashTask = _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(request.BlockNumberTarget.Value), cancellationToken);

                var (sourceBlockHash, targetBlockHash) = await WaiterHelper.WaitAndReturnAsync(sourceBlockHashTask, targetBlockHashTask);
                if(string.IsNullOrEmpty(sourceBlockHash?.Value) || string.IsNullOrEmpty(targetBlockHash?.Value))
                    return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"Block hash are invalid");

                var metadataSourceTask = _substrateService.Rpc.State.GetMetaDataAsync(sourceBlockHash.Bytes, cancellationToken);
                var metadataTargetTask = _substrateService.Rpc.State.GetMetaDataAsync(targetBlockHash.Bytes, cancellationToken);

                (metadataSource, metadataTarget) = await WaiterHelper.WaitAndReturnAsync(metadataSourceTask, metadataTargetTask);

            } else if(request.BlockHashSource is not null)
            {
                var metadataSourceTask = _substrateService.Rpc.State.GetMetaDataAsync(Utils.HexToByteArray(request.BlockHashSource), cancellationToken);
                var metadataTargetTask = _substrateService.Rpc.State.GetMetaDataAsync(Utils.HexToByteArray(request.BlockHashTarget), cancellationToken);

                (metadataSource, metadataTarget) = await WaiterHelper.WaitAndReturnAsync(metadataSourceTask, metadataTargetTask);
            } else
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set properly");
            }

            if(string.IsNullOrEmpty(metadataSource) || string.IsNullOrEmpty(metadataTarget))
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"An error happened when trying to fetch metadata hex");

            var checkVersion = MetadataUtils.EnsureMetadataVersion(metadataSource, metadataTarget);

            var dto = checkVersion switch
            {
                MetadataVersion.V9 => new CompareSpecVersionDto(MetadataUtils.MetadataCompareV9(new MetadataV9(metadataSource), new MetadataV9(metadataTarget))),
                MetadataVersion.V10 => new CompareSpecVersionDto(MetadataUtils.MetadataCompareV10(new MetadataV10(metadataSource), new MetadataV10(metadataTarget))),
                MetadataVersion.V11 => new CompareSpecVersionDto(MetadataUtils.MetadataCompareV11(new MetadataV11(metadataSource), new MetadataV11(metadataTarget))),
                MetadataVersion.V12 => new CompareSpecVersionDto(MetadataUtils.MetadataCompareV12(new MetadataV12(metadataSource), new MetadataV12(metadataTarget))),
                MetadataVersion.V13 => new CompareSpecVersionDto(MetadataUtils.MetadataCompareV13(new MetadataV13(metadataSource), new MetadataV13(metadataTarget))),
                MetadataVersion.V14 => new CompareSpecVersionDto(MetadataUtils.MetadataCompareV14(new MetadataV14(metadataSource), new MetadataV14(metadataTarget))),
                _ => throw new InvalidOperationException("MetadataV15 comparison is not yet supported ! Stay tuned.")
            };

            return dto;
        }
    }
}
