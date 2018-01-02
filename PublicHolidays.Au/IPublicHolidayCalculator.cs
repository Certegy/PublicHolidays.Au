using System;
using System.Collections.Generic;

namespace PublicHolidays.Au
{
    public interface IPublicHolidayCalculator
    {
        IList<DateTime> GetPublicHolidaysFor(Region region, int year);
        bool IsPublicHoliday(DateTime value, Region region);
    }
}