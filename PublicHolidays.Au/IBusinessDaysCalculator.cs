using System;

namespace PublicHolidays.Au
{
    public interface IBusinessDaysCalculator
    {
        IBusinessDaysCalculator In(Region region);
        IStartingFromBusinessDaysCalculator StartingFrom(DateTime startDate);
    }
}
