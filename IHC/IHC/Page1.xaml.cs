﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHC
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AX_Login : Page
    {
        public AX_Login()
        {
            ShowsNavigationUI = false;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content="Insert a Valid Username";
                this.Snack.IsActive = true;
            }
            else if (String.IsNullOrEmpty(PasswordBox1.Password))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a Valid Password";
                this.Snack.IsActive = true;
            }
            else
            {
                AX_Loading loading = new AX_Loading();
                this.NavigationService.Navigate(loading);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            AX_Register register = new AX_Register();
            this.NavigationService.Navigate(register);
        }

        private void Password_Click(object sender, RoutedEventArgs e)
        {
            AX_Password password = new AX_Password();
            this.NavigationService.Navigate(password);
        }

        private void ok_snack(object sender, RoutedEventArgs e)
        {
            this.Snack.IsActive = false;
        }
    }
}
