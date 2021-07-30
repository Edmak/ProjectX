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
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
            float b, c,d;
            korl.Inlines.Add(new Run(Per.korele));
            det.Inlines.Add(new Run(Per.dete));
            app.Inlines.Add(new Run(Per.appro));
            graf.Inlines.Add(new Run(Per.nazvaniy));
            if (Per.proverka == 0)
            {
                if (Convert.ToSingle(Per.b) >= 0)
                {
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x + " + Per.b));
                }
                if (Convert.ToSingle(Per.b) < 0)
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x -" + b));
                }
            }
            if (Per.proverka == 1)
            {
                if (Convert.ToSingle(Per.b) >= 0 && Convert.ToSingle(Per.c) >= 0)
                {
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b2 + " + Per.b + "x + " + Per.c));
                }
                if (Convert.ToSingle(Per.b) >= 0 && Convert.ToSingle(Per.c) < 0)
                {
                    c = Convert.ToSingle(Per.c);
                    c *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b2 + " + Per.b + "x - " + c));
                }
                if (Convert.ToSingle(Per.b) < 0 && Convert.ToSingle(Per.c) >= 0)
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b2 - " + b + "x + " + Per.c));
                }
                if (Convert.ToSingle(Per.b) < 0 && Convert.ToSingle(Per.c) < 0)
                {
                    c = Convert.ToSingle(Per.c);
                    c *= -1;
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b2 - " + b + "x - " + c));
                }
            }
            if (Per.proverka == 2)
            {
                yrav.Inlines.Add(new Run("y= " + Per.a + "x^" + Per.b));
            }
            if (Per.proverka == 3)
            {
                if (Convert.ToSingle(Per.b) >= 0)
                {
                    yrav.Inlines.Add(new Run("y= " + Per.a + " + " + Per.b + "lnx"));
                }
                else
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + " - " + b + "lnx"));
                }
                
            } 
            if (Per.proverka == 4)
            {
                if (Convert.ToSingle(Per.b) >= 0)
                {
                    yrav.Inlines.Add(new Run("y= e^" + Per.a + " + " + Per.b + "x"));
                }
                else
                {
                    b = Convert.ToSingle(Per.b);
                    b = b * -1;
                    yrav.Inlines.Add(new Run("y= e^" + Per.a + " - " + b + "x"));
                }
                
            }
            if (Per.proverka == 5)
            {

                if (Convert.ToSingle(Per.b) >= 0)
                {
                    yrav.Inlines.Add(new Run("y= " + Per.a + " - " + Per.b + "/x"));

                }
                else
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + " + " + b + "/x"));

                }
            }
            if(Per.proverka == 6)
            {
                if (Convert.ToSingle(Per.b) >= 0 && Convert.ToSingle(Per.c) >= 0 && Convert.ToSingle(Per.d) >= 0)
                {
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 + " + Per.b + "x\u00b2 + " + Per.c + "x + " + Per.d));
                }
                if (Convert.ToSingle(Per.b) >= 0 && Convert.ToSingle(Per.c) >= 0 && Convert.ToSingle(Per.d) < 0)
                {
                    d = Convert.ToSingle(Per.d);
                    d *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 + " + Per.b + "x\u00b2 + " + Per.c + "x - " + d));
                }
                if (Convert.ToSingle(Per.b) >= 0 && Convert.ToSingle(Per.c) < 0 && Convert.ToSingle(Per.d) >= 0)
                {
                    c = Convert.ToSingle(Per.c);
                    c *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 + " + Per.b + "x\u00b2 - " + c + "x + " + Per.d));
                }
                if (Convert.ToSingle(Per.b) >= 0 && Convert.ToSingle(Per.c) < 0 && Convert.ToSingle(Per.d) < 0)
                {
                    c = Convert.ToSingle(Per.c);
                    c *= -1;
                    d = Convert.ToSingle(Per.d);
                    d *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 + " + Per.b + "x\u00b2 - " + c + "x - " + d));
                }
                if (Convert.ToSingle(Per.b) < 0 && Convert.ToSingle(Per.c) >= 0 && Convert.ToSingle(Per.d) >= 0)
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 - " + b + "x\u00b2 + " + Per.c + "x + " + Per.d));
                }
                if (Convert.ToSingle(Per.b) < 0 && Convert.ToSingle(Per.c) < 0 && Convert.ToSingle(Per.d) >= 0)
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    c = Convert.ToSingle(Per.c);
                    c *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 - " + b + "x\u00b2 - " + c + "x + " + Per.d));
                }
                if (Convert.ToSingle(Per.b) < 0 && Convert.ToSingle(Per.c) >= 0 && Convert.ToSingle(Per.d) < 0)
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    d = Convert.ToSingle(Per.d);
                    d *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 - " + b + "x\u00b2 + " + Per.c + "x - " + d));
                }
                if (Convert.ToSingle(Per.b) < 0 && Convert.ToSingle(Per.c) < 0 && Convert.ToSingle(Per.d) < 0)
                {
                    b = Convert.ToSingle(Per.b);
                    b *= -1;
                    d = Convert.ToSingle(Per.d);
                    d *= -1;
                    c = Convert.ToSingle(Per.c);
                    c *= -1;
                    yrav.Inlines.Add(new Run("y= " + Per.a + "x\u00b3 - " + b + "x\u00b2 - " + c + "x - " + d));
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Button_Click_Next_Page_5();
        }
    }
}
