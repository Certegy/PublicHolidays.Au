using System;
using System.Collections.Generic;
using PublicHolidays.Au.UnitTests.Extensions;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests
{
    public class PublicHolidayCalculatorTests
    {
        private PublicHolidayCalculator _sut;

        public PublicHolidayCalculatorTests()
        {
            _sut = new PublicHolidayCalculator();
        }

        [Fact]
        public void GetPublicHolidaysFor_NZIn2018_ReturnsCorrectDates()
        {
            var publicHolidays = _sut.GetPublicHolidaysFor(Region.NZ, 2018);
            var containsAll =
                publicHolidays.ContainsAll(
                    new List<DateTime>()
                    {
                        new DateTime(2018, 1, 1),
                        new DateTime(2018, 1, 2),
                        new DateTime(2018, 2, 6),
                        new DateTime(2018, 3, 30),
                        new DateTime(2018, 4, 2),
                        new DateTime(2018, 4, 25),
                        new DateTime(2018, 6, 4),
                        new DateTime(2018, 10, 22),
                        new DateTime(2018, 12, 25),
                        new DateTime(2018, 12, 26)
                    });

            containsAll.ShouldBe(true);
        }

        [Fact]
        public void GetPublicHolidaysFor_SAIn2018_ReturnsCorrectDates()
        {
            var publicHolidays = _sut.GetPublicHolidaysFor(Region.SA, 2018);
            var containsAll =
                publicHolidays.ContainsAll(
                    new List<DateTime>()
                    {
                        new DateTime(2018, 1, 1),
                        new DateTime(2018, 1, 26),
                        new DateTime(2018, 3, 12),
                        new DateTime(2018, 3, 30),
                        new DateTime(2018, 3, 31),
                        new DateTime(2018, 4, 2),
                        new DateTime(2018, 4, 25),
                        new DateTime(2018, 6, 11),
                        new DateTime(2018, 10, 1),
                        new DateTime(2018, 12, 25),
                        new DateTime(2018, 12, 26)
                    });

            containsAll.ShouldBe(true);
        }
    }
}
