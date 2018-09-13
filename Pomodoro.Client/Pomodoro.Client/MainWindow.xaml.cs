using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Pomodoro.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable

    {
        public int PomoCount { get; set; }

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        
        public MainWindow()
        {
            InitializeComponent();
            lblPomoCount.Content = 0;
        }

        CancellationTokenSource cts;
        CancellationToken ct;
        private void button_Click(object sender, RoutedEventArgs e)
        {

            cts = new CancellationTokenSource();
            ct = cts.Token;


            // image.Source = new BitmapImage(new Uri("greenTick.jpg", UriKind.Relative));
            //  textBox.IsEnabled = false;
            Task.Run(() => Time(), ct);

           
        }


        private void Time()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            TimeSpan timeSpan = new TimeSpan(0, 25, 0);
            TimeSpan countdown = timeSpan;
            while (countdown > new TimeSpan(0, 0, 0)) 
            {
                if (ct.IsCancellationRequested)
                {
                    sw.Stop();
                    this.Dispatcher.Invoke(() => {
                        lblCountdownTimer.Content = timeSpan;
                    });

                    ct.ThrowIfCancellationRequested();
                   
                }
                
                countdown = timeSpan - sw.Elapsed;

                this.Dispatcher.Invoke(() => {
                    lblCountdownTimer.Content = countdown;
                });
            }
            
            this.Dispatcher.Invoke(() => {
                lblCountdownTimer.Content = timeSpan;
                lblPomoCount.Content = PomoCount++;
            });
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (cts.Token.CanBeCanceled)
                cts.Cancel();
        }

        public void Dispose()
        {
            cts.Dispose();
        }
    }
}
