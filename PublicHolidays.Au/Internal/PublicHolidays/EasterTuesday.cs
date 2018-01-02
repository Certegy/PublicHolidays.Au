using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class EasterTuesday : IPublicHoliday, IIn
    {
        private readonly IComputus _computus;

        public EasterTuesday()
            : this(new DefaultComputus())
        {
        }

        public EasterTuesday(IComputus computus)
        {
            _computus = computus;
        }

        public Region Regions => Region.TAS;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(EasterTuesday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] { _computus.GetCalendarDateOfEasterFor(year).AddDays(2) };
        }
    }
}