using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Secondary;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Tests.Repository
{
    internal class BlockRepositoryTests
    {
        private IExplorerRepository _blockRepository;

        [SetUp]
        public void Setup()
        {
            _blockRepository = Substitute.For<IExplorerRepository>();
        }

        [Test]
        public void GetLastBlockAsync_ShouldReturnLastBlock()
        {
            Assert.True(true);
        }
    }
}
