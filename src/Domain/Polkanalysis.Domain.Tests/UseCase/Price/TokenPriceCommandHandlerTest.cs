using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.UseCase.Price;
using System.Text;

namespace Polkanalysis.Domain.Tests.UseCase.Price
{
    public class TokenPriceCommandHandlerTest : UseCaseTest<TokenPriceCommandHandler, bool, TokenPriceCommand>
    {
        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<TokenPriceCommandHandler>>();
            _useCase = new TokenPriceCommandHandler(_substrateDbContext, _logger);
        }

        [Test]
        public void TokenPriceCommandValidator_WithValidInput_ShouldSucceed()
        {
            var command = new TokenPriceCommand()
            {
                BlockchainName = "Polkadot",
                TokenPrice = new TokenPriceDto()
                {
                    Price = 10,
                    CompareToCurrency = CurrencyEnumDto.USD,
                    Date = new DateTime(2024, 1, 1)
                }
            };
            Assert.That(new TokenPriceCommandValidator().Validate(command).IsValid, Is.EqualTo(true));
        }

        [Test]
        public void TokenPriceCommandValidator_WithInvalidInput_ShouldFail()
        {
            var command = new TokenPriceCommand()
            {
                BlockchainName = "Polkadot",
                TokenPrice = new TokenPriceDto()
                {
                    Price = -1,
                    CompareToCurrency = CurrencyEnumDto.USD,
                    Date = new DateTime(2024, 1, 1)
                }
            };
            Assert.That(new TokenPriceCommandValidator().Validate(command).IsValid, Is.EqualTo(false));
        }

        [Test]
        [TestCase("Polkadot", 10)]
        public async Task TokenPriceCommand_WithValidInput_ShouldInsertInDatabaseAsync(string blockchainName, double price)
        {
            var tokenPriceDate = DateTime.Now.ToUniversalTime();
            var command = new TokenPriceCommand()
            {
                BlockchainName = blockchainName,
                TokenPrice = new TokenPriceDto()
                {
                    Price = price,
                    CompareToCurrency = CurrencyEnumDto.USD,
                    Date = tokenPriceDate
                }
            };

            // I do this, because in abstract class I already insert some data into Price table
            var initialEntriesCount = _substrateDbContext.TokenPrices.Count();

            await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(_substrateDbContext.TokenPrices.Count(), Is.EqualTo(initialEntriesCount + 1));

            var newEntry = _substrateDbContext.TokenPrices.Last();
            Assert.That(newEntry.BlockchainName, Is.EqualTo(blockchainName));
            Assert.That(newEntry.Price, Is.EqualTo(price));
            Assert.That(newEntry.Date, Is.EqualTo(tokenPriceDate));
        }
    }
}
