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
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using System.Collections.ObjectModel;

namespace ProjectX
{

    public partial class Qq
    {
        // public new string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }
        public List<DataPoint> Pointstwo { get; private set; }
        public PlotModel Model { get; private set; }
        public Qq DataContext { get; private set; }

        public static Qq Instance;
        public Qq()
        {
            Instance = this;
            Qq mn = DataContext as Qq;
            /*this.Points = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };

            this.Pointstwo = new List<DataPoint>
            {
                new DataPoint(5,6),
                new DataPoint(10,10),
                new DataPoint(18,14)
            };
            */
        }
        public void rty()
        {
            /*Console.WriteLine("Что угодно");

            var tmp = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };

            var series1 = new OxyPlot.Series.LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
            series1.Points.Add(new DataPoint(0, 0));
            series1.Points.Add(new DataPoint(10, 18));
            series1.Points.Add(new DataPoint(20, 12));
            series1.Points.Add(new DataPoint(30, 8));
            series1.Points.Add(new DataPoint(40, 15));

            tmp.Series.Add(series1);


            this.Model = tmp;*/





              this.Points = new ObservableCollection<DataPoint>
                            {
                               new DataPoint(0, 4),
                                new DataPoint(10, 13),
                                new DataPoint(20, 15),
                                new DataPoint(30, 16),
                                new DataPoint(40, 12),
                                new DataPoint(50, 12),
                            };

              this.Pointstwo = new List<DataPoint>
          {
              new DataPoint(5,6),
              new DataPoint(10,10),
              new DataPoint(18,14)
          };

        }
    }
    




    public partial class WindowGraf : Window
    {
        public IList<DataPoint> Points { get; private set; }
        public List<DataPoint> Pointstwo { get; private set; }


        public WindowGraf()
        {
            InitializeComponent();
            wer = 5;
            //Qq e = new Qq(wer);

        }

        public int wer;
        public void qwqe(int N, int[] novi, int[] obem)
        {

        }
        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Expand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;

        }

        private void roll_up_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Qq.Instance.rty();
            Qq mn = DataContext as Qq;
            mn.Points.Add(new DataPoint(30, 10));

        }

    }
}


