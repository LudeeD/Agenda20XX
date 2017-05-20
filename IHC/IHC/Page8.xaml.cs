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
    /// Interaction logic for Page8.xaml
    /// </summary>
    public partial class AX_Settings : Page
    {
        public AX_Settings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AX_TriView view = new AX_TriView();
            this.NavigationService.Navigate(view);
        }

        private void Change_Email(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Local_db.db_email.Count; i++)
            {
                if (Local_db.db_email[i] == TextBox1.Text)
                {
                    Local_db.db_email[i] = TextBox1.Text;
                    break;
                }
            }
            
        }

        private void Change_Name(object sender, RoutedEventArgs e)
        {
            for (int i=0; i < Local_db.db_user.Count; i++)
            {
                if (Local_db.db_user[i] == TextBox2.Text)
                {
                    Local_db.db_user[i] = TextBox2.Text;
                    break;
                }
            }
        }

        private void Change_Password(object sender, RoutedEventArgs e)
        {
            for (int i=0; i < Local_db.db_pass.Count; i++)
            {
                if(Local_db.db_pass[i] == TextBox3.Text)
                {
                    Local_db.db_pass[i] = TextBox3.Text;
                    break;
                }
            }
        }
    }
}
