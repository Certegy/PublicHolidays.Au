using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.PublicHolidays;
using PublicHolidays.Au.Internal.Support;
using AuPublicHolidays = PublicHolidays.Au.Internal.Helpers.PublicHolidays;

namespace PublicHolidays.Au
{
    public sealed class BusinessDaysCalculator : IBusinessDaysCalculator, IStartingFromBusinessDaysCalculator
    {
        private readonly IEnumerable<IPublicHoliday> _publicHolidays;
        private DateTime _start;
        private Region? _region;

        public BusinessDaysCalculator()
            : this(AuPublicHolidays.Get.All)
        {
        }

        internal BusinessDaysCalculator(
            IEnumerable<IPublicHoliday> publicHolidays)
        {
            _publicHolidays = publicHolidays;
        }

        public IBusinessDaysCalculator In(Region region)
        {
            this._region = region;
            return this;
        }

        public IStartingFromBusinessDaysCalculator StartingFrom(DateTime startDate)
        {
            _start = startDate;
            return this;
        }

        public DateTime AddBusinessDays(int numberOfDays)
        {
            var state = _region ?? Region.AU;
            var excludedDates = GetExclusions(numberOfDays, state);

            return GetWorkDays(numberOfDays, excludedDates).Last();
        }

        private List<DateTime> GetExclusions(int days, Region region)
        {
            var years = Math.Ceiling(Math.Abs(days)/365M) + 1;

            var dates = new List<DateTime>();
            for (var i = 0; i < years; i++)
            {
                var year = _start.AddYears(i*Math.Sign(days)).Year;
                dates.AddRange(
                    _publicHolidays
                        .Where(_ => 
                            _.Regions.HasFlag(region) &&
                            !_.Traits.HasFlag(Trait.NotAllPostcodes) &&
                            !_.Traits.HasFlag(Trait.IndustrySpecific))
                        .SelectMany(_ => _.GetPublicHolidayDatesFor(region).In(year))
                        .ToList());
            }

            return dates;
        }

        private IEnumerable<DateTime> GetWorkDays(int numberOfDays, ICollection<DateTime> excludedDates)
        {
            var count = 0;
            var increment = 1 * Math.Sign(numberOfDays);
            if (increment == 0) increment = 1;
            var maxIterations = Math.Abs(numberOfDays) + 1;
            for (var day = _start;; day = day.AddDays(increment))
            {
                if (!day.IsWeekend() && !day.In(excludedDates.ToArray()))
                {
                    count++;
                    yield return day;
                }

                if (count >= maxIterations)
                {
                    yield break;
                }
            }
        }
    }
}