using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class AustraliaDayTests
    {
        private readonly AustraliaDay _australiaDay;

        public AustraliaDayTests()
        {
            _australiaDay = new AustraliaDay();
        }

        [Fact]
        public void In_YearWhereAustraliaDayIsNotOnWeekend_ReturnsJanurary26thOfThatYear()
        {
            const int year = 2017;
            var result = _australiaDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 26));
        }

        [Fact]
        public void In_YearWhereAustraliaDayIsOnWeekend_ReturnsMondayFollowingJanurary26thOfThatYear()
        {
            const int year = 2019;
            var result = _australiaDay.In(year);
            result.ShouldContain(new DateTime(year, 1, 28));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _australiaDay.GetNameOfPublicHolidayIn(Region.AU);
            name.ShouldBe("Australia Day");
        }
    }
}
