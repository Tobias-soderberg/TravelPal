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

            bool userInEU = Enum.IsDefined(typeof(EuropeanCountry), UserManager.SignedInUser.Location.ToString());//Readability
            if (!userInEU)
            {
                AddPassport(true);
            }
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

                List<IPackingListItem> packingList = new();
                foreach (ListViewItem item in lstPacking.Items)
                {
                    packingList.Add((IPackingListItem)item.Tag);
                }

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
            if (lstPacking.SelectedIndex != -1)
            {
                lstPacking.Items.Remove(lstPacking.SelectedItem);
                if (lstPacking.Items.Count == 0)
                {
                    btnRemove.IsEnabled = false;
                }
            }

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            string packItem = txtPackItem.Text.Trim();
            string quantityString = txtPackNumber.Text.Trim();
            bool required = (bool)cboxRequired.IsChecked!;
            bool travelDocument = (bool)cboxTravelDocument.IsChecked!;

            if (packItem == "Passport")
            {
                MessageBox.Show("Passport already added!");
                return;
            }

            if (!string.IsNullOrEmpty(packItem))
            {
                IPackingListItem newItem;
                ListViewItem item = new();
                if (travelDocument)
                {
                    newItem = new TravelDocument(packItem, required);
                }
                else if (int.TryParse(quantityString, out int quantity))
                {
                    newItem = new OtherItem(packItem, quantity);
                }
                else
                {
                    txtAddTravelWarning.Visibility = Visibility.Visible;
                    return;
                }
                btnRemove.IsEnabled = true;
                item.Tag = newItem;
                item.Content = newItem.GetInfo();
                lstPacking.Items.Add(item);
                lstPacking.Items.Refresh();
            }

        }

        private void cbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            bool userInEU = Enum.IsDefined(typeof(EuropeanCountry), UserManager.SignedInUser.Location.ToString());
            if (cbCountry.SelectedIndex < 1 || !userInEU)
            {
                return;
            }
            Country country = (Country)cbCountry.SelectedItem;
            bool isEUCountrySelected = Enum.IsDefined(typeof(EuropeanCountry), country.ToString());

            RemovePassport();
            if (!isEUCountrySelected || (isEUCountrySelected && !userInEU))
            {
                AddPassport(true);
            }
            else
            {
                AddPassport(false);
            }
        }

        bool IsValidInputs()
        {
            string city = txtCity.Text.Trim();

            string travellersString = txtTravelers.Text.Trim();

            return (city.Length > 0 && int.TryParse(travellersString, out _) && cbCountry.SelectedIndex > 0 && cbWorkVacation.SelectedIndex != -1) ? true : false;
        }

        void AddPassport(bool required)
        {
            ListViewItem item = new ListViewItem();
            IPackingListItem passport = new TravelDocument("Passport", required);
            item.Tag = passport;
            item.Content = passport.GetInfo();
            lstPacking.Items.Add(item);
        }

        void RemovePassport()
        {
            ListViewItem? itemToRemove = null;
            foreach (ListViewItem item in lstPacking.Items)
            {
                IPackingListItem packItem = (IPackingListItem)item.Tag;
                if (packItem.GetType() == typeof(TravelDocument) && packItem.Name == "Passport")
                {
                    itemToRemove = item;
                    break;
                }
            }
            if (itemToRemove != null)
            {
                lstPacking.Items.Remove(itemToRemove);
                lstPacking.Items.Refresh();
            }
        }
    }
}