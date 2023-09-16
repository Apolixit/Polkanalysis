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
    public class WebsiteConfigurationTest
    {
        [Test]
        public void WebsiteConfigurationFilled_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Website/appsettings_valid_website.json", false)
                .Build();

            var websiteConfig = new WebsiteConfiguration(config);

            Assert.That(websiteConfig, Is.Not.Null);
            Assert.That(websiteConfig.Maintenance, Is.Not.Null);
            Assert.That(websiteConfig.Maintenance.IsActivated, Is.EqualTo(true));
            Assert.That(websiteConfig.Maintenance.EndTime, Is.EqualTo("Soon..."));
        }

        [Test]
        public void WebsiteConfigurationEmpty_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Website/appsettings_valid_website_empty.json", false)
                .Build();

            var websiteConfig = new WebsiteConfiguration(config);

            Assert.That(websiteConfig, Is.Not.Null);
            Assert.That(websiteConfig.Maintenance, Is.Not.Null);
            Assert.That(websiteConfig.Maintenance.IsActivated, Is.EqualTo(false));
            Assert.That(websiteConfig.Maintenance.EndTime, Is.EqualTo(string.Empty));
        }

        [Test]
        public void WebsiteConfigurationEmpty_ShouldFail()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Website/appsettings_valid_website_empty_hard.json", false)
                .Build();

            var websiteConfig = new WebsiteConfiguration(config);

            Assert.That(websiteConfig, Is.Not.Null);
            Assert.That(websiteConfig.Maintenance, Is.Not.Null);
            Assert.That(websiteConfig.Maintenance.IsActivated, Is.EqualTo(false));
            Assert.That(websiteConfig.Maintenance.EndTime, Is.EqualTo(string.Empty));
        }
    }
}
