﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Database;
using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V10;
using Substrate.NET.Metadata.V11;
using Substrate.NET.Metadata.V12;
using Substrate.NET.Metadata.V13;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Metadata.V9;

namespace Polkanalysis.Domain.UseCase.Runtime.SpecVersion
{
    public class CompareSpecVersionHandler : Handler<CompareSpecVersionHandler, CompareSpecVersionDto, CompareSpecVersionsQuery>
    {
        private readonly IMetadataService _metadataService;
        private readonly ISubstrateService _substrateService;
        private readonly SubstrateDbContext _dbContext;

        public CompareSpecVersionHandler(
            MetadataService metadataService,
            SubstrateDbContext dbContext,
            ISubstrateService substrateService,
            ILogger<CompareSpecVersionHandler> logger) : base(logger)
        {
            _metadataService = metadataService;
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<CompareSpecVersionDto, ErrorResult>> Handle(CompareSpecVersionsQuery request, CancellationToken cancellationToken)
        {
            var metadataSource = string.Empty;
            var metadataTarget = string.Empty;

            if(request.SpecVersionSource is not null)
            {
                var specVersionSource = _dbContext.SpecVersionModels.SingleOrDefault(x => x.SpecVersion == request.SpecVersionSource);
                var specVersionTarget = _dbContext.SpecVersionModels.SingleOrDefault(x => x.SpecVersion == request.SpecVersionTarget);

                if(specVersionSource is null || specVersionTarget is null)
                    return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"No spec version is inserted in database for tuple ({request.SpecVersionSource}, {request.SpecVersionTarget})");

                metadataSource = specVersionSource.Metadata;
                metadataTarget = specVersionTarget.Metadata;

            } else if(request.BlockNumberSource is not null)
            {
                var sourceBlockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(request.BlockNumberSource.Value), cancellationToken);
                var targetBlockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(request.BlockNumberTarget.Value), cancellationToken);

                if(string.IsNullOrEmpty(sourceBlockHash?.Value) || string.IsNullOrEmpty(targetBlockHash?.Value))
                    return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"Block hash are invalid");

                metadataSource = await _substrateService.Rpc.State.GetMetaDataAtAsync(sourceBlockHash.Value, cancellationToken);
                metadataTarget = await _substrateService.Rpc.State.GetMetaDataAtAsync(targetBlockHash.Value, cancellationToken);

            } else if(request.BlockHashSource is not null)
            {
                metadataSource = await _substrateService.Rpc.State.GetMetaDataAtAsync(request.BlockHashSource, cancellationToken);
                metadataTarget = await _substrateService.Rpc.State.GetMetaDataAtAsync(request.BlockHashTarget, cancellationToken);
            } else
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set properly");
            }

            if(string.IsNullOrEmpty(metadataSource) || string.IsNullOrEmpty(metadataTarget))
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"An error happened when trying to fetch metadata hex");

            var checkVersion = _metadataService.EnsureMetadataVersion(metadataSource, metadataTarget);

            var dto = checkVersion switch
            {
                MetadataVersion.V9 => new CompareSpecVersionDto(_metadataService.MetadataCompareV9(new MetadataV9(metadataSource), new MetadataV9(metadataTarget))),
                MetadataVersion.V10 => new CompareSpecVersionDto(_metadataService.MetadataCompareV10(new MetadataV10(metadataSource), new MetadataV10(metadataTarget))),
                MetadataVersion.V11 => new CompareSpecVersionDto(_metadataService.MetadataCompareV11(new MetadataV11(metadataSource), new MetadataV11(metadataTarget))),
                MetadataVersion.V12 => new CompareSpecVersionDto(_metadataService.MetadataCompareV12(new MetadataV12(metadataSource), new MetadataV12(metadataTarget))),
                MetadataVersion.V13 => new CompareSpecVersionDto(_metadataService.MetadataCompareV13(new MetadataV13(metadataSource), new MetadataV13(metadataTarget))),
                MetadataVersion.V14 => new CompareSpecVersionDto(_metadataService.MetadataCompareV14(new MetadataV14(metadataSource), new MetadataV14(metadataTarget))),
                _ => throw new InvalidOperationException("MetadataV15 comparison is not yet supported ! Stay tuned.")
            };

            return dto;
        }
    }
}
