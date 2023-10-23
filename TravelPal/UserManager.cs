using System.Collections.Generic;

namespace TravelPal
{
    public class UserManager
    {
        public static List<IUser> users = new();
        public IUser SignedInUser { get; set; }

        public void AddUser()
        {

        }

        public void RemoveUser()
        {

        }

        public bool UpdateUsername(IUser user, string newUsername)
        {
            return true;
        }

        bool ValidateUsername(string username)
        {
            return true;
        }
        public bool SignInUser(string username, string password)
        {
            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    SignedInUser = user;
                    return true;
                }
            }

            return false;
        }
    }
}
