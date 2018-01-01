using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.PublicHolidays;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au
{
    public sealed class PublicHolidayCalculator : IPublicHolidayCalculator
    {
        private readonly IEnumerable<IPublicHoliday> _publicHolidays;

        public PublicHolidayCalculator()
            : this(Internal.Helpers.PublicHolidays.Get.All)
        {
        }

        internal PublicHolidayCalculator(
            IEnumerable<IPublicHoliday> publicHolidays)
        {
            _publicHolidays = publicHolidays;
        }

        public IList<DateTime> GetPublicHolidaysFor(Region region, int year)
        {
            return
                _publicHolidays
                    .Where(_ =>
                        _.Regions.HasFlag(region) &&
                        !_.Traits.HasFlag(Trait.NotAllPostcodes) &&
                        !_.Traits.HasFlag(Trait.IndustrySpecific))
                    .SelectMany(_ => _.GetPublicHolidayDatesFor(region).In(year))
                    .ToList();
        }

        public bool IsPublicHoliday(DateTime date, Region region)
        {
            return GetPublicHolidaysFor(region, date.Year).Contains(date);
        }
    }
}