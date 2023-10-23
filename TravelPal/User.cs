using System.Collections.Generic;

namespace TravelPal
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public bool isAdmin { get; } = false;
        public List<Travel> Travels { get; set; }
    }
}
