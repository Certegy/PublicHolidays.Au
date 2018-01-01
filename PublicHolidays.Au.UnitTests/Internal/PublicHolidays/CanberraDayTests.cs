using System;
using NSubstitute;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class CanberraDayTests
    {
        private readonly CanberraDay _canberraDay;

        public CanberraDayTests()
        {
            _canberraDay = new CanberraDay();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _canberraDay.GetPublicHolidayDatesFor(Region.ACT);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _canberraDay.GetPublicHolidayDatesFor(Region.NSW);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsDateOfSecondMondayInMarch()
        {
            const int year = 2017;
            var result = _canberraDay.In(year);
            result.ShouldContain(new DateTime(year, 3, 13));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _canberraDay.GetNameOfPublicHolidayIn(Region.AU);
            name.ShouldBe("Canberra Day");
        }
    }
}
