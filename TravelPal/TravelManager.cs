using System.Collections.Generic;

namespace TravelPal
{
    public static class TravelManager
    {
        public static List<Travel> travels = new();

        public static void AddTravel(Travel travel)
        {
            travels.Add(travel);
        }
        public static void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);
        }
    }
}
