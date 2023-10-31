using System;
using System.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow(IUser user)
        {
            InitializeComponent();

            txtUsername.Text = user.Username;
            txtPassword.Password = user.Password;

            cbCountry.Items.Add("----Choose Country----");
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(country);
            }
            cbCountry.SelectedIndex = (int)user.Location;

            txtChangeWarning.Visibility = Visibility.Hidden;


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            IUser user = UserManager.SignedInUser;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.ToString().Trim();
            if (ValidateChange(username, password))
            {
                user.Password = txtPassword.Password.ToString();
                user.Username = txtUsername.Text;
                user.Location = (Country)cbCountry.SelectedIndex;

                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                Close();
            }
            txtChangeWarning.Visibility = Visibility.Visible;

        }
        public bool ValidateChange(string username, string password)
        {
            if (username.Length > 2 && password.Length > 4 && cbCountry.SelectedIndex > 0)
            {
                if (UserManager.SignedInUser.Username == username)
                {
                    return true;
                }
                foreach (IUser user in UserManager.users)
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
    }
}
