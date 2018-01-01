using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class PicnicDay : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public PicnicDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public PicnicDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public Region Regions => Region.NT;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(PicnicDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.August).For(year)
            };
        }
    }
}