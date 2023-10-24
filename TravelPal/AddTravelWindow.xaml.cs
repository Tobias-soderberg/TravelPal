using System;
using System.Collections.Generic;
using System.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        List<IPackingListItem> packingList = new();
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

            txtAddTravelWarning.Visibility = Visibility.Hidden;
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

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInputs())
            {
                string destination = txtCity.Text;
                int travellers = int.Parse(txtTravelers.Text);

                if (cbWorkVacation.SelectedIndex == 0) //0 = Work
                {
                    Travel travel = new WorkTrip(destination, (Country)cbCountry.SelectedIndex, travellers, packingList, txtMeetingInfo.Text);
                }
                else if (cbWorkVacation.SelectedIndex == 1) //1 = Vacation
                {
                    Travel travel = new Vacation(destination, (Country)cbCountry.SelectedIndex, travellers, packingList, (bool)cboxAllInclusive.IsChecked!);
                }

                return;
            }
            txtAddTravelWarning.Visibility = Visibility.Visible;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstPacking.SelectedIndex == -1)
            {
                return;
            }
            lstPacking.Items.Remove(lstPacking.SelectedItem);

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {

        }

        bool IsValidInputs()
        {
            string city = txtCity.Text.Trim();

            string travellersString = txtTravelers.Text.Trim();

            return (city.Length > 0 && int.TryParse(travellersString, out _) && cbCountry.SelectedIndex > 0 && cbWorkVacation.SelectedIndex != -1) ? true : false;
        }
    }
}
