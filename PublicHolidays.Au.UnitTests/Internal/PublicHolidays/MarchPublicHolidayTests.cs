using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class MarchPublicHolidayTests
    {
        private readonly MarchPublicHoliday _marchPublicHoliday;

        public MarchPublicHolidayTests()
        {
            _marchPublicHoliday = new MarchPublicHoliday();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _marchPublicHoliday.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _marchPublicHoliday.GetPublicHolidayDatesFor(Region.NSW);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_After2019_ReturnsNull()
        {
            var result = _marchPublicHoliday.In(2020);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void In_Before2019_ReturnsDateOfSecondMondayInMarch()
        {
            const int year = 2017;
            var result = _marchPublicHoliday.In(year);
            result.ShouldContain(new DateTime(year, 3, 13));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _marchPublicHoliday.GetNameOfPublicHolidayIn(Region.SA);
            name.ShouldBe("March Public Holiday");
        }
    }
}