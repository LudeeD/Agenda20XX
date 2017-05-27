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
using System.Windows.Threading;
using RestSharp;
using System.Diagnostics;
using Newtonsoft.Json;

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

        private ObservableCollection<News> _topNews = new ObservableCollection<IHC.News>();

        private ObservableCollection<Event> calendar = new ObservableCollection<Event>();

        

        private string key = "95e3f8d41eae46909ce232325172505";
        private string apiKey = "352daa3b9e104067acb23c49965ceab3";
        private string place = "Aveiro";
        private string provider = "cnn";


        public AX_TriView()
        {
            InitializeComponent();
            seedTodos();
            seedSchedule();

            seedCalendar();

            todosListBox.ItemsSource = ListaToDos;
            scheduleListBoxMon.ItemsSource = _Schedule_Mon;
            scheduleListBoxThu.ItemsSource = _Schedule_Thu;
            scheduleListBoxWed.ItemsSource = _Schedule_Wed;
            scheduleListBoxTue.ItemsSource = _Schedule_Tue;
            scheduleListBoxFri.ItemsSource = _Schedule_Fri;
            newsListBox.ItemsSource = _topNews;

            CalendarListBox.ItemsSource = calendar;

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            this.timeText.Text = DateTime.Now.ToString("HH:mm");
            this.dateText.Text = DateTime.Now.ToString("dd/MM/yy"); 
            dispatcherTimer.Start();

            fetchWeather();
            fetchNews();
        }

        private void seedCalendar()
        {
            calendar.Add(new Event(new DateTime(2017,6,23), "Go to The Dentist"));
            calendar.Add(new Event(new DateTime(2017,7,21), "Deliver Project"));
            calendar.Add(new Event(new DateTime(2017,8,3), "Go to the Doctor"));
            calendar.Add(new Event(new DateTime(2017,8,4), "Meating with the boss"));
            calendar.Add(new Event(new DateTime(2017,8,21), "Go see Mom"));
            calendar.Add(new Event(new DateTime(2017,9,11), "Exam IHC"));
            calendar.Add(new Event(new DateTime(2017,10,7), "Exam BD"));
            calendar.Add(new Event(new DateTime(2017,10,3), "Last Day to Finish Project"));
            calendar.Add(new Event(new DateTime(2017,12, 19), "Birthday"));
            calendar.Add(new Event(new DateTime(2017,12,25), "Christmas"));

            //calendar = new ObservableCollection<Event> (calendar.OrderBy(calendar => calendar));


        }

        public void fetchNews()
        {
            try
            {
                //https://newsapi.org/v1/articles?source=cnn&sortBy=top&apiKey=352daa3b9e104067acb23c49965ceab3
                var client = new RestClient();
                client.BaseUrl = new Uri("https://newsapi.org");
                var request = new RestRequest("v1/articles", Method.GET);
                //request.AddUrlSegment("API_KEY", key);
                //request.AddUrlSegment("place", place);
                request.AddParameter("source", Provider);
                request.AddParameter("sortBy", "top");
                request.AddParameter("apiKey", apiKey);
                
                IRestResponse response = client.Execute(request);
                Debug.WriteLine("=======================================================");
                Debug.WriteLine(response.Content.ToString());
                Debug.WriteLine("=======================================================");

                dynamic news = JsonConvert.DeserializeObject(response.Content.ToString());


                //Debug.WriteLine((string)news["articles"]["0"]["title"]);
                foreach (var n in news["articles"])
                {
                    Debug.WriteLine((string)n["title"]);
                    _topNews.Add(new News((string)n["title"], (string)n["urlToImage"], (string)n["url"]));
                }

            }
            catch
            {
                //TODO SNACK a Dizer que não foi possível Ir buscar as Notcicias
            }

        }

        public void fetchWeather()
        {
            try
            {
                //Debug.WriteLine("================================ Get Weatherr");
                var client = new RestClient();
                client.BaseUrl = new Uri("http://api.apixu.com");
                var request = new RestRequest("v1/current.json", Method.GET);
                //request.AddUrlSegment("API_KEY", key);
                //request.AddUrlSegment("place", place);
                request.AddParameter("key", key);
                request.AddParameter("q", Place);
                IRestResponse response = client.Execute(request);
                //Debug.Write("=======================================================");
                //Debug.WriteLine(response.Content.ToString());
                dynamic weather = JsonConvert.DeserializeObject(response.Content.ToString());

                this.CityText.Text = weather["location"]["name"] + " , " + weather["location"]["country"];
                this.TempText.Text = "Temperature : " + weather["current"]["temp_c"] + " C";
                this.PrecText.Text = "Precipitation: " + weather["current"]["precip_mm"] + " nm";
                this.HumiText.Text = "Humidity : " + weather["current"]["humidity"] + " %";
                this.WindText.Text = "Wind : " + weather["current"]["wind_kph"] + " Km/h";

                this.imageWeather.Source = new BitmapImage(new Uri("http:" + weather["current"]["condition"]["icon"]));
                //Debug.WriteLine("=================" + this.imageWeather.Source);
                //http://api.apixu.com/v1/current.json?key=<YOUR_API_KEY>&q=London
            }
            catch
            {
                //TODO SNACK a Dizer que não foi possível Ir buscar o Tempo
            }
            

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.timeText.Text= DateTime.Now.ToString("HH:mm");
            this.dateText.Text = DateTime.Now.ToString("dd/MM/yy");
        }

        private void seedTodos()
        {
            _TodoList.Add(new Todo { Text = "Clean the House" });
            _TodoList.Add(new Todo { Text = "Wash the Car" });
            _TodoList.Add(new Todo { Text = "Buy Cat Food" });
        }

        private void seedSchedule()
        {
            int day = (int)DateTime.Now.DayOfWeek - 1;
            
            if (day != -1 && day != 5)
                this.ScheduleDay.SelectedIndex = day;

            _Schedule_Mon.Add(new IHC.Class("11:00", "13:00", "Base de Dados T", "Anf IV"));
            _Schedule_Mon.Add(new IHC.Class("16:00", "19:00", "Arquitetura de Redes P", "4.2.20"));

            _Schedule_Tue.Add(new IHC.Class("11:00", "13:00", "Interacção Humano Computador T", "4.1.11"));
            _Schedule_Tue.Add(new IHC.Class("14:00", "16:00", "Interacção Humano Computador P", "Anf V"));
            _Schedule_Tue.Add(new IHC.Class("16:00", "17:00", "Arquitetura de Redes T", "Anf V"));

            _Schedule_Wed.Add(new IHC.Class("09:30", "13:00", "Projecto Eng Informática", "Anf V"));

            _Schedule_Thu.Add(new IHC.Class("14:00", "15:00", "Arquitetura de Redes T", "Anf V"));
            _Schedule_Thu.Add(new IHC.Class("15:00", "16:00", "Base de Dados P", "4.2.8"));
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
            //this.@event.Visibility = Visibility.Visible;
            ////_evento = TextBox2.Text;
            //successAction(sender, e);
            try
            {
                calendar.Add(new Event((DateTime)EventDate.SelectedDate, EventText.Text));
                calendar = new ObservableCollection<Event>(calendar.OrderBy(calendar => calendar));

                CalendarListBox.InvalidateArrange();
                CalendarListBox.ItemsSource = calendar;
                CalendarListBox.UpdateLayout();
            }
            catch (Exception)
            {
             
            }
            
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

        private void Logout_Click(object sender, RoutedEventArgs e)
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
            this.ToDo.Visibility = Visibility.Collapsed;
            this.Calendar.Visibility = Visibility.Visible;
        }
        private void on_Schedule(object sender, RoutedEventArgs e)
        {
            this.News.Visibility = Visibility.Collapsed;
            this.Schedule.Visibility = Visibility.Visible;

        }
        private void on_Todo(object sender, RoutedEventArgs e)
        {
            this.Calendar.Visibility = Visibility.Collapsed;
            this.ToDo.Visibility = Visibility.Visible;
        }
        private void on_News(object sender, RoutedEventArgs e)
        {
            this.News.Visibility = Visibility.Visible;
            this.Schedule.Visibility = Visibility.Collapsed;

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

        public string Place
        {
            get
            {
                return place;
            }

            set
            {
                place = value;
            }
        }

        public string Provider
        {
            get
            {
                return provider;
            }

            set
            {
                provider = value;
            }
        }

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


        private void on_Settings(object sender, RoutedEventArgs e)
        {
            AX_Settings settings = new AX_Settings();
            this.NavigationService.Navigate(settings);
        }

        private void dayClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void weekClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void monthClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void allClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void newsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Process.Start(_topNews[newsListBox.SelectedIndex].URL);
            e.Handled = true;
        }
    }
}
