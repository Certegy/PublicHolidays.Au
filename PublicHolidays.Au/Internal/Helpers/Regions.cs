using System;
using System.Collections.Generic;

namespace PublicHolidays.Au.Internal.Helpers
{
    internal sealed class Regions
    {
        private static readonly Lazy<Regions> Instance = new Lazy<Regions>(() => new Regions());

        private readonly IDictionary<string, Region> _regions;

        private Regions()
        {
            _regions = new Dictionary<string, Region>();
            foreach (Region region in Enum.GetValues(typeof(Region)))
            {
                _regions.Add(region.ToString(), region);
            }
        }

        public static Regions Get => Instance.Value;
        public IDictionary<string, Region> All => _regions;
    }
}