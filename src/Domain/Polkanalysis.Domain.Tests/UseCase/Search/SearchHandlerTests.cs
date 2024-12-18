using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Search;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Search
{
    public class SearchHandlerTests : UseCaseTest<SearchHandler, IEnumerable<SearchResultDto>, SearchQuery>
    {
        private ISearchService _searchService;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SearchHandler>>();
            _searchService = Substitute.For<ISearchService>();

            _useCase = new SearchHandler(_logger, Substitute.For<HybridCache>(), _searchService);
        }

        [Test]
        public void SearchValidator_WhenEmptyRequest_ShouldFail()
        {
            Assert.That(new SearchQueryValidator().Validate(new SearchQuery("")).IsValid, Is.False);
        }
    }
}
