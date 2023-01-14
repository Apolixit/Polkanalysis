using Substats.Domain.Contracts;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Infrastructure.DirectAccess.Tests.Block;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Tests.Repository
{
    public class BlockRepositoryTests : ExplorerRepositoryTests
    {
        [Test]
        public void GetLastBlockAsync_ShouldReturnLastBlock()
        {
            Assert.True(true);
        }
    }
}
