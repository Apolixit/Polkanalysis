using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Parachain;
using Polkanalysis.Domain.UseCase.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Price
{
    public class TokenPriceHandlerTest : UseCaseTest<TokenPriceHandler, TokenPriceDto, TokenPriceQuery>
    {
        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<TokenPriceHandler>>();
            _useCase = new TokenPriceHandler(Substitute.For<HttpClient>(), _logger);
        }
    }
}
