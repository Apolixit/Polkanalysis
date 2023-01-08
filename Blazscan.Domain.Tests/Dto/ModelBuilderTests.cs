using Blazscan.Domain.Contracts.Dto;
using Blazscan.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.Dto
{
    public class ModelBuilderTests
    {
        private IModelBuilder _modelBuilder;

        [SetUp]
        public void SetUp()
        {
            _modelBuilder = new ModelBuilder();
        }

        [Test]
        public void DisplayElapsedTime_WithValidTimes_ShouldWork()
        {
            var twoDaysElapsed = TimeSpan.FromDays(2);
            var dateTwoDaysAgo = DateTime.Now.Subtract(twoDaysElapsed);
            var display = _modelBuilder.DisplayElapsedTime(dateTwoDaysAgo);

            Assert.That(display, Is.EqualTo("2 days ago"));
        }

        [Test]
        public void DisplayElapsedTime_WithTimeInFuture_ShouldFailed()
        {
            var t1 = DateTime.Now.AddDays(2);
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.DisplayElapsedTime(t1));
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.DisplayElapsedTime(t1, DateTime.Now));
        }
    }
}
