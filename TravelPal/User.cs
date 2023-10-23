using System.Collections.Generic;

namespace TravelPal
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public bool IsAdmin { get; } = false;
        public List<Travel> Travels { get; set; } = new();
    }
}
