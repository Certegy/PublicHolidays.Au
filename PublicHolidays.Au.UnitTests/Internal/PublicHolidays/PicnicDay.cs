using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class PicnicDayTests
    {
        private readonly PicnicDay _picnicDay;

        public PicnicDayTests()
        {
            _picnicDay = new PicnicDay();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _picnicDay.GetPublicHolidayDatesFor(Region.NT);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _picnicDay.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsDateOfSecondMondayInMarch()
        {
            const int year = 2017;
            var result = _picnicDay.In(year);
            result.ShouldContain(new DateTime(year, 8, 7));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _picnicDay.GetNameOfPublicHolidayIn(Region.NT);
            name.ShouldBe("Picnic Day");
        }
    }
}
