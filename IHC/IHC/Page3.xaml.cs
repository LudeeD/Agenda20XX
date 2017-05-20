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
            Insert_user.username = TextBox2.Text;
            Insert_user.email = TextBox1.Text;
            Insert_user.password = PasswordBox1.Password.ToString();
            Regex sc = new Regex("@");

            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid email!";
                this.Snack.IsActive = true;
            }
            else if (String.IsNullOrEmpty(TextBox2.Text))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid username!";
                this.Snack.IsActive = true;
            }
            else if (String.IsNullOrEmpty(PasswordBox1.Password))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Insert a valid password!";
                this.Snack.IsActive = true;
            }
            else if (String.IsNullOrEmpty(PasswordBox2.Password))
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Confirm password!";
                this.Snack.IsActive = true;
            }
            else if (PasswordBox1.Password.ToString() != PasswordBox2.Password.ToString())
            {
                this.Snack.IsActive = false;
                this.Snack.Message.Content = "Password must be equal!";
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
                Local_db.add_db(Insert_user.username, Insert_user.password, Insert_user.email);
                AX_Login login = new AX_Login();
                login.Snack.IsActive = false;
                login.Snack.Message.Content = "Account Created Successfully!";
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

    static public class Insert_user
    {
        static public String username = "Utilizador1";
        static public String email = "adminemail@mail.com";
        static public String password = "Admin21";
    }
}
