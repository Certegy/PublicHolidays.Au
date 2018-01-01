using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class GoodFridayTests
    {
        private readonly GoodFriday _goodFriday;

        public GoodFridayTests()
        {
            _goodFriday = new GoodFriday();
        }

        [Fact]
        public void In_2017_ReturnsCorrectDate()
        {
            const int year = 2017;
            var result = _goodFriday.In(year);
            result.ShouldContain(new DateTime(year, 4, 14));
        }

        [Fact]
        public void In_2018_ReturnsCorrectDate()
        {
            const int year = 2018;
            var result = _goodFriday.In(year);
            result.ShouldContain(new DateTime(year, 3, 30));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _goodFriday.GetNameOfPublicHolidayIn(Region.ANZ);
            name.ShouldBe("Good Friday");
        }
    }
}
