using System.Collections.Generic;

namespace TravelPal
{
    public static class UserManager
    {
        public static List<IUser> users = new();
        public static IUser SignedInUser { get; set; }

        public static bool AddUser(IUser user)
        {
            if (ValidateUsername(user.Username))
            {
                users.Add(user);
                return true;
            }
            return false;
        }

        public static void RemoveUser(IUser user) // Dont know why this is needed??
        {
            users.Remove(user);
        }

        public static bool UpdateUsername(IUser user, string newUsername)
        {
            if (!ValidateUsername(newUsername))
            {
                user.Username = newUsername;
                return true;
            }
            return false;

        }

        static bool ValidateUsername(string username)
        {
            username = username.Trim();
            if (!string.IsNullOrEmpty(username) && username.Length > 2)
            {
                foreach (IUser user in users)
                {
                    if (user.Username == username)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
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

        public static void initiateUsers()
        {
            Travel tempTravel1 = new Vacation("Porto", Country.PORTUGAL, 1, new List<IPackingListItem>
                        {
                            new TravelDocument("Passport", false),
                            new OtherItem("Swimsuit", 1),
                            new OtherItem("Hoodie",10),
                            new OtherItem("Sunglasses", 1),
                            new OtherItem("Umbrella", 2)
                        }, true);
            TravelManager.travels.Add(tempTravel1);
            Travel tempTravel2 = new WorkTrip("Copenhagen", Country.DENMARK, 2, new List<IPackingListItem>
                    {
                            new TravelDocument("Passport", false),
                            new OtherItem("Jacket", 2),
                            new OtherItem("Pair of Gloves",2),
                            new OtherItem("Favorite snacks", 10),
                            new OtherItem("Party hat", 25)

                    }, "Work christmas party, all will gather in Copenhagen, +1 in invitaton");
            TravelManager.travels.Add(tempTravel2);



            users.Add(new Admin()
            {
                Username = "admin",
                Password = "password",
                Location = Country.SWEDEN,
            });

            users.Add(new User()
            {
                Username = "user",
                Password = "password",
                Location = Country.DENMARK,
                Travels = new List<Travel>()
                {
                    tempTravel1,
                    tempTravel2
                }
            });
        }

    }
}
