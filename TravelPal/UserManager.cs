using System.Collections.Generic;

namespace TravelPal
{
    public static class UserManager
    {
        public static List<IUser> users = new();
        public static IUser SignedInUser { get; set; }

        public static void AddUser()
        {

        }

        public static void RemoveUser()
        {

        }

        public static bool UpdateUsername(IUser user, string newUsername)
        {
            return true;
        }

        static bool ValidateUsername(string username)
        {
            return true;
        }
        public static bool SignInUser(string username, string password, out IUser? signedInUser)
        {
            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    SignedInUser = user;
                    signedInUser = user;
                    return true;
                }
            }
            signedInUser = null;
            return false;
        }
    }
}
