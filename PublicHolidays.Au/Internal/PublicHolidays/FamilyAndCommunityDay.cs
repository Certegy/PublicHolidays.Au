using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class FamilyAndCommunityDay : IPublicHoliday, IIn
    {
        public Region Regions => Region.ACT;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return "Family & Community Day";
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return Regions.HasFlag(region) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            // Cannot accurately calculate date of this public holiday.
            return new List<DateTime>();
        }
    }
}