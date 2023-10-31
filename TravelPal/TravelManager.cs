using System.Collections.Generic;

namespace TravelPal
{
    public static class TravelManager
    {
        public static List<Travel> travels = new();

        public static void AddTravel(Travel travel)
        {
            if (travel != null)
            {
                travels.Add(travel);
                travel.User.Travels.Add(travel);
            }

        }
        public static void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);
        }
    }
}
