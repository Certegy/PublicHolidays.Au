using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class EasterTuesdayTests
    {
        private readonly EasterTuesday _easterTuesday;

        public EasterTuesdayTests()
        {
            _easterTuesday = new EasterTuesday();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _easterTuesday.GetPublicHolidayDatesFor(Region.TAS);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _easterTuesday.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsCorrectDate()
        {
            const int year = 2017;
            var result = _easterTuesday.In(year);
            result.ShouldContain(new DateTime(year, 4, 18));
        }

        [Fact]
        public void In_2018_ReturnsCorrectDate()
        {
            const int year = 2018;
            var result = _easterTuesday.In(year);
            result.ShouldContain(new DateTime(year, 4, 3));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _easterTuesday.GetNameOfPublicHolidayIn(Region.TAS);
            name.ShouldBe("Easter Tuesday");
        }
    }
}