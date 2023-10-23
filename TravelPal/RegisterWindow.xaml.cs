using System;
using System.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            cbCountry.Items.Add("----Choose Country----");
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(country);
            }
            cbCountry.SelectedIndex = 0;
            txtRegisterWarning.Visibility = Visibility.Hidden; //Added to still see it in window view
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.ToString().Trim();

            if (ValidateRegistration(username, password))
            {
                Country country = (Country)cbCountry.SelectedIndex; //Using the index to get correct country from the list, Could do with ComboBox Item, but feels like this is a valid and effective use of Enums
                UserManager.AddUser(new User()
                {
                    Username = username,
                    Password = password,
                    Location = country
                });
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            txtRegisterWarning.Visibility = Visibility.Visible;
        }

        public bool ValidateRegistration(string username, string password)
        {
            if (username.Length > 2 && password.Length > 4 && cbCountry.SelectedIndex > 0)
            {
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
