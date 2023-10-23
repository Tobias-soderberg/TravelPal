using System.Collections.Generic;

namespace TravelPal
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, Country country, int travellers, List<IPackingListItem> packingList, bool allInclusive) : base(destination, country, travellers, packingList)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            return base.GetInfo();
        }
    }
}
