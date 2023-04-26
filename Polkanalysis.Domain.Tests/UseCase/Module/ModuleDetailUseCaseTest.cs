using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Domain.UseCase.Module;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;

namespace Polkanalysis.Domain.Tests.UseCase.Module
{
    public class ModuleDetailUseCaseTest : UseCaseTest<RuntimeModuleDetailUseCase, ModuleDetailDto, ModuleDetailCommand>
    {
        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<RuntimeModuleDetailUseCase>>();
            _useCase = new ModuleDetailUseCase(_logger);
            base.Setup();
        }
    }
}
