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
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid email!";
                this.Snack.IsActive = true;
            }
            else
            {
                AX_Login login = new AX_Login();
                login.Snack.IsActive = false;
                login.Snack.Message.Content = "Email sent successfully!";
                login.Snack.IsActive = true;
                this.NavigationService.Navigate(login);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AX_Login login = new AX_Login();
            this.NavigationService.Navigate(login);
        }
    }
}
