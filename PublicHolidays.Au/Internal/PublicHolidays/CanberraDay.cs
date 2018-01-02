using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class CanberraDay : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;

        public CanberraDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public CanberraDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public Region Regions => Region.ACT;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(CanberraDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new List<DateTime>
            {
                _dateOfMonthCalculator.Find(Ordinal.Second, DayOfWeek.Monday).In(Month.March).For(year)
            };
        }
    }
}