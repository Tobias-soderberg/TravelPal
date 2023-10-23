namespace TravelPal
{
    internal interface IPackingListItem
    {
        public string Name { get; set; }

        public string GetInfo();
    }
}
