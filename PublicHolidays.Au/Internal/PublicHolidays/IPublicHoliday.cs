using System;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public interface IPublicHoliday
    {
        Region Regions { get; }
        Trait Traits { get; }
        string GetNameOfPublicHolidayIn(Region region);
        IIn GetPublicHolidayDatesFor(Region region);
    }
}