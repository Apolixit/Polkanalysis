using Polkanalysis.Domain.Contracts.Dto;
using NSubstitute;
using Polkanalysis.Domain.Runtime;

namespace Polkanalysis.Domain.Tests.Dto
{
    public class ModelBuilderTests
    {

        [Test]
        public void DisplayElapsedTime_WithValidTime_ShouldWork()
        {
            Assert.That(ModelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(1))), Is.EqualTo("1 day ago"));
            Assert.That(ModelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(2))), Is.EqualTo("2 days ago"));
            Assert.That(ModelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(2.5))), Is.EqualTo("2 days ago"));
            Assert.That(ModelBuilder.DisplayElapsedTime(DateTime.Now.Subtract(TimeSpan.FromDays(12.5))), Is.EqualTo("12 days ago"));
        }

        [Test]
        public void DisplayElapsedTime_WithTimeInFuture_ShouldFailed()
        {
            var t1 = DateTime.Now.AddDays(2);
            Assert.Throws<InvalidOperationException>(() => ModelBuilder.DisplayElapsedTime(t1));
            Assert.Throws<InvalidOperationException>(() => ModelBuilder.DisplayElapsedTime(t1, DateTime.Now));
        }

        [Test]
        [TestCase("1-1", 1, 1)]
        [TestCase("12-4", 12, 4)]
        public void CreateTuppleIndex_WithValidId_ShouldSuceed(string id, int mainId, int subId)
        {
            Assert.That((mainId, subId), Is.EqualTo(ModelBuilder.CreateTuppleIndex(id)));
        }

        [Test]
        public void CreateTuppleIndex_WithInvalidId_ShouldFailed()
        {
            Assert.Throws<ArgumentNullException>(() => ModelBuilder.CreateTuppleIndex(id: null!));
            Assert.Throws<FormatException>(() => ModelBuilder.CreateTuppleIndex("1--1"));
            Assert.Throws<FormatException>(() => ModelBuilder.CreateTuppleIndex(""));
            Assert.Throws<FormatException>(() => ModelBuilder.CreateTuppleIndex("invalid"));
            Assert.Throws<InvalidOperationException>(() => ModelBuilder.CreateTuppleIndex("s-1"));
            Assert.Throws<InvalidOperationException>(() => ModelBuilder.CreateTuppleIndex("1-oooooo"));
            Assert.Throws<InvalidOperationException>(() => ModelBuilder.CreateTuppleIndex("nop-nop"));
        }
    }
}
