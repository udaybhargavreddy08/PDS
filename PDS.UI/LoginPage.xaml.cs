﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PDS.UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text.Equals("uday", StringComparison.InvariantCultureIgnoreCase) && 
                txtPassword.Password.Equals("uday"))
            {
                NavigationService.Navigate(new HomePage());
            }
            else
            {
                txtErrorMessage.Text = "Invalid user name or password";

            }
        }
        
    }
}
