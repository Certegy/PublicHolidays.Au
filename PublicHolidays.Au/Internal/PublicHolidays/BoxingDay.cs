using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class BoxingDay : IPublicHoliday, IIn
    {
        public Region Regions => Region.ANZ;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return region == Region.SA ? "Proclamation Day" : nameof(BoxingDay).ToSentence();
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            return
                new DateTime(year, 12, 26)
                    .Shift(
                        saturday => saturday.AddDays(2),
                        sunday => sunday.AddDays(2),
                        monday => monday.AddDays(1));
        }
    }
}