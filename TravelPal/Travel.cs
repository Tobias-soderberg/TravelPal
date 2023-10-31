using System.Collections.Generic;

namespace TravelPal
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Country { get; set; }
        public int Travellers { get; set; }
        public List<IPackingListItem> PackingList { get; set; }
        public User User { get; set; }

        public Travel(string destination, Country country, int travellers, List<IPackingListItem> packingList, User user)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
            PackingList = packingList;
            User = user;
        }

        public virtual string GetInfo()
        {
            return "";
        }
    }
}
