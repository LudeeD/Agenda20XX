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
    /// Interaction logic for Page7.xaml
    /// </summary>
    public partial class AX_Profile : Page
    {
        private string email = Insert_user.email;
        private string utilizador = Insert_user.username;
        public AX_Profile()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Back_Click(object e, RoutedEventArgs sender)
        {
            AX_TriView login = new AX_TriView();
            this.NavigationService.Navigate(login);
        }

        public string User
        {
            get { return utilizador; }
            set { utilizador = value; }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set { email = value; }
        }
    }
}
