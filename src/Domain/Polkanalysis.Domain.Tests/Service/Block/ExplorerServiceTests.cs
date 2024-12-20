﻿using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;

namespace Polkanalysis.Domain.Tests.Service.Block
{
    public abstract class ExplorerServiceTests
    {
        protected IExplorerService _explorerService;
        protected ISubstrateService _substrateService;
        protected ISubstrateDecoding _substrateDecode;
        protected ICoreService _coreService;

        [SetUp]
        public void Setup()
        {
            _substrateService = Substitute.For<ISubstrateService>();
            _substrateDecode = Substitute.For<ISubstrateDecoding>();
            _coreService = Substitute.For<ICoreService>();

            _explorerService = new ExplorerService(
                _substrateService,
                _substrateDecode,
                Substitute.For<IAccountService>(),
                Substitute.For<ILogger<ExplorerService>>(),
                _coreService);


        }


    }
}
