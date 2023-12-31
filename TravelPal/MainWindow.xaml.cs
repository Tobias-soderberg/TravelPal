﻿using System.Windows;

namespace TravelPal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (UserManager.users.Count == 0)
            {
                UserManager.initiateUsers();
            }
            txtLoginWarning.Visibility = Visibility.Hidden;  //Added to still see it in window view
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.ToString().Trim();
            if (UserManager.SignInUser(username, password))
            {

                TravelsWindow travelWindow = new TravelsWindow();
                travelWindow.Show();
                Close();
            }
            txtLoginWarning.Visibility = Visibility.Visible;
        }
    }
}
