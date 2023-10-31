using System.Windows;
using System.Windows.Controls;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            lblHeader.Content = travel.Country.ToString();
            txtCity.Text = travel.Destination;
            txtCountry.Text = travel.Country.ToString();
            txtTravelers.Text = travel.Travellers.ToString();

            GetTypeDetails(travel);

            GetPackItems(travel);

        }



        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();
        }

        void GetPackItems(Travel travel)
        {
            foreach (IPackingListItem packingListItem in travel.PackingList)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = packingListItem;
                item.Content = packingListItem.GetInfo();
                lstPacklist.Items.Add(item);
            }
        }
        private void GetTypeDetails(Travel travel)
        {
            if (travel.GetType() == typeof(WorkTrip))
            {

                WorkTrip workTrip = (WorkTrip)travel;
                txtType.Text = travel.GetType().Name;
                txtExtraInfo.Height = 65;
                txtExtraInfo.Text = workTrip.GetInfo();
            }
            else if (travel.GetType() == typeof(Vacation))
            {

                Vacation vacation = (Vacation)travel;
                txtType.Text = travel.GetType().Name;
                txtExtraInfo.Text = vacation.GetInfo();
            }
        }
    }
}
