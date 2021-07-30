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


namespace ProjectX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       //private int butt = 0;
       // private int buttq = 0;
       public static MainWindow Instance; 
       

        


        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            // qweas.IsEnabled = false;
            //  qweas.Visibility = Visibility.Hidden; скрытие кнопки

        }
        
        public void Hides()
        {
           
           //qweas.Visibility = Visibility.Hidden;
            
            
        }
        public void Button_Click_Next_Page_2()
       {
           Page2 p2 = new Page2();
            Main.Navigate(p2);
            
            long totalMemory = GC.GetTotalMemory(false);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //public void Button_Click_Next_Page_4()
        //{
        //    Page4 p2 = new Page4();
        //    Main.Navigate(p2);

        //    long totalMemory = GC.GetTotalMemory(false);

        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //}
        public void Button_Click_Next_Page_3()
        {
            //WindowGraf p3 = new WindowGraf(); 
            Page3 p3 = new Page3();
            Main.Navigate(p3);
           // p3.ShowDialog();

        }
        public void Button_Click_Next_Page_6()
        {
            //WindowGraf p3 = new WindowGraf(); 
            Page6 p6 = new Page6();
            Main.Navigate(p6);
            // p3.ShowDialog();

        }
        public void Button_Click_Next_Page_5()
        {
            //WindowGraf p3 = new WindowGraf(); 
            Page5 p5 = new Page5();
            Main.Navigate(p5);
            // p3.ShowDialog();

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

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2();
            Main.Navigate(p2);

            long totalMemory = GC.GetTotalMemory(false);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
