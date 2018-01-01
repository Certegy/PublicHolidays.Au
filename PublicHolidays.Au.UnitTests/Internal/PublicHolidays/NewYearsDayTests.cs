using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class NewYearsDayTests
    {
        private readonly NewYearsDay _newYearsDay;

        public NewYearsDayTests()
        {
            _newYearsDay = new NewYearsDay();
        }

        [Fact]
        public void In_YearWhereNewYearsDayIsNotOnWeekend_ReturnsJanurary1stOfThatYear()
        {
            const int year = 2018;
            var result = _newYearsDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 1));
        }

        [Fact]
        public void In_YearWhereNewYearsDayIsOnWeekend_ReturnsMondayFollowingJanurary1stOfThatYear()
        {
            const int year = 2017;
            var result = _newYearsDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 2));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _newYearsDay.GetNameOfPublicHolidayIn(Region.ANZ);
            name.ShouldBe("New Years Day");
        }
    }
}
