using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class ChristmasDayTests
    {
        private readonly ChristmasDay _christmasDay;

        public ChristmasDayTests()
        {
            _christmasDay = new ChristmasDay();
        }

        [Fact]
        public void In_YearWhereChristmasDayIsNotOnWeekend_ReturnsDecember25thOfThatYear()
        {
            const int year = 2017;
            var result = _christmasDay.In(year);
            result.ShouldContain(new DateTime(year, 12, 25));
        }

        [Fact]
        public void In_YearWhereChristmasDayIsOnWeekend_ReturnsMondayFollowingDecember25thOfThatYear()
        {
            const int year = 2016;
            var result = _christmasDay.In(year);
            result.ShouldContain(new DateTime(year, 12, 26));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _christmasDay.GetNameOfPublicHolidayIn(Region.ANZ);
            name.ShouldBe("Christmas Day");
        }
    }
}
