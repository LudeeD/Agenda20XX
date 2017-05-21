using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string _to_do;
        private string _evento;

        private ObservableCollection<Todo> _TodoList = new ObservableCollection<Todo>();
        private ObservableCollection<Class> _Schedule_Mon = new ObservableCollection<Class>();
        private ObservableCollection<Class> _Schedule_Thu = new ObservableCollection<Class>();
        private ObservableCollection<Class> _Schedule_Wed = new ObservableCollection<Class>();
        private ObservableCollection<Class> _Schedule_Tue = new ObservableCollection<Class>();
        private ObservableCollection<Class> _Schedule_Fri = new ObservableCollection<Class>();


        public AX_TriView()
        {
            InitializeComponent();
            seedTodos();
            seedSchedule();
            todosListBox.ItemsSource = ListaToDos;
            scheduleListBoxMon.ItemsSource = _Schedule_Mon;
            scheduleListBoxThu.ItemsSource = _Schedule_Thu;
            scheduleListBoxWed.ItemsSource = _Schedule_Wed;
            scheduleListBoxTue.ItemsSource = _Schedule_Tue;
            scheduleListBoxFri.ItemsSource = _Schedule_Fri;



            this.DataContext = this;
        }

        private void seedTodos()
        {
            _TodoList.Add(new Todo { Text = "Clean the House" });
            _TodoList.Add(new Todo { Text = "Wash the Car" });
            _TodoList.Add(new Todo { Text = "Buy Cat Food" });
        }

        private void seedSchedule()
        {
            _Schedule_Mon.Add(new IHC.Class("09:00", "10:00", "Base de Dados", "4.2.3"));
            _Schedule_Mon.Add(new IHC.Class("10:00", "11:00", "Ihc", "4.2.2"));
            _Schedule_Mon.Add(new IHC.Class("11:00", "10:00", "Arquitectura de Redes", "4.1.3"));
            _Schedule_Mon.Add(new IHC.Class("12:00", "10:00", "Base de Dados Prática", "4.2.3"));

            _Schedule_Tue.Add(new IHC.Class("13:00", "16:00", "Pei", "4.2.3"));

            _Schedule_Wed.Add(new IHC.Class("09:00", "10:00", "IHC ", "4.2.3"));
            _Schedule_Wed.Add(new IHC.Class("11:00", "12:00", "IHC Prática", "4.2.3"));

            _Schedule_Thu.Add(new IHC.Class("13:00", "15:00", "Pei", "4.2.3"));
            _Schedule_Thu.Add(new IHC.Class("15:00", "16:00", "Arquitectura de Redes", "4.2.3"));
           

        }

        private void ToggleButton_ClickSchedule(object sender, RoutedEventArgs e)
        {
            this.News.Visibility = Visibility.Visible;
            this.Schedule.Visibility = Visibility.Collapsed;
        }

        private void ToggleButton_ClickCalendar(object sender, RoutedEventArgs e)
        {
            this.Calendar.Visibility = Visibility.Collapsed;
            this.ToDo.Visibility = Visibility.Visible;
        }

        private void ToggleButton_ClickTodo(object sender, RoutedEventArgs e)
        {
            this.ToDo.Visibility = Visibility.Collapsed;
            this.Calendar.Visibility = Visibility.Visible;
        }

        private void ToggleButton_ClickNews(object sender, RoutedEventArgs e)
        {
            this.News.Visibility = Visibility.Collapsed;
            this.Schedule.Visibility = Visibility.Visible;
        }


        private void addEvent(object sender, RoutedEventArgs e)
        {
            this.@event.Visibility = Visibility.Visible;
            //_evento = TextBox2.Text;
            successAction(sender, e);
        }

        public string Eventos
        {
            get { return _evento; }
            set { _evento = value; }
        }


        public string Todo
        {
            get { return _to_do; }
            set { _to_do = value; }
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
            AX_Settings setting = new AX_Settings();
            this.NavigationService.Navigate(setting);
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
        private void on_Profile(object sender, RoutedEventArgs e)
        {
            AX_Profile profile = new AX_Profile();
            this.NavigationService.Navigate(profile);
        }


        public ObservableCollection<Todo> ListaToDos { get { return _TodoList; } }

        private void addTodo(object sender, RoutedEventArgs e)
        {
            _TodoList.Add(new Todo { Text = this.TodoText.Text });
            this.TodoText.Text = "";
        }

        private void monClick(object sender, MouseButtonEventArgs e)
        {
            scheduleListBoxMon.Visibility = Visibility.Visible;
            scheduleListBoxTue.Visibility = Visibility.Collapsed;
            scheduleListBoxWed.Visibility = Visibility.Collapsed;
            scheduleListBoxThu.Visibility = Visibility.Collapsed;
            scheduleListBoxFri.Visibility = Visibility.Collapsed;
        }

        private void tueClick(object sender, MouseButtonEventArgs e)
        {

            scheduleListBoxMon.Visibility = Visibility.Collapsed;
            scheduleListBoxTue.Visibility = Visibility.Visible;
            scheduleListBoxWed.Visibility = Visibility.Collapsed;
            scheduleListBoxThu.Visibility = Visibility.Collapsed;
            scheduleListBoxFri.Visibility = Visibility.Collapsed;

        }

        private void wedClick(object sender, MouseButtonEventArgs e)
        {
            scheduleListBoxMon.Visibility = Visibility.Collapsed;
            scheduleListBoxTue.Visibility = Visibility.Collapsed;
            scheduleListBoxWed.Visibility = Visibility.Visible;
            scheduleListBoxThu.Visibility = Visibility.Collapsed;
            scheduleListBoxFri.Visibility = Visibility.Collapsed;

        }

        private void thuClick(object sender, MouseButtonEventArgs e)
        {
            scheduleListBoxMon.Visibility = Visibility.Collapsed;
            scheduleListBoxTue.Visibility = Visibility.Collapsed;
            scheduleListBoxWed.Visibility = Visibility.Collapsed;
            scheduleListBoxThu.Visibility = Visibility.Visible;
            scheduleListBoxFri.Visibility = Visibility.Collapsed;

        }

        private void friClick(object sender, MouseButtonEventArgs e)
        {
            scheduleListBoxMon.Visibility = Visibility.Collapsed;
            scheduleListBoxTue.Visibility = Visibility.Collapsed;
            scheduleListBoxWed.Visibility = Visibility.Collapsed;
            scheduleListBoxThu.Visibility = Visibility.Collapsed;
            scheduleListBoxFri.Visibility = Visibility.Visible;

        }
    }
}
