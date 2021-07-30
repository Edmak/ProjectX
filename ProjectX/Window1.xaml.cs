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


namespace ProjectX
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        


        public Window1(string Taitle,string Massage, string Massage_Bold, string Massage_contin)
        {
            InitializeComponent();
            //Titlee.Content = Taitle;
            Massagee.Inlines.Add(new Run(Massage));
            Massagee.Inlines.Add(new Run(Massage_Bold) { FontWeight = FontWeights.Bold });
            Massagee.Inlines.Add(new Run(Massage_contin));
        }

        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
       
          //  MainWindow.Instance.Button_Click_Next_Page_2(k);

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        
    }
}
