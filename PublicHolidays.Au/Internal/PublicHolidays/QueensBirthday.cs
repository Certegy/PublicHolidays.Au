using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.DateOfMonthCalculator;
using PublicHolidays.Au.Internal.Extensions;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class QueensBirthday : IPublicHoliday, IIn
    {
        private readonly IDateOfMonthCalculator _dateOfMonthCalculator;
        private Region region;

        public QueensBirthday()
            : this(new DefaultDateOfMonthCalculator())
        {
        }

        public QueensBirthday(IDateOfMonthCalculator dateOfMonthCalculator)
        {
            _dateOfMonthCalculator = dateOfMonthCalculator;
        }

        public Region Regions => Region.ANZ;
        public Trait Traits => Trait.MostPostcodes;

        public string GetNameOfPublicHolidayIn(Region region)
        {
            return region == Region.SA ? "Volunteer's Day" : "Queen's Birthday";
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
                    var firstMondayInOctober = _dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.October).For(year);
                    var lastDayOfSeptember = new DateTime(year, 9, 30);
                    dates.Add(!lastDayOfSeptember.IsWeekend()
                        ? firstMondayInOctober.AddDays(-7)
                        : firstMondayInOctober);
                    break;
                case Region.QLD:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.October).For(year));
                    break;
                case Region.ACT:
                case Region.NSW:
                case Region.NT:
                case Region.SA:
                case Region.TAS:
                case Region.VIC:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.Second, DayOfWeek.Monday).In(Month.June).For(year));
                    break;
                case Region.NZ:
                    dates.Add(_dateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.June).For(year));
                    break;
            }

            return dates;
        }
    }
}