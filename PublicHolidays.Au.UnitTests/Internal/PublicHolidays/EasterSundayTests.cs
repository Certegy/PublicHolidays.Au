using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class EasterSundayTests
    {
        private readonly EasterSunday _easterSunday;

        public EasterSundayTests()
        {
            _easterSunday = new EasterSunday();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _easterSunday.GetPublicHolidayDatesFor(Region.NSW);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _easterSunday.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsCorrectDate()
        {
            const int year = 2017;
            var result = _easterSunday.In(year);
            result.ShouldContain(new DateTime(year, 4, 16));
        }

        [Fact]
        public void In_2018_ReturnsCorrectDate()
        {
            const int year = 2018;
            var result = _easterSunday.In(year);
            result.ShouldContain(new DateTime(year, 4, 1));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _easterSunday.GetNameOfPublicHolidayIn(Region.AU);
            name.ShouldBe("Easter Sunday");
        }
    }
}