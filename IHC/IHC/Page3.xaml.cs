using System;
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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class AX_Register : Page
    {
        public AX_Register()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Insert a valid email!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (String.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Insert a valid username!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (String.IsNullOrEmpty(PasswordBox1.Password))
            {
                MessageBox.Show("Insert a valid password!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (String.IsNullOrEmpty(PasswordBox2.Password))
            {
                MessageBox.Show("Confirm password!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Account Created Successfully!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                AX_Login login = new AX_Login();
                this.NavigationService.Navigate(login);
            }
        }

    }
}
