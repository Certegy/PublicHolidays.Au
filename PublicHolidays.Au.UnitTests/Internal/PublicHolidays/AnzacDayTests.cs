using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class AnzacDayTests
    {
        private readonly AnzacDay _anzacDay;

        public AnzacDayTests()
        {
            _anzacDay = new AnzacDay();
        }

        [Fact]
        public void In_YearWhereAnzacDayIsNotOnWeekend_ReturnsApril25thOfThatYear()
        {
            const int year = 2018;
            var result = _anzacDay.In(year);
            result.ShouldContain(new DateTime(year, 4, 25));
        }

        [Fact]
        public void In_YearWhereAnzacDayIsOnASaturday_ReturnsApril25thOfThatYear()
        {
            const int year = 2020;
            var result = _anzacDay.In(year);
            result.ShouldContain(new DateTime(year, 4, 25));
        }

        [Fact]
        public void In_YearWhereAnzacDayIsOnASunday_ReturnsMondayFollowingApril25thOfThatYear()
        {
            const int year = 2021;
            var result = _anzacDay.In(year);
            result.ShouldContain(new DateTime(year, 4, 26));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _anzacDay.GetNameOfPublicHolidayIn(Region.ANZ);
            name.ShouldBe("Anzac Day");
        }
    }
}
