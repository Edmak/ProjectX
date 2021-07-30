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
    public class Class1
    {
        float arfx,arfy,stepx, stepy;
        float[] x = new float[100];
        float[] y = new float[100];
        float temp,temp1;
        public Class1()
            {
           
                var tmp = new PlotModel { Title = "График зависимости Nov от V", TitleFontSize = 20 };
            

            // Create two line series (markers are hidden by default)
            var series1 = new LineSeries {  MarkerType = MarkerType.Circle, LineStyle = LineStyle.Solid,   };//Title = "Series 1"
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
            var rtq = new LinearAxis { Title = "Nov, % " , Position = AxisPosition.Bottom , FontSize = 16};
           


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
                        if(переменая.ober[i] > переменая.ober[j])
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
            //точка();
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
                //for (int i = 0; i < переменая.gg*10; i++)
                //{
                //    if (переменая.novich[i] != 0)
                //        series1.Points.Add(new DataPoint(x[i], y[i]));
                //    else
                //    {
                //        series1.Points.Add(new DataPoint(x[i + 1], y[i + 1]));
                //        i++;
                //    }

                //}
                /* series1.Points.Add(new DataPoint(0, 0));
                 series1.Points.Add(new DataPoint(переменая.gg, 18));
                 series1.Points.Add(new DataPoint(20, 12));
                 series1.Points.Add(new DataPoint(30, 8));
                 series1.Points.Add(new DataPoint(40, 15));*/

                /*var series2 = new LineSeries { Title = "Series 2", MarkerType = MarkerType.Square };
                series2.Points.Add(new DataPoint(0, 4));
                series2.Points.Add(new DataPoint(10, 12));
                series2.Points.Add(new DataPoint(20, 16));
                series2.Points.Add(new DataPoint(30, 25));
                series2.Points.Add(new DataPoint(40, 5));*/


                // Add the series to the plot model
                tmp.Series.Add(series1);
            //series1.XAxis.Position{B };
            tmp.Axes.Add(rt);
            tmp.Axes.Add(rtq);
            //tmp.Series.Add(series2);

            // Axes are created automatically if they are not defined

            // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
            this.Model = tmp;

        }

        private void точка()
        {
          for (int i = 0; i < переменая.gg; i++)
            {
               // if (переменая.novich[i+1] >= переменая.ober[i+1])
              //  {
                   arfx = (переменая.novich[i] - переменая.novich[i])/2;
                    stepx = переменая.novich[i + 1] - переменая.novich[i] / 10;
                    stepy = (переменая.ober[i + 1] - переменая.ober[i])/ 10;
                    x[i] = переменая.novich[i];
                    y[i] = переменая.ober[i];
                    for (int j = 1; j <= 10; j++)
                    {
                        x[j] = x[j - 1] + stepx*2;
                        y[j] = y[j - 1] + stepy*2;
                    }

              //  }
              //  else
              //  {

             //   }
            }
          


        }
        public PlotModel Model { get; private set; }
    }
}
