using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class EasterSaturdayTests
    {
        private readonly EasterSaturday _easterSaturday;

        public EasterSaturdayTests()
        {
            _easterSaturday = new EasterSaturday();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _easterSaturday.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _easterSaturday.GetPublicHolidayDatesFor(Region.TAS);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsCorrectDate()
        {
            const int year = 2017;
            var result = _easterSaturday.In(year);
            result.ShouldContain(new DateTime(year, 4, 15));
        }

        [Fact]
        public void In_2018_ReturnsCorrectDate()
        {
            const int year = 2018;
            var result = _easterSaturday.In(year);
            result.ShouldContain(new DateTime(year, 3, 31));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _easterSaturday.GetNameOfPublicHolidayIn(Region.AU);
            name.ShouldBe("Easter Saturday");
        }
    }
}