using Polkanalysis.Domain.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Common
{
    public class PaginationValidatorTest
    {
        [Test]
        [TestCase(1, 10)]
        [TestCase(10, 100)]
        public void PaginationValidator_WhenValidPagination_ShouldSucceed(int pageSize, int pageNumber)
        {
            Assert.That(new PaginationValidator().Validate(new Pagination(pageSize, pageNumber)).IsValid, Is.True);
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(101, 10)]
        [TestCase(10, 0)]
        public void PaginationValidator_WhenInvalidPagination_ShouldFail(int pageSize, int pageNumber)
        {
            Assert.That(new PaginationValidator().Validate(new Pagination(pageSize, pageNumber)).IsValid, Is.False);
        }
    }
}
