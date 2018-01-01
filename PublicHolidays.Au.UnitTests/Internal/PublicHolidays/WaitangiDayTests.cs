using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using System;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class WaitangiDayTests
    {
        private readonly WaitangiDay _waitangiDay;

        public WaitangiDayTests()
        {
            _waitangiDay = new WaitangiDay();
        }

        [Fact]
        public void In_YearWhereWaitangiDayIsNotOnWeekend_ReturnsFeb6thOfThatYear()
        {
            const int year = 2018;
            var result = _waitangiDay.In(year);
            result.ShouldContain(new DateTime(year, 2, 6));
        }

        [Fact]
        public void In_YearWhereWaitangiDayIsOnASaturday_ReturnsMondayFollowingFeb6thOfThatYear()
        {
            const int year = 2021;
            var result = _waitangiDay.In(year);
            result.ShouldContain(new DateTime(year, 2, 8));
        }

        [Fact]
        public void In_YearWhereWaitangiDayIsOnASunday_ReturnsMondayFollowingFeb6thOfThatYear()
        {
            const int year = 2022;
            var result = _waitangiDay.In(year);
            result.ShouldContain(new DateTime(year, 2, 7));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _waitangiDay.GetNameOfPublicHolidayIn(Region.NZ);
            name.ShouldBe("Waitangi Day");
        }
    }
}
