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

namespace dotNet5781_03B_2382_5685
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random(DateTime.Now.Millisecond);

        public MainWindow()
        {
            List<Bus> L1 = new List<Bus>();
            DateTime d;
            for (int i = 0; i < 10; i++)
            {
                string s;
                /*int num= r.Next(1000000, 99999999);//randomaly number of licence
               
                string s = num.ToString();
                if (s.Length==7)//7 DIGITS
                {
                     d = new DateTime(r.Next(31), r.Next(13), r.Next(2018));//random for date
                }
                else if(s.Length==8)//8 digits
                {
                    d = new DateTime(r.Next(31), r.Next(13), r.Next(2022));
                }*/
                d = new DateTime(r.Next(31), r.Next(13), r.Next(1970, 2022));//random for date
                if (d.Year < 2018)
                {
                    int num = r.Next(1000000, 10000000);
                    s = num.ToString();

                }
                else
                {
                    int num = r.Next(10000000, 100000000);
                    s = num.ToString();
                }

                if (Bus.AddBus(L1, s, s.Length, ref d))//if its ok to add
                {
                    Bus B = new Bus();

                    B.ProNumBus = s;
                    B.ProStartDate = d;
                    B.ProLastDate = d;//Update that last treatment date is the start date of activity
                    L1.Add(B);
                    //Console.WriteLine("succeed");
                }//אם תהיה בעיה---לטפל בזה---לגבי רנדומליזציה---
            }
            //taking care of other demands

            //L1[0].ProLastDate = DateTime.Now.Day;
           
            L1[2].ProFuel = 10;//ITS A SIGN THAT ITS NEED FUAL
            L1[3].ProFuel=20;//its a sign that its need tipul
            L1[4].ProKilometrathAfterTipul = 1850;//its a sign that its need tipul




            InitializeComponent();
        }
    }
}
