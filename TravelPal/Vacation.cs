using System.Collections.Generic;

namespace TravelPal
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, Country country, int travellers, List<IPackingListItem> packingList, User user, bool allInclusive) : base(destination, country, travellers, packingList, user)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            return $"All inclusive: {AllInclusive}";
        }
    }
}
