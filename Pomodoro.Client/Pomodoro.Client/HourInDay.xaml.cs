using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Pomodoro.Client
{
    /// <summary>
    /// Interaction logic for HourInDay.xaml
    /// </summary>
    public partial class HourInDay : UserControl
    {
        public string Hour
        {
            get { return lblHour.Content.ToString(); }
            set { lblHour.Content = value; }
        }

        public Visibility ImgVisibility
        {
            get { return image.Visibility; }
            set { image.Visibility = value; }
        }


        public HourInDay()
        {
            InitializeComponent();
            image.Source = new BitmapImage(new Uri("greenTick.jpg", UriKind.Relative));
        }
    }
}
