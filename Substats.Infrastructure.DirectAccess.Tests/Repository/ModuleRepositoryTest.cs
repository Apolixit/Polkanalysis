using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Infrastructure.DirectAccess.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Tests.Repository
{
    public class ModuleRepositoryTest
    {
        private IModuleRepository _moduleRepository;
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = Substitute.For<ICurrentMetaData>();
            _moduleRepository = new ModuleRepository(_currentMetaData);
        }

        [Test]
        public async Task GetModule_WithNullModuleName_ShouldFailedAsync()
        {
            Assert.Throws<ArgumentNullException>(() => _moduleRepository.GetModuleDetailAsync(Arg.Any<string>(), CancellationToken.None));
        }
    }
}
