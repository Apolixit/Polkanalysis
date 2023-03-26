﻿using Polkanalysis.Domain.Contracts.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Runtime.Module;

namespace Polkanalysis.Infrastructure.DirectAccess.Tests.Repository
{
    public class ModuleInformationTest
    {
        private IModuleInformation _moduleRepository;
        private ICurrentMetaData _currentMetaData;
        private IModelBuilder _modelBuilder;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = Substitute.For<ICurrentMetaData>();
            _modelBuilder = Substitute.For<IModelBuilder>();
            _moduleRepository = new ModuleInformation(_currentMetaData, _modelBuilder);
        }

        [Test]
        public void GetModule_WithNullModuleName_ShouldFailed()
        {
            Assert.Throws<ArgumentNullException>(() => _moduleRepository.GetModuleDetail(Arg.Any<string>()));
        }
    }
}
