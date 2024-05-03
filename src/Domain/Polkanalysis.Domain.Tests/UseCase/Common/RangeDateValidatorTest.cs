using Polkanalysis.Domain.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Common
{
    public class RangeDateValidatorTest
    {
        [Test]
        public void RangeDateValidator_WhenValidRangeDate_ShouldSucceed()
        {
            Assert.That(new RangeDateValidator().Validate(new RangeDate(null, null)).IsValid, Is.True);
            Assert.That(new RangeDateValidator().Validate(new RangeDate(null, DateTime.Now)).IsValid, Is.True);
            Assert.That(new RangeDateValidator().Validate(new RangeDate(DateTime.Now, null)).IsValid, Is.True);
        }

        [Test]
        public void RangeDateValidator_WhenInvalidRangeDate_ShouldFail()
        {
            Assert.That(new RangeDateValidator().Validate(new RangeDate(
                new DateTime(2024, 2, 1),
                new DateTime(2024, 1, 1))).IsValid, 
                Is.False);
        }
    }
}
