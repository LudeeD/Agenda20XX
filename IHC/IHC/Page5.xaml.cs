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
using System.Windows.Threading;

namespace IHC
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class AX_Loading : Page
    {
        public AX_Loading()
        {
            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            timer.Start();
            AX_TriView triView = new AX_TriView();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                this.NavigationService.Navigate(triView);
            };
        }
    }
}
