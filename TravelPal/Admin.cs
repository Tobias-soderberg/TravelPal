namespace TravelPal
{
    internal class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public bool isAdmin { get; } = true;
    }
}
