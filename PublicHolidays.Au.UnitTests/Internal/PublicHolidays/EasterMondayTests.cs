using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class EasterMondayTests
    {
        private readonly EasterMonday _easterMonday;

        public EasterMondayTests()
        {
            _easterMonday = new EasterMonday();
        }


        [Fact]
        public void In_2017_ReturnsCorrectDate()
        {
            const int year = 2017;
            var result = _easterMonday.In(year);
            result.ShouldContain(new DateTime(year, 4, 17));
        }

        [Fact]
        public void In_2018_ReturnsCorrectDate()
        {
            const int year = 2018;
            var result = _easterMonday.In(year);
            result.ShouldContain(new DateTime(year, 4, 2));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _easterMonday.GetNameOfPublicHolidayIn(Region.ANZ);
            name.ShouldBe("Easter Monday");
        }
    }
}
