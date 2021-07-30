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
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.Axes;


namespace ProjectX
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
     public class CollectionRows
     { 
      public int CollectionRows_Obr { get; set; }
        public string CollectionRows_Nov { get; set; }
        public string CollectionRows_V { get; set; }
       
    }
    public  static class переменая
    {
        public static int gg { get; set; } // количество образцов
        public static float[] novich { get; set; } // массив для Nov
        public static float[] ober { get; set; } // массив для объема
        public static int[] ggg { get; set; } // массив для количества образцов
    }
    public static class Per
    {
        public static float[] trendx { get; set; } // x для линейной регресси
        public static float[] trendy { get; set; } // y для линейной регресси
        public static float kol { get; set; }
        public static string korele { get; set; } //  кореллиация
        public static string dete { get; set; } // детарминация
        public static string appro{ get; set; } // аппрксимация
        public static string a { get; set; } // уравнение
        public static string b { get; set; }
        public static string c { get; set; }
        public static string d { get; set; }
        public static int proverka{ get; set; } // проверка на тип линии
        public static string nazvaniy { get; set; }// название для графиков
    }
    public partial class Page2 : Page
    {

        public IList<DataPoint> Points { get; set; }
        public List<DataPoint> Pointstwo { get; set; }
        public PlotModel Model { get; private set; }

        public Page2()
        {
           InitializeComponent();
            butt.IsEnabled = false;
            change.IsEnabled = false;
            delete.IsEnabled = false;
            kk = 0;
            N = 0;
            переменая.novich = new float[100];
            переменая.ober = new float[100];
            переменая.ggg = new int[100];
            float[] novi = new float[100];
            float[] obem = new float[100];
            Per.trendx = new float[1000000];
            Per.trendy = new float[1000000];
            // na = Convert.ToString(k);
            //Dannye.Content += na;
        }
      
        int N;
        bool oshibka = false;
         public string ww = ""; // второй_столбец
        string qq = ""; // третий_столбец
         int kk; // счетчик по умолчанию 0
        string Taitle = "";
        string Massage = "";
        string Massage_Bold = "";
        string Massage_contin = "";

         float[] novi = new float[100];  // массив нов
        float[] obem = new float[100]; // массив объем
        int[] obraz = new int[100]; //массив образцов



       

        public void add_Click(object sender, RoutedEventArgs e )
        {
            oshibka = false;
            if(Obrazq.Text.Length != 0)
                {
                if (Convert.ToInt32(Obrazq.Text) == 0)
                {
                    Massage = "Допущена ошибка! ";
                    Massage_contin = "Нельзя начинать номер образца с 0";
                    Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                    error.ShowDialog();
                }
                else
                {
                    if (Novq.Text.Length != 0)
                    {
                        if (Vq.Text.Length != 0)
                        {
                            if (kk == 0)
                            {
                                добавление_в_таблицу();
                                очистка_текстовых_полей();
                                butt.IsEnabled = true;
                                change.IsEnabled = true;
                                delete.IsEnabled = true;

                            }
                            else

                            {
                                for (int i = 0; i < kk; i++)
                                {
                                    if (obraz[i] == Convert.ToInt32(Obrazq.Text))
                                    {
                                        oshibka = true;
                                        // Taitle = "Ошибка № 14";
                                        Massage = "Допущена ошибка! ";
                                        //Massage_Bold = "\"№ образца!\"";
                                        Massage_contin = "Такой образец с \"№ " + obraz[i] + "\" уже существует в таблице!";
                                        Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                                        error.ShowDialog();
                                        break;
                                        //ошибка есть похожий образец
                                    }
                                }
                                if (oshibka == false)
                                {
                                    добавление_в_таблицу();
                                    очистка_текстовых_полей();
                                    butt.IsEnabled = true;
                                    change.IsEnabled = true;
                                    delete.IsEnabled = true;

                                }



                            }


                        }
                        else
                        {
                            Massage = "Допущена ошибка! ";
                            Massage_contin = "Вы не ввели объем!";
                            Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        Massage = "Допущена ошибка! ";
                        Massage_contin = "Вы не ввели процентное содержание новомила!";
                        Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                        error.ShowDialog();
                    }
                } 
            }
            else
            {
                Massage = "Допущена ошибка! ";
                Massage_contin = "Вы не ввели номер образца!";
                Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                error.ShowDialog();


            }
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (Obrazec.SelectedIndex != -1) 

            {
               
                int row = Obrazec.SelectedIndex;
                Obrazq.Text = Convert.ToString(obraz[row]);
                Novq.Text = Convert.ToString(переменая.novich[row]);
                Vq.Text = Convert.ToString(переменая.ober[row]);
               
                for (int i = Obrazec.SelectedIndex; i <= kk; i++)
                {
                    novi[i] = novi[i + 1];
                    obem[i] = obem[i + 1];
                    obraz[i] = obraz[i + 1];
                    переменая.novich[i] = переменая.novich[i + 1];
                    переменая.ober[i] = переменая.ober[i + 1];
                    переменая.ggg[i] = переменая.ggg[i + 1];
                }
                Obrazec.Items.Remove(Obrazec.SelectedItem);
            }
            else
            {
                Massage = "Допущена ошибка! ";
                Massage_contin = "Вы не выделили строку, которую хотите изменить!";
                Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                error.ShowDialog();
            }
               


        }
       
        
        
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (kk != 0) // проверка на заполненость таблицы
            {
                if (Obrazec.SelectedIndex != -1) // проверка на выделение строки в таблице
                {
                    kk--;
                    //int i = Obrazec.SelectedIndex;
                    for ( int i = Obrazec.SelectedIndex; i <= kk; i++)// i это выбранная строка, потом i сравниваеться с количесовм срок
                    {
                        novi[i] = novi[i + 1]; //   1(0) 2(1) 3(2) 4(3) 5(4)
                        obem[i] = obem[i + 1]; // 1(0) 2(1) 4(2) 5(3)
                        obraz[i] = obraz[i + 1];
                        переменая.novich[i] = переменая.novich[i + 1];
                        переменая.ober[i] = переменая.ober[i + 1];
                        переменая.ggg[i] = переменая.ggg[i + 1];
                    }

                    Obrazec.Items.Remove(Obrazec.SelectedItem);
                }
                else
                {
                    Massage = "Допущена ошибка! ";
                    Massage_contin = "Вы не выделили строку, которую хотите удалить!";
                    Window1 error = new Window1(Taitle, Massage, Massage_Bold, Massage_contin);
                    error.ShowDialog();
                }
            }
        }


        private void очистка_текстовых_полей()
        {
            Novq.Text = "";
            Vq.Text = "";
            Obrazq.Text = "";
        }

         private void добавление_в_таблицу()
        {
            N = Convert.ToInt32(Obrazq.Text);
            ww = Novq.Text;
            qq = Vq.Text;
            CollectionRows information = new CollectionRows();
            information.CollectionRows_Obr = Convert.ToInt32(N);
            information.CollectionRows_Nov = Convert.ToString(ww);
            information.CollectionRows_V = Convert.ToString(qq);
            Obrazec.Items.Add(information);
            obraz[kk] = Convert.ToInt32(N);
            novi[kk] = Convert.ToSingle(ww);
            obem[kk] = Convert.ToSingle(qq);
            переменая.novich[kk] = Convert.ToSingle(ww);
            переменая.ober[kk] = Convert.ToSingle(qq);
            переменая.gg = Convert.ToInt32(N);
            переменая.ggg[kk] = N;
            kk++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            переменая.gg = Convert.ToInt32(kk);
            MainWindow.Instance.Button_Click_Next_Page_3();
           // переменая.novich = переменая.novich.OrderBy(x => x).ToArray();
            
            

        }
        private void TB_KeyPress_Another(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true;
            }
        }
        private void проверка_на_значения(object sender, KeyEventArgs e)
        {
            TextBox temp_text = sender as TextBox;
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                if (temp_text.Text == "1000")
                {
                    temp_text.MaxLength = 5;
                    if (e.Key == Key.D0)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.OemComma)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 5;
                }
            }
        }
        private void TB_KeyPressDown(object sender, KeyEventArgs e)
        {
            TextBox temp_text = sender as TextBox;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            проверка_на_значения(sender, e);
            string s;
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                s = temp_text.Text.Substring(temp_text.Text.Length - 1, 1);
                if (s == ",")
                {
                    if (temp_text.Text.Length == 5 && s == ",")
                    {
                        temp_text.MaxLength = 8;
                    }
                    else
                    {
                        temp_text.MaxLength = 3;
                        if (temp_text.Text.Length == 3 && s == ",")
                        {
                            temp_text.MaxLength = 7;
                        }
                        else
                        {
                            temp_text.MaxLength = 3;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 3;
                    проверка_на_значения(sender, e);
                }
            }
            Key k1 = e.Key;
            if (k1 == Key.OemPeriod)
            {
                k1 = Key.OemComma;
            }
            if (k1 == Key.OemComma)
            {

                if (temp_text.Text.IndexOf(",") != -1 || (temp_text.Text == ""))
                {
                    e.Handled = true;
                }
                else
                {
                    temp_text.Text += ",";
                    temp_text.MaxLength =6;
                    temp_text.CaretIndex = temp_text.Text.Length;
                }
            }
        }

        private void TB_KeyPress_Nomer(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TB_KeyPressDown_Nomer(object sender, KeyEventArgs e)
        {
            TextBox temp_text = sender as TextBox;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                if (temp_text.Text == "100")
                {
                    temp_text.MaxLength = 4;
                    if (e.Key == Key.D0)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.Key == Key.Back || e.Key == Key.Tab)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 3;
                }
            }
        }

        private void проверка_на_значения1(object sender, KeyEventArgs e)
        {
            TextBox temp_text = sender as TextBox;
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                if (temp_text.Text == "10")
                {
                    temp_text.MaxLength = 3;
                    if (e.Key == Key.D0)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.OemComma)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 2;
                }
            }
        }
        private void TB_KeyPressDown1(object sender, KeyEventArgs e)
        {
            TextBox temp_text = sender as TextBox;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            проверка_на_значения1(sender, e);
            string s;
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                s = temp_text.Text.Substring(temp_text.Text.Length - 1, 1);
                if (s == ",")
                {
                    if (temp_text.Text.Length == 2 && s == ",")
                    {
                        temp_text.MaxLength = 5;
                    }
                    else
                    {
                        temp_text.MaxLength = 4;
                        if (temp_text.Text.Length == 3 && s == ",")
                        {
                            temp_text.MaxLength = 5;
                        }
                        else
                        {
                            temp_text.MaxLength = 4;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 4;
                    проверка_на_значения1(sender, e);
                }
            }
            Key k1 = e.Key;
            if (k1 == Key.OemPeriod)
            {
                k1 = Key.OemComma;
            }
            if (k1 == Key.OemComma)
            {

                if (temp_text.Text.IndexOf(",") != -1 || (temp_text.Text == ""))
                {
                    e.Handled = true;
                }
                else
                {
                    temp_text.Text += ",";
                    temp_text.MaxLength = 6;
                    temp_text.CaretIndex = temp_text.Text.Length;
                }
            }
        }

    }

   
}
