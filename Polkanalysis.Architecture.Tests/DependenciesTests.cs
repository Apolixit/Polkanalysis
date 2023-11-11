﻿using NetArchTest.Rules;
using Polkanalysis.Api.Controllers;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.WebApp;
using Polkanalysis.Worker.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Architecture.Tests
{
    public class DependenciesTests : ArchiBaseTests
    {
        [Test]
        public void DomainProject_ShouldOnlyDependsOn()
        {
            var forbiddenDependencies = Types
                .InAssembly(DomainAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(ApiAssembly.FullName, WebAppAssembly.FullName, WorkerAssembly.FullName)
                .GetResult();

            Assert.That(forbiddenDependencies.IsSuccessful, Is.True);
        }

        [Test]
        public void WebAppProject_ShouldOnlyDependsOn()
        {
            var forbiddenDependencies = Types
                .InAssembly(WebAppAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(ApiAssembly.FullName, WorkerAssembly.FullName)
                .GetResult();

            Assert.That(forbiddenDependencies.IsSuccessful, Is.True);
        }

        [Test]
        public void ApiProject_ShouldOnlyDependsOn()
        {
            var forbiddenDependencies = Types
                .InAssembly(ApiAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(WebAppAssembly.FullName, WorkerAssembly.FullName)
                .GetResult();

            Assert.That(forbiddenDependencies.IsSuccessful, Is.True);
        }

        [Test]
        public void InfrastructureDatabaseProject_ShouldOnlyDependsOn()
        {
            var forbiddenDependencies = Types
                .InAssembly(InfrastructureDatabaseAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(WebAppAssembly.FullName, WorkerAssembly.FullName, ApiAssembly.FullName)
                .GetResult();

            Assert.That(forbiddenDependencies.IsSuccessful, Is.True);
        }

        [Test]
        public void InfrastructureBlockchainProject_ShouldOnlyDependsOn()
        {
            var forbiddenDependencies = Types
                .InAssembly(InfrastructureBlockchainAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(WebAppAssembly.FullName, WorkerAssembly.FullName, ApiAssembly.FullName)
                .GetResult();

            Assert.That(forbiddenDependencies.IsSuccessful, Is.True);
        }
    }
}
