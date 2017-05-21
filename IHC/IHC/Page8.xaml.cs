using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Regex sc = new Regex("@");
            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid email!";
                this.Snack.IsActive = true;
            }
            else if (!sc.IsMatch(TextBox1.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid email!";
                this.Snack.IsActive = true;
            }
            else
            {
                for (int i = 0; i < Local_db.db_email.Count; i++)
                {
                    if (Local_db.db_email[i] == Insert_user.email)
                    {
                        Local_db.db_email[i] = TextBox1.Text;
                        Insert_user.email = TextBox1.Text;
                        break;
                    }
                }
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Account's email changed successfully!";
                this.Snack.IsActive = true;
            }
        }

        private void Change_Name(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox2.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid username!";
                this.Snack.IsActive = true;
            }
            else
            {
                for (int i = 0; i < Local_db.db_user.Count; i++)
                {
                    if (Local_db.db_user[i] == Insert_user.username)
                    {
                        Local_db.db_user[i] = TextBox2.Text;
                        Insert_user.username = TextBox2.Text;
                        break;
                    }
                }
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Account's name changed successfully!";
                this.Snack.IsActive = true;
            }
        }

        private void Change_Password(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox3.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid password!";
                this.Snack.IsActive = true;
            }
            else
            {
                for (int i = 0; i < Local_db.db_pass.Count; i++)
                {
                    if (Local_db.db_pass[i] == Insert_user.password)
                    {
                        Local_db.db_pass[i] = TextBox3.Text;
                        Insert_user.password = TextBox3.Text;
                        break;
                    }
                }
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Account's password changed successfully!";
                this.Snack.IsActive = true;
            }
        }

        
    }
}
