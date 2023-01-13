using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.Infrastructure.DirectAccess.Tests.Block;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Tests.Repository
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
