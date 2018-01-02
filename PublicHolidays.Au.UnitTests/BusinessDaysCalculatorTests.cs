using System;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests
{
    public class BusinessDaysCalculatorTests
    {
        private readonly BusinessDaysCalculator _businessDaysCalculator;

        public BusinessDaysCalculatorTests()
        {
            _businessDaysCalculator = new BusinessDaysCalculator();
        }

        [Fact]
        public void AddBusinessDays_RangeThatDoesntGoOverWeekend_ReturnsExactNumberOfDaysAfterStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2016, 10, 31)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2016, 11, 3));
        }

        [Fact]
        public void AddBusinessDays_RangeThatGoesOverWeekend_ReturnsNumberOfBusinessDaysAfterStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2016, 10, 28)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2016, 11, 2));
        }

        [Fact]
        public void AddBusinessDays_RangeThatGoesOverWeekendAndIncludesPublicHoliday_ReturnsNumberOfBusinessDaysIncludingPublicHolidayAfterStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2018, 1, 24)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2018, 1, 30));
        }

        [Fact]
        public void AddBusinessDays_RangeThatDoesNotGoOverWeekendButIncludesPublicHoliday_ReturnsNumberOfDaysIncludingPublicHolidayAfterStartDate()
        {
            var dateTime = _businessDaysCalculator.In(Region.VIC).StartingFrom(new DateTime(2018, 11, 5)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2018, 11, 9));
        }

        [Fact]
        public void AddBusinessDays_RangeThatIncludesPublicHolidayFromDifferentState_ReturnsExactNumberOfDaysAfterStartDate()
        {
            var dateTime = _businessDaysCalculator.In(Region.SA).StartingFrom(new DateTime(2018, 11, 5)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2018, 11, 8));
        }

        [Fact]
        public void AddBusinessDays_RangeThatGoesOverWeekendAndIncludesBackToBackPublicHolidays_ReturnsNumberOfBusinessDaysIncludingPublicHolidaysAfterStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2016, 12, 23)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2016, 12, 30));
        }

        [Fact]
        public void AddBusinessDays_LastBusinessDayOfTheYear_ReturnsNumberOfBusinessDaysAfterStartDateIncludingNewYearsDayForNextYear()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2016, 12, 30)).AddBusinessDays(3);
            dateTime.ShouldBe(new DateTime(2017, 1, 5));
        }

        [Fact]
        public void AddBusinessDays_NegativeRangeThatDoesntGoOverWeekend_ReturnsExactNumberOfDaysBeforeStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2016, 11, 3)).AddBusinessDays(-3);
            dateTime.ShouldBe(new DateTime(2016, 10, 31));
        }

        [Fact]
        public void AddBusinessDays_NegativeRangeThatGoesOverWeekend_ReturnsNumberOfBusinessDaysBeforeStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2016, 11, 2)).AddBusinessDays(-3);
            dateTime.ShouldBe(new DateTime(2016, 10, 28));
        }

        [Fact]
        public void AddBusinessDays_NegativeRangeThatGoesOverWeekendAndIncludesPublicHoliday_ReturnsNumberOfBusinessDaysIncludingPublicHolidayBeforeStartDate()
        {
            var dateTime = _businessDaysCalculator.StartingFrom(new DateTime(2018, 1, 30)).AddBusinessDays(-3);
            dateTime.ShouldBe(new DateTime(2018, 1, 24));
        }

        [Fact]
        public void Test()
        {
            var addBusinessDays = DateTime.Today.AddBusinessDays(2);
            addBusinessDays.ShouldBeGreaterThan(DateTime.Today);
        }
    }
}
