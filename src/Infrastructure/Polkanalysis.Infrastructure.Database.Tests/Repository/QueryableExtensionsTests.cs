using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Database.Repository;
using System.Linq;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository
{
    public class TestEntity
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }

    public class QueryableExtensionsTests
    {
        // Data set
        private List<TestEntity> testData = new List<TestEntity>
    {
        new TestEntity { Id = 1, Value = 10 },
        new TestEntity { Id = 2, Value = 20 },
        new TestEntity { Id = 3, Value = 30 },
        new TestEntity { Id = 4, Value = 40 },
        new TestEntity { Id = 5, Value = 50 },
    };

        [Test]
        public void Where_LowerStrict_CorrectResultsReturned()
        {
            var criteria = NumberCriteria<int>.LowerStrict(30);
            var queryable = testData.AsQueryable();
            var filteredResults = queryable.WhereCriteria(criteria, x => x.Value);

            Assert.That(filteredResults.Count(), Is.EqualTo(2));
            Assert.That(filteredResults.First().Id, Is.EqualTo(4));
        }

        [Test]
        public void Where_LowerOrEqual_CorrectResultsReturned()
        {
            var criteria = NumberCriteria<int>.LowerOrEqualThan(30);
            var queryable = testData.AsQueryable();
            var filteredResults = queryable.WhereCriteria(criteria, x => x.Value);

            Assert.That(filteredResults.Count(), Is.EqualTo(3));
            Assert.That(filteredResults.Last().Id, Is.EqualTo(3));
        }

        [Test]
        public void Where_Equal_CorrectResultsReturned()
        {
            var criteria = NumberCriteria<int>.Equal(30);
            var queryable = testData.AsQueryable();
            var filteredResults = queryable.WhereCriteria(criteria, x => x.Value);

            Assert.That(filteredResults.Count(), Is.EqualTo(1));
            Assert.That(filteredResults.Single().Id, Is.EqualTo(3));
        }

        [Test]
        public void Where_GreaterStrict_CorrectResultsReturned()
        {
            var criteria = NumberCriteria<int>.GreaterThan(30);
            var queryable = testData.AsQueryable();
            var filteredResults = queryable.WhereCriteria(criteria, x => x.Value);

            Assert.That(filteredResults.Count(), Is.EqualTo(2));
            Assert.That(filteredResults.Last().Id, Is.EqualTo(5));
        }

        [Test]
        public void Where_GreaterOrEqual_CorrectResultsReturned()
        {
            var criteria = NumberCriteria<int>.GreaterOrEqualThan(30);
            var queryable = testData.AsQueryable();
            var filteredResults = queryable.WhereCriteria(criteria, x => x.Value);

            Assert.That(filteredResults.Count(), Is.EqualTo(3));
            Assert.That(filteredResults.First().Id, Is.EqualTo(3));
        }

        [Test]
        public void Where_Between_CorrectResultsReturned()
        {
            var criteria = NumberCriteria<int>.Between(20, 40);
            var queryable = testData.AsQueryable();
            var filteredResults = queryable.WhereCriteria(criteria, x => x.Value);

            Assert.That(filteredResults.Count(), Is.EqualTo(3));
            Assert.That(filteredResults.First().Id, Is.EqualTo(2));
            Assert.That(filteredResults.Last().Id, Is.EqualTo(4));
        }
    }
}
