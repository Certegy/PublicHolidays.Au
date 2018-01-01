using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Computus;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class GoodFriday : IPublicHoliday, IIn
    {
        private readonly IComputus _computus;

        public GoodFriday()
            : this(new DefaultComputus())
        {
        }

        public GoodFriday(IComputus computus)
        {
            _computus = computus;
        }

        public Region Regions => Region.ANZ;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(GoodFriday).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return new[] {_computus.GetCalendarDateOfEasterFor(year).AddDays(-2)};
        }
    }
}