using Substats.Domain.Contracts.Dto;
using Substats.Domain.Dto;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Tests.Dto
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
        [TestCase()]
        public void DisplayElapsedTime_WithValidTime_ShouldWork()
        {
            Assert.That(_modelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(1))), Is.EqualTo("1 day ago"));
            Assert.That(_modelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(2))), Is.EqualTo("2 days ago"));
            Assert.That(_modelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(2.5))), Is.EqualTo("2 days ago"));
            Assert.That(_modelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(12.5))), Is.EqualTo("12 days ago"));
        }

        [Test]
        public void DisplayElapsedTime_WithTimeInFuture_ShouldFailed()
        {
            var t1 = DateTime.Now.AddDays(2);
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.DisplayElapsedTime(t1));
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.DisplayElapsedTime(t1, DateTime.Now));
        }

        [Test]
        [TestCase("1-1", 1, 1)]
        [TestCase("12-4", 12, 4)]
        public void CreateTuppleIndex_WithValidId_ShouldSuceed(string id, int mainId, int subId)
        {
            Assert.That((mainId, subId), Is.EqualTo(_modelBuilder.CreateTuppleIndex(id)));
        }

        [Test]
        public void CreateTuppleIndex_WithInvalidId_ShouldFailed()
        {
            Assert.Throws<ArgumentNullException>(() => _modelBuilder.CreateTuppleIndex(Arg.Any<string>()));
            Assert.Throws<FormatException>(() => _modelBuilder.CreateTuppleIndex("1--1"));
            Assert.Throws<FormatException>(() => _modelBuilder.CreateTuppleIndex(""));
            Assert.Throws<FormatException>(() => _modelBuilder.CreateTuppleIndex("invalid"));
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.CreateTuppleIndex("s-1"));
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.CreateTuppleIndex("1-oooooo"));
            Assert.Throws<InvalidOperationException>(() => _modelBuilder.CreateTuppleIndex("nop-nop"));
        }
    }
}
