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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        

        public Page1()
        {
            InitializeComponent();

        }


       
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // Main.Content = new Page2();

        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
           // ((MainWindow)this.Owner).Hides();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Text = Convert.ToInt32(ff.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /* Page2 p2 = new Page2();
             Main.Navigate(p2);
             long totalMemory = GC.GetTotalMemory(false);

             GC.Collect();
             GC.WaitForPendingFinalizers(); */

            MainWindow.Instance.Button_Click_Next_Page_2();
        }


        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }*/
    }
}
