using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class ChristmasDay : IPublicHoliday, IIn
    {
        public Region Regions => Region.ANZ;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(ChristmasDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return
                new DateTime(year, 12, 25)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(1));
        }
    }
}