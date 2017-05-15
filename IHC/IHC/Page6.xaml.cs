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
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class AX_TriView : Page
    {
        public AX_TriView()
        {
            InitializeComponent();
        }

        private void ToggleButton_ClickSchedule(object sender, RoutedEventArgs e)
        {
            this.Calendar.Visibility = Visibility.Visible;
            this.Schedule.Visibility = Visibility.Collapsed;
            this.ToggleSchedule.IsChecked = true;
        }

        private void ToggleButton_ClickCalendar(object sender, RoutedEventArgs e)
        {
            this.Calendar.Visibility = Visibility.Collapsed;
            this.Schedule.Visibility = Visibility.Visible;
            this.ToggleCalendar.IsChecked = false;
        }

        private void ToggleButton_ClickTodo(object sender, RoutedEventArgs e)
        {
            this.ToDo.Visibility = Visibility.Collapsed;
            this.News.Visibility = Visibility.Visible;
            this.ToggleTodo.IsChecked = true;
        }

        private void ToggleButton_ClickNews(object sender, RoutedEventArgs e)
        {
            this.News.Visibility = Visibility.Collapsed;
            this.ToDo.Visibility = Visibility.Visible;
            this.ToggleNews.IsChecked = false;
        }



        private void createEvent(object sender, RoutedEventArgs e)
        {
            this.@event.Visibility = Visibility.Visible;
            successAction(sender, e);

        }

        private void createTodo(object sender, RoutedEventArgs e)
        {
            this.TodoCard.Visibility = Visibility.Visible;
            successAction(sender, e);
        }

        private void successAction(object sender, RoutedEventArgs e)
        {
            this.ToEmail.Text = "";
            this.ccEmail.Text = "";
            this.AssuntoEmail.Text = "";
            this.MailEmail.Text = "";
            this.Snack.IsActive = false;
            this.Snack.Message.Content = "Action succeeded";
            this.Snack.IsActive = true;
        }

        private void Snack_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Snack.IsActive = false;
        }

        private void Settings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AX_Login login = new AX_Login();
            this.NavigationService.Navigate(login);
        }

        private void ToggleButton_MouseLeave(object sender, MouseEventArgs e)
        {
            this.hamburguer.IsChecked = false;
        }

        private void on_Calendar(object sender, RoutedEventArgs e)
        {
            this.Calendar.Visibility = Visibility.Visible;
            this.Schedule.Visibility = Visibility.Collapsed;
        }
        private void on_Schedule(object sender, RoutedEventArgs e)
        {
            this.Schedule.Visibility = Visibility.Visible;
            this.Calendar.Visibility = Visibility.Collapsed;

        }
        private void on_Todo(object sender, RoutedEventArgs e)
        {
            this.ToDo.Visibility = Visibility.Visible;
            this.News.Visibility = Visibility.Collapsed;

        }
        private void on_News(object sender, RoutedEventArgs e)
        {
            this.News.Visibility = Visibility.Visible;
            this.ToDo.Visibility = Visibility.Collapsed;

        }
        private void on_Email(object sender, RoutedEventArgs e)
        {
            this.Email.Visibility = Visibility.Visible;
        }
    }
}
