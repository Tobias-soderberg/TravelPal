using System;
using System.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();

            cbCountry.Items.Add("-Choose Country-");
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(country);
            }
            cbCountry.SelectedIndex = 0;

            cbWorkVacation.Items.Add("Work");
            cbWorkVacation.Items.Add("Vacation");
        }

        private void cboxTravelDocument_Checked(object sender, RoutedEventArgs e)
        {
            lblQuantity.Visibility = Visibility.Hidden;
            txtPackNumber.Visibility = Visibility.Hidden;
            cboxRequired.Visibility = Visibility.Visible;

        }

        private void cboxTravelDocument_Unchecked(object sender, RoutedEventArgs e)
        {
            lblQuantity.Visibility = Visibility.Visible;
            txtPackNumber.Visibility = Visibility.Visible;
            cboxRequired.Visibility = Visibility.Hidden;
        }

        private void cbWorkVacation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbWorkVacation.SelectedItem.ToString() == "Work")
            {
                txtMeetingInfo.Visibility = Visibility.Visible;
                cboxAllInclusive.Visibility = Visibility.Hidden;
                lblWorkDetails.Visibility = Visibility.Visible;
            }
            else if (cbWorkVacation.SelectedItem.ToString() == "Vacation")
            {
                txtMeetingInfo.Visibility = Visibility.Hidden;
                cboxAllInclusive.Visibility = Visibility.Visible;
                lblWorkDetails.Visibility = Visibility.Hidden;
            }
            else
            {
                txtMeetingInfo.Visibility = Visibility.Hidden;
                cboxAllInclusive.Visibility = Visibility.Hidden;
                lblWorkDetails.Visibility = Visibility.Hidden;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow(UserManager.SignedInUser);
            travelsWindow.Show();
            Close();
        }
    }
}
