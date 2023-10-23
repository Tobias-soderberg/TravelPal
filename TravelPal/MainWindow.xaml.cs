using System.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtLoginWarning.Visibility = Visibility.Hidden;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelWindow = new TravelsWindow();
            travelWindow.Show();
            Close();
        }
    }
}
