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

        private void createEvent(object sender, RoutedEventArgs e)
        {
            this.@event.Visibility = Visibility.Visible;
        }
    }
}
