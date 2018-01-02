using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class MelbourneCupTests
    {
        private readonly MelbourneCup _melbourneCup;

        public MelbourneCupTests()
        {
            _melbourneCup = new MelbourneCup();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_MatchingState_DoesNotShortCircuit()
        {
            var result = _melbourneCup.GetPublicHolidayDatesFor(Region.VIC);
            result.ShouldNotBeOfType<ShortCircuit>();
        }

        [Fact]
        public void GetPublicHolidayDatesFor_NonMatchingState_ShortCircuits()
        {
            var result = _melbourneCup.GetPublicHolidayDatesFor(Region.SA);
            result.ShouldBeOfType<ShortCircuit>();
        }

        [Fact]
        public void In_2017_ReturnsDateOfFirstTuesdayInNovember()
        {
            const int year = 2017;
            var result = _melbourneCup.In(year);
            result.ShouldContain(new DateTime(year, 11, 7));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_Any_ReturnsCorrectName()
        {
            var name = _melbourneCup.GetNameOfPublicHolidayIn(Region.VIC);
            name.ShouldBe("Melbourne Cup");
        }
    }
}