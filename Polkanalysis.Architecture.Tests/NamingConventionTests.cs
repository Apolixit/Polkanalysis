using MediatR;
using NetArchTest.Rules;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Architecture.Tests
{
    public class NamingConventionTests : ArchiBaseTests
    {
        [Test]
        public void MediatorUseCaseHandler_ShouldHaveValidSuffix()
        {
            var useCasesHandler = Types
                .InAssembly(DomainAssembly)
                .That().Inherit(typeof(Handler<,,>))
                .Should().HaveNameEndingWith("Handler")
                .GetResult();

            Assert.That(useCasesHandler.IsSuccessful, Is.True);
        }

        [Test]
        public void MediatorQuery_ShouldHaveValidSuffix()
        {
            var useCasesHandler = Types
                .InAssembly(DomainContractAssembly)
                .That().Inherit(typeof(IRequest<>))
                .Should().HaveNameEndingWith("Query")
                .GetResult();

            Assert.That(useCasesHandler.IsSuccessful, Is.True);
        }

        [Test]
        public void MediatorCommand_ShouldHaveValidSuffix()
        {
            var useCasesHandler = Types
                .InAssembly(DomainContractAssembly)
                .That().Inherit(typeof(IRequest<Result<bool, ErrorResult>>))
                .Should().HaveNameEndingWith("Command")
                .GetResult();

            Assert.That(useCasesHandler.IsSuccessful, Is.True);
        }
    }
}
