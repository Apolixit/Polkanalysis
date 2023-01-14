using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.UseCase.Explorer.Block;
using Substats.Domain.UseCase;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NSubstitute.ReturnsExtensions;

namespace Substats.Domain.Tests.UseCase
{
    /// <summary>
    /// Global UseCase test class
    /// Every use cases have common behaviors to test
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class UseCaseTest<T, U, V> 
        where T : class
        where U : class
        where V : class
    {
        protected ILogger<T> _logger;
        protected UseCase<T, U, V> _useCase;

        public virtual void Setup()
        {
            if(_logger == null)
                throw new ArgumentException(nameof(_logger));

            if (_useCase == null)
                throw new ArgumentException(nameof(_useCase));
        }

        [Test]
        public async Task GenericUseCaseWithNullRequest_ShouldFailedAsync()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var result = await _useCase.ExecuteAsync(null, CancellationToken.None);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyParam);

            // We got an error status result, so we need to log at least one log error
            //_logger.Received().LogError(Arg.Any<string>());
        }

        
    }
}
