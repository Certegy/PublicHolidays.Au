using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class AustraliaDay : IPublicHoliday, IIn
    {
        public Region Regions => Region.AU;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return nameof(AustraliaDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            return
                new DateTime(year, 1, 26)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(1));
        }
    }
}