using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class EasterSunday : IPublicHoliday, IIn
    {
        private readonly IComputus _computus;

        public EasterSunday()
            : this(new DefaultComputus())
        {
        }

        public EasterSunday(IComputus computus)
        {
            _computus = computus;
        }

        public Region Regions => Region.ACT | Region.NSW | Region.VIC;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(EasterSunday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] {_computus.GetCalendarDateOfEasterFor(year)};
        }
    }
}