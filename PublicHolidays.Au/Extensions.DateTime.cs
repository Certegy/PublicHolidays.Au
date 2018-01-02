using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Helpers;
using AuPublicHolidays = PublicHolidays.Au.Internal.Helpers.PublicHolidays;

namespace PublicHolidays.Au
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<KeyValuePair<string, IEnumerable<DateTime>>> GetPublicHolidaysFor(this string region, int year)
        {
            return Regions.Get.All.Single(_ => _.Key.ToLower() == region.ToLower()).Value.GetPublicHolidaysFor(year);
        }

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

        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays, string region)
        {
            return value.AddBusinessDays(numberOfDays, Regions.Get.All.Single(_ => _.Key.ToLower() == region.ToLower()).Value);
        }

        public static DateTime AddBusinessDays(this DateTime value, int numberOfDays, Region region)
        {
            var businessDaysCalculator = new BusinessDaysCalculator();
            var dateTime = businessDaysCalculator.In(region).StartingFrom(value).AddBusinessDays(numberOfDays);

            return dateTime;
        }

        public static bool IsPublicHoliday(this DateTime value, string region)
        {
            return value.IsPublicHoliday(Regions.Get.All.Single(_ => _.Key.ToLower() == region.ToLower()).Value);
        }

        public static bool IsPublicHoliday(this DateTime value, Region region)
        {
            var publicHolidayCalculator = new PublicHolidayCalculator();
            return publicHolidayCalculator.IsPublicHoliday(value, region);
        }

        public static bool IsWeekendOrPublicHoliday(this DateTime value, string region)
        {
            return value.IsWeekendOrPublicHoliday(Regions.Get.All.Single(_ => _.Key.ToLower() == region.ToLower()).Value);
        }

        public static bool IsWeekendOrPublicHoliday(this DateTime value, Region region)
        {
            var dayOfWeek = value.DayOfWeek;
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday || value.IsPublicHoliday(region);
        }
    }
}