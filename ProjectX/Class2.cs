using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    public class Class2
    {

        float temp, temp1;
        public Class2()
        {

            var tmp = new PlotModel { Title = " ", TitleFontSize = 20 };


            // Create two line series (markers are hidden by default)
            var series1 = new LineSeries { MarkerType = MarkerType.Circle, LineStyle = LineStyle.Solid, Title = "Исходный график "};//Title = "Series 1"
            var series2 = new LineSeries { MarkerType = MarkerType.None, LineStyle = LineStyle.Dash,Title = "График регрессии" };//Title = "Series 1"
            // переменая.novich = переменая.novich.OrderBy(x => x).ToArray();
            //  Array.Sort(переменая.novich);
            /*for (int i = 0; i < переменая.gg; i++)
            {
                if(переменая.novich[i] < переменая.novich[i+1])
                {
                    a = переменая.novich[i];
                    переменая.novich[i] = переменая.novich[i + 1];
                    переменая.novich[i + 1] = a;


                }

            }*/
            var rt = new LinearAxis { Title = "V, см^3/г", Position = AxisPosition.Left, FontSize = 16 };
            var rtq = new LinearAxis { Title = "Nov, % ", Position = AxisPosition.Bottom, FontSize = 16 };



            for (int i = 0; i < переменая.gg - 1; i++) // сортировка массива от мин к макс
            {
                for (int j = i + 1; j < переменая.gg; j++)
                {
                    if (переменая.novich[i] > переменая.novich[j])
                    {
                        temp = переменая.novich[i];
                        переменая.novich[i] = переменая.novich[j];
                        переменая.novich[j] = temp;

                        temp1 = переменая.ober[i];
                        переменая.ober[i] = переменая.ober[j];
                        переменая.ober[j] = temp1;
                    }
                }
            }
            for (int i = 0; i < переменая.gg - 1; i++)  // 1 3 2   1 2 3        1 2 3 
            {                                           // 1 2 3   1 2 3        1 3 2
                for (int j = i + 1; j < переменая.gg; j++)
                {
                    if (переменая.novich[i] == переменая.novich[j])
                    {
                        if (переменая.ober[i] > переменая.ober[j])
                        {
                            temp = переменая.novich[i];
                            переменая.novich[i] = переменая.novich[j];
                            переменая.novich[j] = temp;

                            temp1 = переменая.ober[i];
                            переменая.ober[i] = переменая.ober[j];
                            переменая.ober[j] = temp1;
                        }

                    } 
                }
            }

            for (int i = 0; i < переменая.gg; i++)
            {
                if (переменая.novich[i] != 0)
                    series1.Points.Add(new DataPoint(переменая.novich[i], переменая.ober[i]));
                else
                {
                    series1.Points.Add(new DataPoint(переменая.novich[i + 1], переменая.ober[i + 1]));
                    i++;
                }

            }
            for (int i = 0; i < Per.kol; i++)
            {
                series2.Points.Add(new DataPoint(Per.trendx[i], Per.trendy[i]));
            }
     
            tmp.Series.Add(series1);
            tmp.Series.Add(series2);

            tmp.Axes.Add(rt);
            tmp.Axes.Add(rtq);
           
            this.Model = tmp;

        }
        public PlotModel Model { get; private set; }
    }
}
