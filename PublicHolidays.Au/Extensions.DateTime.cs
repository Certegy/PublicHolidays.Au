using System;
using System.Collections.Generic;
using System.Linq;
using AuPublicHolidays = PublicHolidays.Au.Internal.Helpers.PublicHolidays;

namespace PublicHolidays.Au
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<KeyValuePair<string, IEnumerable<DateTime>>> GetPublicHolidaysFor(this Region region, int year)
        {
            var publicHolidays =
                AuPublicHolidays.Get.All
                    .Where(_ => _.Regions.HasFlag(region))
                    .Select(_ => new KeyValuePair<string, IEnumerable<DateTime>>(_.GetNameOfPublicHolidayIn(region), _.GetPublicHolidayDatesFor(region).In(year)));
            
            return publicHolidays;
        }

        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays)
        {
            return value.AddBusinessDays(numberOfDays, Region.AU);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays, Region region)
        {
            var businessDaysCalculator = new BusinessDaysCalculator();
            var dateTime = businessDaysCalculator.In(region).StartingFrom(value).AddBusinessDays(numberOfDays);

            return dateTime;
        }
    }
}