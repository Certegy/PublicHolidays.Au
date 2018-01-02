using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class WesternAustraliaDayTests
    {
        private readonly WesternAustraliaDay _westernAustraliaDay;

        public WesternAustraliaDayTests()
        {
            _westernAustraliaDay = new WesternAustraliaDay();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _westernAustraliaDay.GetPublicHolidayDatesFor(Region.WA);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _westernAustraliaDay.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsDateOfSecondMondayInMarch()
        {
            const int year = 2017;
            var result = _westernAustraliaDay.In(year);
            result.ShouldContain(new DateTime(year, 6, 5));
        }


        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _westernAustraliaDay.GetNameOfPublicHolidayIn(Region.WA);
            name.ShouldBe("Western Australia Day");
        }
    }
}