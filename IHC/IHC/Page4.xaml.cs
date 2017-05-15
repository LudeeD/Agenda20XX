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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class AX_Password : Page
    {
        public AX_Password()
        {
            InitializeComponent();
        }

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Insert an email!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Email sent successfully!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                AX_Login login = new AX_Login();
                this.NavigationService.Navigate(login);
            }
        }
    }
}
