using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class EasterSaturday : IPublicHoliday, IIn
    {
        private readonly IComputus _computus;

        public EasterSaturday()
            : this(new DefaultComputus())
        {
        }

        public EasterSaturday(IComputus computus)
        {
            _computus = computus;
        }

        public Region Regions => Region.ACT | Region.NSW | Region.NT | Region.QLD | Region.SA | Region.VIC;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(EasterSaturday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(-1) };
        }
    }
}