using System;
using System.Collections.Generic;
using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    public sealed class FamilyAndCommunityDay : IPublicHoliday, IIn
    {
        public State States => State.ACT;
        public Trait Traits => Trait.AllPostcodes;

        public string GetNameOfPublicHolidayIn(State state)
        {
            return "Family & Community Day";
        }

        public IIn GetPublicHolidayDatesFor(State state)
        {
            return States.HasFlag(state) ? this : ShortCircuit.Response();
        }

        public IEnumerable<DateTime> In(int year)
        {
            // Cannot accurately calculate date of this public holiday.
            return new List<DateTime>();
        }
    }
}