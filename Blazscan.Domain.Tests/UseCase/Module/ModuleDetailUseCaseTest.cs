using Blazscan.Domain.Contracts.Dto.Module;
using Blazscan.Domain.Contracts.Primary;
using Blazscan.Domain.UseCase.Account;
using Blazscan.Domain.UseCase.Module;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.UseCase.Module
{
    public class ModuleDetailUseCaseTest : UseCaseTest<ModuleDetailUseCase, ModuleDetailDto, ModuleCommand>
    {
        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<ModuleDetailUseCase>>();
            _useCase = new ModuleDetailUseCase(_logger);
            base.Setup();
        }
    }
}
