using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Support;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class DayAfterNewYearsDay : IPublicHoliday, IIn
    {
        public Region Regions => Region.NZ;

        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(DayAfterNewYearsDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return
                new DateTime(year, 1, 2)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(2),
                        monday => monday.AddDays(1));
        }
    }
}
