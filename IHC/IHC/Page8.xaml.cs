using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string city = null;
        public AX_Settings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AX_TriView view = new AX_TriView();
            if (city != null)
            {
                view.Place = city;
            }
            view.fetchWeather();

            switch (chooseNews.SelectedIndex)
            {
                case 1: view.Provider = "google-news"; break;
                case 2: view.Provider = "the-new-york-times"; break;
                default: break;
            }

            view.fetchNews();

            this.NavigationService.Navigate(view);


        }

        private void Expander_Expanded_Email(object sender, RoutedEventArgs e)
        {
            this.todoSettings.IsExpanded = false;
            this.calendarSettings.IsExpanded = false;
            this.basicSettings.IsExpanded = false;
            this.scheduleSettings.IsExpanded = false;
        }

        private void Expander_Expanded_Schedule(object sender, RoutedEventArgs e)
        {
            this.todoSettings.IsExpanded = false;
            this.calendarSettings.IsExpanded = false;
            this.basicSettings.IsExpanded = false;
            this.mailSettings.IsExpanded = false;
        }

        private void Expander_Expanded_ToDo(object sender, RoutedEventArgs e)
        {
            this.mailSettings.IsExpanded = false;
            this.calendarSettings.IsExpanded = false;
            this.basicSettings.IsExpanded = false;
            this.scheduleSettings.IsExpanded = false;
        }

        private void Expander_Expanded_Calendar(object sender, RoutedEventArgs e)
        {
            this.todoSettings.IsExpanded = false;
            this.mailSettings.IsExpanded = false;
            this.basicSettings.IsExpanded = false;
            this.scheduleSettings.IsExpanded = false;
        }

        private void Expander_Expanded_Basic(object sender, RoutedEventArgs e)
        {
            if (this.todoSettings == null)
                return;
            this.todoSettings.IsExpanded = false;
            this.calendarSettings.IsExpanded = false;
            this.mailSettings.IsExpanded = false;
            this.scheduleSettings.IsExpanded = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var palette = new PaletteHelper();
            palette.SetLightDark(false);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var palette = new PaletteHelper();
            palette.SetLightDark(true);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.city = this.cityBox.Text;
        }
    }
}
