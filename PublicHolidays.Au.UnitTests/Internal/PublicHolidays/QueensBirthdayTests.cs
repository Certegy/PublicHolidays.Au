using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class QueensBirthdayTests
    {
        const int Year = 2017;
        private readonly QueensBirthday _queensBirthday;

        public QueensBirthdayTests()
        {
            _queensBirthday = new QueensBirthday();
        }

        [Fact]
        public void InWA_YearWhereLastDayOfSeptemberIsOnWeekend_ReturnsDateOfFirstMondayInOctober()
        {
            var year = 2018;
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.WA).In(year);
            result.ShouldContain(new DateTime(year, 10, 1));
        }

        [Fact]
        public void InWA_YearWhereLastDayOfSeptemberIsNotOnWeekend_ReturnsDateOfLastMondayInSeptember()
        {
            var year = 2016;
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.WA).In(year);
            result.ShouldContain(new DateTime(year, 9, 26));
        }

        [Fact]
        public void InQLD_2017_ReturnsDateOfFirstMondayInOctober()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.QLD).In(Year);
            result.ShouldContain(new DateTime(Year, 10, 2));
        }

        [Fact]
        public void InACT_2017_ReturnsDateOfSecondMondayInJune()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.ACT).In(Year);
            result.ShouldContain(new DateTime(Year, 6, 12));
        }

        [Fact]
        public void InNSW_2017_ReturnsDateOfSecondMondayInJune()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.NSW).In(Year);
            result.ShouldContain(new DateTime(Year, 6, 12));
        }

        [Fact]
        public void InNT_2017_ReturnsDateOfSecondMondayInJune()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.NT).In(Year);
            result.ShouldContain(new DateTime(Year, 6, 12));
        }

        [Fact]
        public void InSA_2017_ReturnsDateOfSecondMondayInJune()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.SA).In(Year);
            result.ShouldContain(new DateTime(Year, 6, 12));
        }

        [Fact]
        public void InTAS_2017_ReturnsDateOfSecondMondayInJune()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.TAS).In(Year);
            result.ShouldContain(new DateTime(Year, 6, 12));
        }

        [Fact]
        public void InVIC_2017_ReturnsDateOfSecondMondayInJune()
        {
            var result = _queensBirthday.GetPublicHolidayDatesFor(Region.VIC).In(Year);
            result.ShouldContain(new DateTime(Year, 6, 12));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_SA_ReturnsCorrectName()
        {
            var name = _queensBirthday.GetNameOfPublicHolidayIn(Region.SA);
            name.ShouldBe("Volunteer's Day");
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_NotSA_ReturnsCorrectName()
        {
            var name = _queensBirthday.GetNameOfPublicHolidayIn(Region.AU);
            name.ShouldBe("Queen's Birthday");
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_NZ_ReturnsCorrectName()
        {
            var name = _queensBirthday.GetNameOfPublicHolidayIn(Region.NZ);
            name.ShouldBe("Queen's Birthday");
        }
    }
}