using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class LabourDay : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;
        private Region region;

        public LabourDay()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public LabourDay(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public Region Regions => Region.ANZ;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            switch (region)
            {
                case Region.NT:
                    return "May Day";
                case Region.TAS:
                    return "Eight Hours Day";
                default:
                    return nameof(LabourDay).ToSentence();
            }
        }

        public IIn GetPublicHolidayDatesFor(Region region)
        {
            this.region = region;
            return this;
        }

        public IEnumerable<DateTime> In(int year)
        {
            var dates = new List<DateTime>();

            switch (region)
            {
                case Region.WA:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.March).For(year));
                    break;
                case Region.TAS:
                case Region.VIC:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.Second, DayOfWeek.Monday).In(Month.March).For(year));
                    break;
                case Region.QLD:
                case Region.NT:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.May).For(year));
                    break;
                case Region.NSW:
                case Region.ACT:
                case Region.SA:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.October).For(year));
                    break;
                case Region.NZ:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.Fourth, DayOfWeek.Monday).In(Month.October).For(year));
                    break;
            }

            return dates;
        }
    }
}