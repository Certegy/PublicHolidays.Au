using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class BoxingDayTests
    {
        private readonly BoxingDay _boxingDay;

        public BoxingDayTests()
        {
            _boxingDay = new BoxingDay();
        }

        [Fact]
        public void In_YearWhereProclamationDayIsOnSaturday_ReturnsDecember26thOfThatYear()
        {
            const int year = 2015;
            var result = _boxingDay.In(year);
            result.ShouldContain(new DateTime(year, 12, 28));
        }

        [Fact]
        public void In_YearWhereProclamationDayIsOnSunday_ReturnsTuesdayFollowingDecember26thOfThatYear()
        {
            const int year = 2021;
            var result = _boxingDay.In(year);
            result.ShouldContain(new DateTime(year, 12, 28));
        }

        [Fact]
        public void In_YearWhereProclamationDayIsOnMonday_ReturnsTuesdayFollowingDecember26thOfThatYear()
        {
            const int year = 2016;
            var result = _boxingDay.In(year);
            result.ShouldContain(new DateTime(year, 12, 27));
        }

        [Fact]
        public void In_YearWhereProclamationDayIsNotOnSaturdaySundayOrMonday_ReturnsDecember26thOfThatYear()
        {
            const int year = 2017;
            var result = _boxingDay.In(year);
            result.ShouldContain(new DateTime(year, 12, 26));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_SA_ReturnsCorrectName()
        {
            var name = _boxingDay.GetNameOfPublicHolidayIn(Region.SA);
            name.ShouldBe("Proclamation Day");
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_NotSA_ReturnsCorrectName()
        {
            var name = _boxingDay.GetNameOfPublicHolidayIn(Region.VIC);
            name.ShouldBe("Boxing Day");
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_NZ_ReturnsCorrectName()
        {
            var name = _boxingDay.GetNameOfPublicHolidayIn(Region.NZ);
            name.ShouldBe("Boxing Day");
        }
    }
}
