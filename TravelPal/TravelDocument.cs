﻿namespace TravelPal
{
    internal class TravelDocument : IPackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }

        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;

        }

        public string GetInfo()
        {
            return $"{Name}, Required: {Required}";
        }
    }
}
