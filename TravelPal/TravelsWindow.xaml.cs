using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow(IUser user)
        {
            InitializeComponent();

            AddTravels();

        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();

            addTravelWindow.Show();

            Close();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow();
            userDetailsWindow.Show();
            Close();
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        void AddTravels()
        {
            if (UserManager.SignedInUser.GetType() == typeof(Admin))
            {
                AddTravelsToList(TravelManager.travels);
            }
            else if (UserManager.SignedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.SignedInUser;
                AddTravelsToList(user.Travels);
            }
        }

        void AddTravelsToList(List<Travel> travels)
        {
            foreach (Travel travel in travels)
            {
                ListViewItem item = new();
                item.Tag = travel;
                item.Content = travel.Destination + ", " + travel.Country;
                lstTravels.Items.Add(item);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstTravels.SelectedItem == null)
            {
                MessageBox.Show("No travel selected!");
                return;
            }
            ListViewItem item = (ListViewItem)lstTravels.SelectedItem;
            TravelManager.travels.Remove((Travel)item.Tag);
            lstTravels.Items.Remove(item);
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (lstTravels.SelectedItem == null)
            {
                MessageBox.Show("No travel selected!");
                return;
            }

        }
    }
}
