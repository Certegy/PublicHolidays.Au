using System.Collections.Generic;
using System.Linq;

namespace PublicHolidays.Au.UnitTests.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool ContainsAll<T>(this IEnumerable<T> value, IEnumerable<T> values)
        {
            var count = value.Intersect(values).Count();
            return count == value.Count() && count == values.Count();
        }
    }
}