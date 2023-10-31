using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInputs())
            {
                string destination = txtCity.Text;
                int travellers = int.Parse(txtTravelers.Text);
                Travel travel;

                if (cbWorkVacation.SelectedIndex == 0) //0 = Work
                {
                    travel = new WorkTrip(destination, (Country)cbCountry.SelectedIndex, travellers, packingList, (User)UserManager.SignedInUser, txtMeetingInfo.Text);
                    TravelManager.AddTravel(travel);
                }
                else if (cbWorkVacation.SelectedIndex == 1) //1 = Vacation
                {
                    travel = new Vacation(destination, (Country)cbCountry.SelectedIndex, travellers, packingList, (User)UserManager.SignedInUser, (bool)cboxAllInclusive.IsChecked!);
                    TravelManager.AddTravel(travel);
                }
                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                Close();
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
            if (IsValidAddInputs())
            {

            }
            ListViewItem item = new();
            lstPacking.Items.Add(item);
        }

        bool IsValidInputs()
        {
            string city = txtCity.Text.Trim();

            string travellersString = txtTravelers.Text.Trim();

            return (city.Length > 0 && int.TryParse(travellersString, out _) && cbCountry.SelectedIndex > 0 && cbWorkVacation.SelectedIndex != -1) ? true : false;
        }

        bool IsValidAddInputs()
        {
            string packItem = txtPackItem.Text.Trim();
            string quantityString = txtPackNumber.Text.Trim();
            bool required = (bool)cboxRequired.IsChecked!;
            bool travelDocument = (bool)cboxTravelDocument.IsChecked!;

            if (!string.IsNullOrEmpty(packItem))
            {
                if (travelDocument)
                {

                }
                else if (int.TryParse(quantityString, out int quantity))
                {

                }
            }

            return false;
        }
    }
}
