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
       static Random r = new Random(DateTime.Now.Millisecond);
        public static bool CheckForAdd( List<Bus> L1 , string num,int D, ref DateTime date)
        {
            //int counter = 0;
            bool isEmpty = !L1.Any();
            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is already a bus like this
                    {
                        return false;

                    }

                }
            }
            
             if ((date.Year < 2018 && D == 7) || (date.Year > 2018 && D == 8))
                {
                    return true;
                }
            
            else
                return false;



        }
       public static void Checkforchoose(List<Bus> L1, string num)
        {
            bool isEmpty = !L1.Any();

           // bool b = false;
            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is already a bus like this
                    {
                        DateTime currentDate = DateTime.Now;
                        //רק אם לא עברה שנה או מקסימום שנה מהטיפול הקודם
                        if ((bus.ProLastDate.Year == currentDate.Year) || ((bus.ProLastDate.Year + 1 == currentDate.Year) && (12 - bus.ProLastDate.Month + currentDate.Month <= 12)))
                        {
                            double g = r.NextDouble(); //מגרילים מס רנדומלי עם המרה לדאבל
                                                       //bool b = Double.TryParse(r, out double g);
                            if (bus.ProKilometrathAfterTipul + g <= 20000)
                            {
                                bus.ProKilometrath += g;
                                bus.ProKilometrathAfterTipul +=g;//uptade the relevant fields

                            }
                            else
                                Console.WriteLine("The bus cannot make the trip");

                        }
                        else
                            Console.WriteLine("The bus cannot make the trip");

                        break;
                    }
                    else
                        Console.WriteLine("The bus does not exist in the system");

                }
            }

            else
            {
                Console.WriteLine("The bus does not exist in the system");
                //return false;
            }

        }
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
                        string num = Console.ReadLine();//מס רישוי
                        DateTime date;//תאריך תחילת פעילות
                        string s = Console.ReadLine();
                        int D = num.Length;
                         bool b= DateTime.TryParse(s, out  date);//קיבלתי מהמשתמש קלט סטרינג והמרתי
                        if (b)
                        {
                            if(Program.CheckForAdd( L1, num,D,ref  date))
                            {
                                Bus B = new Bus();
                                B.ProNumBus = s;
                                B.ProStartDate = date;
                            }   

                        }
                        else
                            Console.WriteLine("Error.insert again");
                    }
                    break;
                case Options.Choose:
                    {
                        Console.WriteLine("please enter Licensing number");
                        string num = Console.ReadLine();//מס רישוי
                        Program.Checkforchoose(L1, num);




                    }
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
