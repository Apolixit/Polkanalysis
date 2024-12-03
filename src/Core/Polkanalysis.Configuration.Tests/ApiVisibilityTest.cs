using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Polkanalysis.Configuration.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Tests
{
    public class ApiVisibilityTest
    {
        [Test]
        public void FilledApiVisibility_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Api/appsettings_valid_api_visibility.json", false)
                .Build();

            var apiVisibility = new ApiVisibility(config);

            Assert.That(apiVisibility.AvailableControllersByBlockchain, Has.Count.EqualTo(3));

            var controllers = apiVisibility.GetAvailableController("PeopleChain");
            Assert.That(controllers, Has.Count.EqualTo(2));
            Assert.That(controllers[0], Is.EqualTo("Account"));
        }

        [Test]
        public void ApiVisibility_WithEmptyBlockchainName_ShouldThrowException()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Api/appsettings_valid_api_visibility_empty_blockchain.json", false)
                .Build();

            Assert.Throws<ArgumentException>(() => new ApiVisibility(config));
        }
    }
}
