using System.Collections.Generic;

namespace TravelPal
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Country country, int travellers, List<IPackingListItem> packingList, string meetingDetails) : base(destination, country, travellers, packingList)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return base.GetInfo();
        }
    }
}
