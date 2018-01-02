using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Extensions;

namespace PublicHolidays.Au
{
    public sealed class BusinessDaysCalculator : IBusinessDaysCalculator, IStartingFromBusinessDaysCalculator
    {
        private IPublicHolidayCalculator _publicHolidayCalculator;
        private DateTime _start;
        private Region? _region;

        public BusinessDaysCalculator()
            : this(new PublicHolidayCalculator())
        {
        }

        internal BusinessDaysCalculator(
            IPublicHolidayCalculator publicHolidayCalculator)
        {
            _publicHolidayCalculator = publicHolidayCalculator;
        }

        public IBusinessDaysCalculator In(Region region)
        {
            _region = region;
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
                dates.AddRange(_publicHolidayCalculator.GetPublicHolidaysFor(region, year));
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