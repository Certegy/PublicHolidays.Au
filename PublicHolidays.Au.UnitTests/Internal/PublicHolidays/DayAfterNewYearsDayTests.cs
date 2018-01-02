using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using System;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class DayAfterNewYearsDayTests
    {
        private readonly DayAfterNewYearsDay _dayAfterNewYearsDay;

        public DayAfterNewYearsDayTests()
        {
            _dayAfterNewYearsDay = new DayAfterNewYearsDay();
        }

        [Fact]
        public void In_YearWhereDayAfterNewYearsDayIsNotOnWeekend_ReturnsJan2ndOfThatYear()
        {
            const int year = 2018;
            var result = _dayAfterNewYearsDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 2));
        }

        [Fact]
        public void In_YearWhereDayAfterNewYearsDayIsOnASaturday_ReturnsMondayFollowingJan2ndOfThatYear()
        {
            const int year = 2021;
            var result = _dayAfterNewYearsDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 4));
        }

        [Fact]
        public void In_YearWhereDayAfterNewYearsDayIsOnASunday_ReturnsTuesdayFollowingJan2ndOfThatYear()
        {
            const int year = 2022;
            var result = _dayAfterNewYearsDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 4));
        }

        [Fact]
        public void In_YearWhereDayAfterNewYearsDayIsOnAMonday_ReturnsTuesdayFollowingJan2ndOfThatYear()
        {
            const int year = 2017;
            var result = _dayAfterNewYearsDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 3));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _dayAfterNewYearsDay.GetNameOfPublicHolidayIn(Region.NZ);
            name.ShouldBe("Day After New Years Day");
        }
    }
}
