using Microsoft.Office.Interop.Excel;
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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : System.Windows.Controls.Page
    {
        public Page5()
        {
            InitializeComponent();
            cc = 1;
            ccc = 100;
            rez[0] = переменая.ober[0];
            bat1.Visibility = Visibility.Hidden;
            bat2.Visibility = Visibility.Hidden;
            //if (переменая.gg >= 4)
            //{
            //    qub.IsEnabled = true;
            //    qvad.IsEnabled = true;
            //}
            //else
            //{
            //    qub.IsEnabled = false;
            //    qvad.IsEnabled = false;
            //}
            for (int i = 0; i < переменая.gg; i++)
            {
                ee[i] = переменая.novich[i] * переменая.ober[i]; // x*y
                pow[i] = переменая.novich[i] * переменая.novich[i]; // x^2
                y2[i] = переменая.ober[i] * переменая.ober[i]; //y^2
                pow3[i] = переменая.novich[i] * переменая.novich[i] * переменая.novich[i];
                pow4[i] = переменая.novich[i] * переменая.novich[i] * переменая.novich[i] * переменая.novich[i];
                pow5[i] = Math.Pow(переменая.novich[i], 5);
                pow6[i] = Math.Pow(переменая.novich[i], 6);
                x2y[i] = (переменая.novich[i] * переменая.novich[i]) * переменая.ober[i];
                x3y[i] =  Math.Pow(переменая.novich[i],3) *  переменая.ober[i];
                ln10[i] = Convert.ToSingle(Math.Log(переменая.novich[i]) * Math.Log(переменая.ober[i]));
                ln10x2[i] = Convert.ToSingle(Math.Log(переменая.novich[i]) * Math.Log(переменая.novich[i]));
                ln10x[i] = Convert.ToSingle(Math.Log(переменая.novich[i]));
                ln10y[i] = Convert.ToSingle(Math.Log(переменая.ober[i]));
                ln10xlny[i] = Convert.ToSingle(переменая.novich[i] * Math.Log(переменая.ober[i]));
                ln10ylnx[i] = Convert.ToSingle(переменая.ober[i] * Math.Log(переменая.novich[i]));
                ynax[i] = Convert.ToSingle(переменая.ober[i] / переменая.novich[i]);
                odinnax[i] = Convert.ToSingle(1 / переменая.novich[i]);
                odinnax2[i] = Convert.ToSingle(1 / (переменая.novich[i] * переменая.novich[i]));
            }
        }
        string Taitle = "";
        string Massage = "";
        string Massage_Bold = "";
        string Massage_contin = "";
        float[] rez = new float[100];// массив y новый по эйлеру
        int cc;
        int ccc;
        float[] x2y = new float[100]; // x^2*y
        double[] x3y = new double[100];
        float[] y2 = new float[100];
        float[] model = new float[100];
        float[] model1 = new float[100];
        float[] yyrav = new float[100];
        float[] yyrav1 = new float[100];
        float[] ee = new float[100]; // 
        float[] pow = new float[100]; // массив ворзведеных в 2 степень x
        double[] pow3 = new double[100]; // массив ворзведеных в 3 степень
        double[] pow4 = new double[100];// массив ворзведеных в 4 степень
        double[] pow5 = new double[100];// массив ворзведеных в 4 степень
        double[] pow6 = new double[100];// массив ворзведеных в 4 степень
        float[] yminusy = new float[100]; // массив среднего значения по my
        float[] yminusy1 = new float[100]; // массив среднего значения по my
        float[] ln10 = new float[100]; // ln x * ln y
        float[] ln10x = new float[100]; // ln x
        float[] ln10x2 = new float[100]; // ln^2 x
        float[] ln10y = new float[100]; // ln y
        float[] ln10xlny = new float[100]; // x * ln y 
        float[] ln10ylnx = new float[100]; // y * ln x
        float[] ynax = new float[100]; // Y/x
        float[] odinnax = new float[100]; // 1/x
        float[] odinnax2 = new float[100]; // 1/x^2
        float[] sravenene = new float[100]; // Массив для сравнения

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Линейная_регрессия_2();
            // квадратичная_регрессия();
            // степенная_регрессия();
            //логарифмическая_регрессия();
            экспоненциальная_регрессия();
        }
      
        
        private void Линейная_регрессия()
        {
            Per.proverka = 0;
            float a;// коэфицент а в y=ax+b
            float b;//  коэфицент b в y=ax+b
            float r; // Коэффициент линейной парной корреляции:
            float R; //Коэффициент детерминации
            float A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;
            a = (переменая.novich.Sum() * переменая.ober.Sum() - переменая.gg * ee.Sum()) / ((переменая.novich.Sum() * переменая.novich.Sum()) - переменая.gg * pow.Sum());
            b = (переменая.novich.Sum() * ee.Sum() - pow.Sum() * переменая.ober.Sum()) / ((переменая.novich.Sum() * переменая.novich.Sum()) - переменая.gg * pow.Sum());
            r = Convert.ToSingle((переменая.gg * ee.Sum() - переменая.novich.Sum() * переменая.ober.Sum()) / (Math.Sqrt((переменая.gg * pow.Sum() - (переменая.novich.Sum() * переменая.novich.Sum()))*(переменая.gg * y2.Sum() - (переменая.ober.Sum() * переменая.ober.Sum()) ))));
            R = r * r;
            for (int i = 0; i < переменая.gg; i++)
            {
                model[i] = Math.Abs((переменая.ober[i] - (a * переменая.novich[i] + b)) / (переменая.ober[i]));
            }
            A =( (Convert.ToSingle(cc)/ переменая.gg) * model.Sum() * Convert.ToSingle(ccc));
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(r);
            Console.WriteLine(R);
            Console.WriteLine(A);

            sravenene[0] = R;

            Per.korele = Convert.ToString(Math.Round(r, 2));
            Per.dete = Convert.ToString(Math.Round(R, 2));
            Per.appro = Convert.ToString(Math.Round(A, 2));
            Per.nazvaniy = "Линейная регрессия";
            Per.a = Convert.ToString(Math.Round(a,2) );
            Per.b = Convert.ToString(Math.Round(b,2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;

            if (переменая.novich[0] + переменая.novich[1] >= 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.5);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] = kk;
                Per.trendy[i] = Convert.ToSingle(a * Per.trendx[i]  + b );
                //Console.WriteLine(Per.trendy[i]);
                kk += plch;
            }


        }
        private void квадратичная_регрессия()
        {
            Per.proverka = 1;
            float det; // определитель матрицы
            float a;
            float b;
            float c;
           float R; // Коэффициент корреляции:
            float y; // 
            float R2;  // Коэффициент детерминации
            float A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;
            det =  Convert.ToSingle((pow.Sum() * pow.Sum() * pow.Sum()) + (переменая.novich.Sum() * переменая.novich.Sum() * pow4.Sum()) + (pow3.Sum() * pow3.Sum() * переменая.gg) - (переменая.gg * pow.Sum() * pow4.Sum()) - (переменая.novich.Sum()* pow3.Sum() * pow.Sum()) - (pow.Sum() * pow3.Sum() * переменая.novich.Sum())) ;
            a =Convert.ToSingle((переменая.ober.Sum() * pow.Sum() * pow.Sum() + переменая.novich.Sum() * переменая.novich.Sum() * x2y.Sum() + ee.Sum() * pow3.Sum() * переменая.gg - переменая.gg * pow.Sum() * x2y.Sum() - переменая.novich.Sum() * ee.Sum() *pow.Sum() - переменая.novich.Sum() * pow3.Sum() * переменая.ober.Sum()) / det);
            b =Convert.ToSingle( (pow.Sum() * ee.Sum() * pow.Sum() + переменая.ober.Sum() * переменая.novich.Sum()*pow4.Sum() + pow3.Sum() * x2y.Sum() * переменая.gg  - переменая.gg * ee.Sum() * pow4.Sum() - переменая.ober.Sum() * pow3.Sum() * pow.Sum() - переменая.novich.Sum() * x2y.Sum() * pow.Sum()) / det);
            c =Convert.ToSingle( (pow.Sum()* pow.Sum() * x2y.Sum() + переменая.novich.Sum() * ee.Sum() * pow4.Sum() + pow3.Sum() * pow3.Sum() * переменая.ober.Sum() - переменая.ober.Sum() * pow.Sum() * pow4.Sum() - переменая.novich.Sum() * pow3.Sum() * x2y.Sum() - ee.Sum() * pow3.Sum() * pow.Sum()) / det);
            y = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum());
            for (int i = 0; i < переменая.gg; i++)
            {
                model[i] = Convert.ToSingle( Math.Abs((переменая.ober[i] - (a * (переменая.novich[i]*переменая.novich[i]) + b * переменая.novich[i] + c)) / (переменая.ober[i])));
                yyrav[i] = Convert.ToSingle((переменая.ober[i] - (a * pow[i] + b * переменая.novich[i] + c)) * (переменая.ober[i] - (a * pow[i] + b * переменая.novich[i] + c) ));
                yminusy[i] = Convert.ToSingle((переменая.ober[i] - y)*(переменая.ober[i] - y));
            }
            R = Convert.ToSingle( Math.Sqrt(Convert.ToSingle(cc) - (yyrav.Sum() / yminusy.Sum()) ));
            R2 = R * R;
            A = ((Convert.ToSingle(cc) / переменая.gg) * model.Sum() * Convert.ToSingle(ccc));

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(R);
            Console.WriteLine(R2);
            Console.WriteLine(A);

            sravenene[1] = R2;

            Per.a = Convert.ToString(Math.Round(a,2));
            Per.b = Convert.ToString(Math.Round(b,2));
            Per.c = Convert.ToString(Math.Round(c,2));

            Per.nazvaniy = "Квадратичная регрессия";
            Per.korele = Convert.ToString(Math.Round(R, 2));
            Per.dete = Convert.ToString(Math.Round(R2, 2));
            Per.appro = Convert.ToString(Math.Round(A, 2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;
           
            if (переменая.novich[0] + переменая.novich[1] >= 2 )
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.5);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if(переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten-1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }      
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                       Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {                   
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                { 
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] =kk;
                Per.trendy[i] = Convert.ToSingle(a *(Per.trendx[i] * Per.trendx[i]) + b * Per.trendx[i] + c); 
                kk += plch;
            }
        }


        private void степенная_регрессия()
        {
            Per.proverka = 2;
            float a;
            float b;
            double R; // Коэффициент корреляции:
            double y; // 
            double R2;  // Коэффициент детерминации
            double A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;

            b = (переменая.gg * ln10.Sum() - ln10x.Sum() * ln10y.Sum()) / (переменая.gg * ln10x2.Sum() - (ln10x.Sum() * ln10x.Sum()));
            a = Convert.ToSingle(Math.Exp(((Convert.ToSingle(cc) / переменая.gg) * ln10y.Sum()) - ((b / переменая.gg) * ln10x.Sum())));
            y = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum());
            for (int i = 0; i < переменая.gg; i++)
            {
                model1[i] = Convert.ToSingle(Math.Abs((переменая.ober[i] - (a * Math.Pow(переменая.novich[i], b))) / (переменая.ober[i])));
                yyrav1[i] = Convert.ToSingle((переменая.ober[i] - (a * Math.Pow(переменая.novich[i], b))) * (переменая.ober[i] - (a * Math.Pow(переменая.novich[i], b))));
                yminusy1[i] = Convert.ToSingle((переменая.ober[i] - y) * (переменая.ober[i] - y));


            }
            R = Math.Sqrt(Convert.ToSingle(cc) - (yyrav1.Sum() / yminusy1.Sum()));
            R2 = R * R;
            A = ((Convert.ToSingle(cc) / переменая.gg) * model1.Sum() * Convert.ToSingle(ccc));


            Console.WriteLine(b);
            Console.WriteLine(a);
            Console.WriteLine(R);
            Console.WriteLine(R2);
            Console.WriteLine(A);

            sravenene[2] = Convert.ToSingle(R2);

            Per.a = Convert.ToString(Math.Round(a,2));
            Per.b = Convert.ToString(Math.Round(b,2));

            Per.nazvaniy = "Степенная регрессия";
            Per.korele = Convert.ToString(Math.Round(R, 2));
            Per.dete = Convert.ToString(Math.Round(R2, 2));
            Per.appro = Convert.ToString(Math.Round(A, 2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;

            if (переменая.novich[0] + переменая.novich[1] >= 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.5);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] = kk;
                Per.trendy[i] = Convert.ToSingle(a * Math.Pow(Per.trendx[i], b));
                //Console.WriteLine(Per.trendy[i]);
                kk += plch;
            }
        }

        private void логарифмическая_регрессия()
        {
            Per.proverka = 3;
            float a;
            float b;
            double R; // Коэффициент корреляции:
            double y; // 
            double R2;  // Коэффициент детерминации
            double A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;

            b = (переменая.gg * ln10ylnx.Sum() - ln10x.Sum() * переменая. ober.Sum())/ (переменая.gg * ln10x2.Sum() - (ln10x.Sum() * ln10x.Sum()));
            a = (( Convert.ToSingle(cc) / переменая.gg ) * переменая.ober.Sum()) - ((b/переменая.gg) * ln10x.Sum());
            y = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum());
            for (int i = 0; i < переменая.gg; i++)
            {
                model[i] = Convert.ToSingle(Math.Abs((переменая.ober[i] - (a + b * Math.Log(переменая.novich[i]))) / (переменая.ober[i])));
                yyrav[i] = Convert.ToSingle( (переменая.ober[i] - (a + b * Math.Log(переменая.novich[i]))) * (переменая.ober[i] - (a + b * Math.Log(переменая.novich[i]))));
                yminusy[i] = Convert.ToSingle((переменая.ober[i] - y) * (переменая.ober[i] - y));
            }
            R = Convert.ToSingle(Math.Sqrt(Convert.ToSingle(cc) - (yyrav.Sum() / yminusy.Sum())));
            R2 = R * R;
            A = ((Convert.ToSingle(cc) / переменая.gg) * model.Sum() * Convert.ToSingle(ccc));
            Console.WriteLine(b);
            Console.WriteLine(a);
            Console.WriteLine(R);
            Console.WriteLine(R2);
            Console.WriteLine(A);

            sravenene[3] = Convert.ToSingle(R2);
            Per.a = Convert.ToString(Math.Round(a, 2));
            Per.b = Convert.ToString(Math.Round(b, 2));

            Per.nazvaniy = "Логарифмическая регрессия";
            Per.korele = Convert.ToString(Math.Round(R, 2));
            Per.dete = Convert.ToString(Math.Round(R2, 2));
            Per.appro = Convert.ToString(Math.Round(A, 2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;

            if (переменая.novich[0] + переменая.novich[1] >= 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.5);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] = kk;
                Per.trendy[i] = Convert.ToSingle(a + b* Math.Log(Per.trendx[i]));
                //Console.WriteLine(Per.trendy[i]);
                kk += plch;
            }
        }

        private void экспоненциальная_регрессия()
        {
            Per.proverka = 4;
            float a;
            float b;
            double R; // Коэффициент корреляции:
            double y; // 
            double R2;  // Коэффициент детерминации
            double A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;

            b = ( переменая.gg * ln10xlny.Sum() - переменая.novich.Sum() * ln10y.Sum()) / (переменая.gg * pow.Sum() - (переменая.novich.Sum() * переменая.novich.Sum()));
            a = ((Convert.ToSingle(cc) / переменая.gg) * ln10y.Sum()) - (b/переменая.gg * переменая.novich.Sum());
            y = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum());
            for (int i = 0; i < переменая.gg; i++)
            {
                model[i] = Convert.ToSingle(Math.Abs((переменая.ober[i] - (Math.Exp(a + b * переменая.novich[i])))) / (переменая.ober[i]));
                yyrav[i] = Convert.ToSingle((переменая.ober[i] - (Math.Exp(a + b * переменая.novich[i]))) * (переменая.ober[i] - (Math.Exp(a + b * переменая.novich[i]))));
                yminusy[i] = Convert.ToSingle((переменая.ober[i] - y) * (переменая.ober[i] - y));
            }
            R = Convert.ToSingle(Math.Sqrt(Convert.ToSingle(cc) - (yyrav.Sum() / yminusy.Sum())));
            R2 = R * R;
            A = ((Convert.ToSingle(cc) / переменая.gg) * model.Sum() * Convert.ToSingle(ccc));

            Console.WriteLine(b);
            Console.WriteLine(a);
            Console.WriteLine(R);
            Console.WriteLine(R2);
            Console.WriteLine(A);

            sravenene[4] = Convert.ToSingle(R2);
            Per.a = Convert.ToString(Math.Round(a, 2));
            Per.b = Convert.ToString(Math.Round(b, 2));

            Per.nazvaniy = "Экспоненциальная регрессия";
            Per.korele = Convert.ToString(Math.Round(R, 2));
            Per.dete = Convert.ToString(Math.Round(R2, 2));
            Per.appro = Convert.ToString(Math.Round(A, 2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;

            if (переменая.novich[0] + переменая.novich[1] >= 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.5);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] = kk;
                Per.trendy[i] = Convert.ToSingle((Math.Exp(a + b * Per.trendx[i])));
                //Console.WriteLine(Per.trendy[i]);
                kk += plch;
            }

        }

        private void гиперболическая_регрессия()
        {
            Per.proverka = 5;
            float a;
            float b;
            double R; // Коэффициент корреляции:
            double y; // 
            double R2;  // Коэффициент детерминации
            double A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;

            b = ((переменая.gg * ynax.Sum()) - (odinnax.Sum() * переменая.ober.Sum())) / ((переменая.gg * odinnax2.Sum()) - ((odinnax.Sum() * odinnax.Sum())));
            a = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum()) - ((b / переменая.gg) * odinnax.Sum());

            y = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum());
            for (int i = 0; i < переменая.gg; i++)
            {
                model[i] = Convert.ToSingle(Math.Abs((переменая.ober[i] - (a + (b / переменая.novich[i])) )) / (переменая.ober[i]));
                yyrav[i] = Convert.ToSingle((переменая.ober[i] - (a + (b / переменая.novich[i]))) * (переменая.ober[i] - (a + (b / переменая.novich[i]))));
                yminusy[i] = Convert.ToSingle((переменая.ober[i] - y) * (переменая.ober[i] - y));
            }
            R = Convert.ToSingle(Math.Sqrt(Convert.ToSingle(cc) - (yyrav.Sum() / yminusy.Sum())));
            R2 = R * R;
            A = ((Convert.ToSingle(cc) / переменая.gg) * model.Sum() * Convert.ToSingle(ccc));


            Console.WriteLine(b);
            Console.WriteLine(a);
            Console.WriteLine(R);
            Console.WriteLine(R2);
            Console.WriteLine(A);

            sravenene[5] = Convert.ToSingle( R2);

            Per.a = Convert.ToString(Math.Round(a, 2));
            Per.b = Convert.ToString(Math.Round(b, 2));

            Per.nazvaniy = "Гиперболическая регрессия";
            Per.korele = Convert.ToString(Math.Round(R, 2));
            Per.dete = Convert.ToString(Math.Round(R2,2));
            Per.appro = Convert.ToString(Math.Round(A, 2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;

            if (переменая.novich[0] + переменая.novich[1] >= 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.5);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] = kk;
                Per.trendy[i] = Convert.ToSingle((a + (b /Per.trendx[i])));
                //Console.WriteLine(Per.trendy[i]);
                kk += plch;
            }

        }

        private void кубическая_регрессия()
        {
            Per.proverka = 6;
            float a;
            float b;
            float c;
            float d;
            float det;
            float deta;
            float detb;
            float detc;
            float detd;
            double R; // Коэффициент корреляции:
            double y; // 
            double R2;  // Коэффициент детерминации
            double A; // Средняя ошибка аппроксимации
            float kk;
            int ten;
            float plch;
            float q;

            det = Convert.ToSingle((pow3.Sum() * ( (pow3.Sum() * pow3.Sum() * pow3.Sum()) + (pow.Sum()*pow.Sum() * pow5.Sum()) + (переменая.novich.Sum() * pow4.Sum() * pow4.Sum()) - (переменая.novich.Sum() * pow3.Sum() * pow5.Sum()) - (pow.Sum() * pow4.Sum()*pow3.Sum()) - (pow3.Sum() * pow.Sum() * pow4.Sum()))) - (pow.Sum() * ( (pow4.Sum() * pow3.Sum() * pow3.Sum()) + (pow.Sum() * pow.Sum() * pow6.Sum()) + (переменая.novich.Sum() * pow5.Sum() * pow4.Sum()) - (переменая.novich.Sum() * pow3.Sum() * pow6.Sum()) - (pow.Sum() * pow5.Sum() * pow3.Sum()) - (pow4.Sum() * pow.Sum() * pow4.Sum()))) + (переменая.novich.Sum() * ((pow4.Sum() * pow4.Sum() * pow3.Sum()) + (pow3.Sum() * pow.Sum() * pow6.Sum()) + (переменая.novich.Sum() * pow5.Sum() * pow5.Sum()) - (переменая.novich.Sum() * pow4.Sum() * pow6.Sum()) - (pow3.Sum() * pow5.Sum() * pow3.Sum()) - (pow4.Sum() * pow5.Sum() * pow.Sum()))) - (переменая.gg * ( (pow4.Sum() * pow4.Sum() * pow4.Sum())+( pow3.Sum() * pow3.Sum()* pow6.Sum())+(pow.Sum() * pow5.Sum() * pow5.Sum())-( pow.Sum() * pow4.Sum() * pow6.Sum())-(pow3.Sum() * pow5.Sum() * pow4.Sum())-( pow4.Sum() * pow3.Sum() * pow5.Sum())  ))   );
            deta = Convert.ToSingle((переменая.ober.Sum() * ((pow3.Sum() * pow3.Sum() * pow3.Sum()) + (pow.Sum() * pow.Sum() * pow5.Sum()) + (переменая.novich.Sum() * pow4.Sum() * pow4.Sum()) - (переменая.novich.Sum() * pow3.Sum() * pow5.Sum()) - (pow.Sum() * pow4.Sum() * pow3.Sum()) - (pow3.Sum() * pow.Sum() * pow4.Sum()))) - (pow.Sum() * ((ee.Sum() * pow3.Sum() * pow3.Sum()) + (pow.Sum() * pow.Sum() * x3y.Sum()) + (переменая.novich.Sum() * x2y.Sum() * pow4.Sum()) - (переменая.novich.Sum() * pow3.Sum() * x3y.Sum()) - (pow.Sum() * x2y.Sum() * pow3.Sum()) - (pow4.Sum() * pow.Sum() * ee.Sum()))) + (переменая.novich.Sum() * ((ee.Sum() * pow4.Sum() * pow3.Sum()) + (pow3.Sum() * pow.Sum() * x3y.Sum()) + (переменая.novich.Sum() * x2y.Sum() * pow5.Sum()) - (переменая.novich.Sum() * pow4.Sum() * x3y.Sum()) - (pow3.Sum() * x2y.Sum() * pow3.Sum()) - (ee.Sum() * pow5.Sum() * pow.Sum()))) - (переменая.gg * ((ee.Sum() * pow4.Sum() * pow4.Sum()) + (pow3.Sum() * pow3.Sum() * x3y.Sum()) + (pow.Sum() * x2y.Sum() * pow5.Sum()) - (pow.Sum() * pow4.Sum() * x3y.Sum()) - (pow3.Sum() * x2y.Sum() * pow4.Sum()) - (ee.Sum() * pow3.Sum() * pow5.Sum()))));
            detb = Convert.ToSingle((pow3.Sum() * ((ee.Sum() * pow3.Sum() * pow3.Sum()) + (pow.Sum() * pow.Sum() * x3y.Sum()) + (переменая.novich.Sum() * x2y.Sum() * pow4.Sum()) - (переменая.novich.Sum() * pow3.Sum() * x3y.Sum()) - (pow.Sum() * x2y.Sum() * pow3.Sum()) - (ee.Sum() * pow.Sum() * pow4.Sum()))) - (переменая.ober.Sum() * ((pow4.Sum() * pow3.Sum() * pow3.Sum()) + (pow.Sum() * pow.Sum() * pow6.Sum()) + (переменая.novich.Sum() * pow5.Sum() * pow4.Sum()) - (переменая.novich.Sum() * pow3.Sum() * pow6.Sum()) - (pow.Sum() * pow5.Sum() * pow3.Sum()) - (pow4.Sum() * pow.Sum() * pow4.Sum()))) + (переменая.novich.Sum() * ((pow4.Sum() * x2y.Sum() * pow3.Sum()) + (ee.Sum() * pow.Sum() * pow6.Sum()) + (переменая.novich.Sum() * x3y.Sum() * pow5.Sum()) - (переменая.novich.Sum() * x2y.Sum() * pow6.Sum()) - (ee.Sum() * pow5.Sum() * pow3.Sum()) - (pow4.Sum() * x3y.Sum() * pow.Sum()))) - (переменая.gg * ((pow4.Sum() * x2y.Sum() * pow4.Sum()) + (ee.Sum() * pow3.Sum() * pow6.Sum()) + (pow.Sum() * x3y.Sum() * pow5.Sum()) - (pow.Sum() * x2y.Sum() * pow6.Sum()) - (ee.Sum() * pow5.Sum() * pow4.Sum()) - (pow4.Sum() * pow3.Sum() * x3y.Sum()))));
            detc = Convert.ToSingle((pow3.Sum() * ((pow3.Sum() * x2y.Sum() * pow3.Sum()) + (pow.Sum() * ee.Sum() * pow5.Sum()) + (переменая.novich.Sum() * x3y.Sum() * pow4.Sum()) - (переменая.novich.Sum() * x2y.Sum() * pow5.Sum()) - (ee.Sum() * pow4.Sum() * pow3.Sum()) - (pow3.Sum() * pow.Sum() * x3y.Sum()))) - (pow.Sum() * ((pow4.Sum() * x2y.Sum() * pow3.Sum()) + (pow.Sum() * ee.Sum() * pow6.Sum()) + (переменая.novich.Sum() * pow5.Sum() * x3y.Sum()) - (переменая.novich.Sum() * x2y.Sum() * pow6.Sum()) - (ee.Sum() * pow5.Sum() * pow3.Sum()) - (x3y.Sum() * pow.Sum() * pow4.Sum()))) + (переменая.ober.Sum() * ((pow4.Sum() * pow4.Sum() * pow3.Sum()) + (pow3.Sum() * pow.Sum() * pow6.Sum()) + (переменая.novich.Sum() * pow5.Sum() * pow5.Sum()) - (переменая.novich.Sum() * pow4.Sum() * pow6.Sum()) - (pow3.Sum() * pow5.Sum() * pow3.Sum()) - (pow4.Sum() * pow5.Sum() * pow.Sum()))) - (переменая.gg * ((pow4.Sum() * pow4.Sum() * x3y.Sum()) + (x2y.Sum() * pow3.Sum() * pow6.Sum()) + (ee.Sum() * pow5.Sum() * pow5.Sum()) - (ee.Sum() * pow4.Sum() * pow6.Sum()) - (pow3.Sum() * pow5.Sum() * x3y.Sum()) - (pow4.Sum() * x2y.Sum() * pow5.Sum()))));
            detd = Convert.ToSingle((pow3.Sum() * ((pow3.Sum() * pow3.Sum() * x3y.Sum()) + (x2y.Sum() * pow.Sum() * pow5.Sum()) + (ee.Sum() * pow4.Sum() * pow4.Sum()) - (ee.Sum() * pow3.Sum() * pow5.Sum()) - (pow.Sum() * pow4.Sum() * x3y.Sum()) - (pow3.Sum() * x2y.Sum() * pow4.Sum()))) - (pow.Sum() * ((pow4.Sum() * pow3.Sum() * x3y.Sum()) + (x2y.Sum() * pow.Sum() * pow6.Sum()) + (ee.Sum() * pow5.Sum() * pow4.Sum()) - (ee.Sum() * pow3.Sum() * pow6.Sum()) - (pow.Sum() * pow5.Sum() * x3y.Sum()) - (pow4.Sum() * x2y.Sum() * pow4.Sum()))) + (переменая.novich.Sum() * ((pow4.Sum() * pow4.Sum() * x3y.Sum()) + (pow3.Sum() * x2y.Sum() * pow6.Sum()) + (ee.Sum() * pow5.Sum() * pow5.Sum()) - (ee.Sum() * pow4.Sum() * pow6.Sum()) - (pow3.Sum() * pow5.Sum() * x3y.Sum()) - (pow4.Sum() * pow5.Sum() * x2y.Sum()))) - (переменая.ober.Sum() * ((pow4.Sum() * pow4.Sum() * pow4.Sum()) + (pow3.Sum() * pow3.Sum() * pow6.Sum()) + (pow.Sum() * pow5.Sum() * pow5.Sum()) - (pow.Sum() * pow4.Sum() * pow6.Sum()) - (pow3.Sum() * pow5.Sum() * pow4.Sum()) - (pow4.Sum() * pow3.Sum() * pow5.Sum()))));

            a = deta / det;
            b = detb / det;
            c = detc / det;
            d = detd / det;


            y = ((Convert.ToSingle(cc) / переменая.gg) * переменая.ober.Sum());
            for (int i = 0; i < переменая.gg; i++)
            {
                model[i] = Convert.ToSingle(Math.Abs((переменая.ober[i] - (a * Math.Pow(переменая.novich[i], 3) + b * Math.Pow(переменая.novich[i], 2) + c * переменая.novich[i] + d))) / (переменая.ober[i]));
                yyrav[i] = Convert.ToSingle((переменая.ober[i] - (a * Math.Pow(переменая.novich[i], 3) + b * Math.Pow(переменая.novich[i], 2) + c * переменая.novich[i] + d)) * (переменая.ober[i] - (a * Math.Pow(переменая.novich[i], 3) + b * Math.Pow(переменая.novich[i], 2) + c * переменая.novich[i] + d)));
                yminusy[i] = Convert.ToSingle((переменая.ober[i] - y) * (переменая.ober[i] - y));
            }
            R = Convert.ToSingle(Math.Sqrt(Convert.ToSingle(cc) - (yyrav.Sum() / yminusy.Sum())));
            R2 = R * R;
            A = ((Convert.ToSingle(cc) / переменая.gg) * model.Sum() * Convert.ToSingle(ccc));

            Console.WriteLine(det);
            Console.WriteLine(detb);
            Console.WriteLine(d);
            Console.WriteLine(x2y.Sum());
            Console.WriteLine(x3y.Sum());
            Console.WriteLine(ee.Sum());
            

            sravenene[6] = Convert.ToSingle(R2);

            Per.a = Convert.ToString(Math.Round(a, 2));
            Per.b = Convert.ToString(Math.Round(b, 2));
            Per.c = Convert.ToString(Math.Round(c, 2));
            Per.d = Convert.ToString(Math.Round(d, 2));

            Per.nazvaniy = "Кубическая регрессия";
            Per.korele = Convert.ToString(Math.Round(R, 2));
            Per.dete = Convert.ToString(Math.Round(R2, 2));
            Per.appro = Convert.ToString(Math.Round(A, 2));

            ten = 0;
            q = 0;
            ten = переменая.gg;
            kk = 0;
            plch = 0;

            if (переменая.novich[0] + переменая.novich[1] >= 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.4);
                plch = Convert.ToSingle(0.1);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11;
                    }
                    else
                    {
                        Per.kol = q * 10;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 10;
                    }
                    else
                    {
                        Per.kol = q * 9;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] >= 0.2 && переменая.novich[0] + переменая.novich[1] < 2)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.025);
                plch = Convert.ToSingle(0.01);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.1);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 110;
                    }
                    else
                    {
                        Per.kol = q * 100;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 100;
                    }
                    else
                    {
                        Per.kol = q * 90;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.2 && переменая.novich[0] + переменая.novich[1] > 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.005);
                plch = Convert.ToSingle(0.001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.01);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
                else
                {
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 1100;
                    }
                    else
                    {
                        Per.kol = q * 1000;
                    }
                }
            }
            if (переменая.novich[0] + переменая.novich[1] <= 0.02)
            {
                kk = Convert.ToSingle(переменая.novich[0] - 0.001);
                plch = Convert.ToSingle(0.0001);
                q = Convert.ToSingle(переменая.novich[ten - 1] + 0.001);
                if (переменая.ober[ten - 1] >= 1)
                {
                    if (переменая.novich[ten - 1] >= переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
                else
                {
                    Console.WriteLine(q);
                    if (переменая.novich[ten - 1] < переменая.ober[ten - 1])
                    {
                        Per.kol = q * 11500;
                    }
                    else
                    {
                        Per.kol = q * 10500;
                    }
                }
            }
            for (int i = 0; i <= Per.kol; i++)
            {
                Per.trendx[i] = kk;
                Per.trendy[i] = Convert.ToSingle((a * Math.Pow(Per.trendx[i], 3) + b * Math.Pow(Per.trendx[i], 2) + c * Per.trendx[i] + d));
                //Console.WriteLine(Per.trendy[i]);
                kk += plch;
            }
        }

        private void оптимальный_выбор()
        {
            float a;
            Линейная_регрессия();
            логарифмическая_регрессия();
            if (переменая.novich.Count() >= 4)
            {
                квадратичная_регрессия();
            }
            
            гиперболическая_регрессия();
            степенная_регрессия();
            экспоненциальная_регрессия();
            if (переменая.novich.Count() >= 5)
            {
                кубическая_регрессия();
            }
            
            a = sravenene.Max();
            if (sravenene[0] == a && sravenene[1] == a && sravenene[2] == a && sravenene[3] == a && sravenene[4] == a && sravenene[5] == a && sravenene[6] == a)
            {
                квадратичная_регрессия();
            }
            else
            {
                if (sravenene[0] == a && a != 1)
                {
                    Линейная_регрессия();
                }
                if (sravenene[1] == a )
                {
                    квадратичная_регрессия();
                }
                if (sravenene[2] == a && a != 1)
                {
                    степенная_регрессия();
                }
                if (sravenene[3] == a && a != 1)
                {
                    логарифмическая_регрессия();
                }
                if (sravenene[4] == a && a != 1) 
                {
                    экспоненциальная_регрессия();
                }
                if (sravenene[5] == a && a != 1)
                {
                    гиперболическая_регрессия();
                }
                if (sravenene[6] == a && переменая.novich.Count() > 5 && a != 1)
                {
                    кубическая_регрессия();
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Button_Click_Next_Page_6();
            // график();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Линейная_регрессия();
            MainWindow.Instance.Button_Click_Next_Page_6();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (переменая.gg >= 3)
            {
                квадратичная_регрессия();
                MainWindow.Instance.Button_Click_Next_Page_6();
            }
            else
            {
                Massage = "Допущена ошибка! ";
                Massage_contin = "Нельзя посчитать квадратичную регрессию, так как количество образцов меньше 3";
                Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                error.ShowDialog();
            }
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            степенная_регрессия();
            MainWindow.Instance.Button_Click_Next_Page_6();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            логарифмическая_регрессия();
            MainWindow.Instance.Button_Click_Next_Page_6();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            экспоненциальная_регрессия();
            MainWindow.Instance.Button_Click_Next_Page_6();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            гиперболическая_регрессия();
            MainWindow.Instance.Button_Click_Next_Page_6();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            оптимальный_выбор();
            MainWindow.Instance.Button_Click_Next_Page_6();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (переменая.gg >=4)
            {
                кубическая_регрессия();
                MainWindow.Instance.Button_Click_Next_Page_6();
            }
            else
            {
                Massage = "Допущена ошибка! ";
                Massage_contin = "Нельзя посчитать кубическую регрессию, так как количество образцов меньше 4";
                Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                error.ShowDialog();
            }
            
        }
    }
}
