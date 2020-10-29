using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_01_2382_5685
{
    class Program
    {
        enum Options
        {Add,Choose,FuelOrCare,Show,Bye};
        static void Main(string[] args)
        {
            Options o;
            o = (Options)Console.Read();
            List<Bus>L1=new List<Bus>();

            switch (o)
            {
                case Options.Add:
                    { 
                        Console.WriteLine("please enter Licensing number and date of commencement of activity");
                        string num = Console.ReadLine();
                        DateTime date;
                        string s = Console.ReadLine();
                        int D = s.Length;
                         bool b= DateTime.TryParse(s, out  date);//קיבלתי מהמשתמש קלט סטרינג והמרתי
                        if (b)
                        {
                            if (date.Year < 2018 && D>7|| date.Year > 2018 &&D<8)
                            {
                                Console.WriteLine("error.insert again");
                            }

                                }







                    }
                    break;
                case Options.Choose:
                    break;
                case Options.FuelOrCare:
                    break;
                case Options.Show:
                    break;
                case Options.Bye:
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
