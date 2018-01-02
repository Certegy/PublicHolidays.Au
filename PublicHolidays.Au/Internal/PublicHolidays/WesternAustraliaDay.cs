using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class WesternAustraliaDay : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public WesternAustraliaDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public WesternAustraliaDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public Region Regions => Region.WA;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(WesternAustraliaDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.June).For(year)
            };
        }
    }
}