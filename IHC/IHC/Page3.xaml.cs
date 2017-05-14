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
            MessageBox.Show("Account Created Successfully!");
            AX_Login login = new AX_Login();
            this.NavigationService.Navigate(login);
        }
    }
}
