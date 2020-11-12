using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    
    class Program

    {
        enum Options
        { Insert, Deletion, Search, Printing, Exit };
        static int d = 0;
        static void Main(string[] args)
        {
            //1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16.....40
            List<BusLineStation> physical = new List<BusLineStation>();
            for (int i = 0; i < 40; i++)
            {
                physical[i] = new BusLineStation();//initialiation of 40 physical busstations
            }

            BusLines list = new BusLines();//object of class BusLines
            for (int i = 0; i < 11; i++)//initialitation of 11 lines
            {
                
            BusLineStation b = new BusLineStation();
            BusLineStation c = new BusLineStation();
       // 1 2 3 4 ...10
              list[i] = new BusLine(++d, b, c);
                for(int j=0;j<i*4;j++)
                {
                    List<BusLineStation> help = new List<BusLineStation>();
                    // help[j] = physical[j];
                    
                    list[i].ProStations[j] = physical[j];
                }
                // list[i].ProStations = help;
            }

            Console.WriteLine("Please enter one of the following options:");
            Console.WriteLine("0-Insert options");//הוספה
            Console.WriteLine("1-Deletion options");//מחיקה
            Console.WriteLine("2-Search options");//חיפוש
            Console.WriteLine("3-Printing options ");//הדפסה
            Console.WriteLine("4-Exit");//יציאה
            Console.WriteLine("insert your choise please");//
            Options o;
            o = (Options)int.Parse(Console.ReadLine());
            do
            {
                switch (o)
                {
                    case Options.Insert:
                        Console.WriteLine("Press 0 for adding a new bus line and 1 for adding a station to a bus line");//0 להוספת קו חדש ו 1 להוספת תחנה לקו אוטובוס
                        string option = Console.ReadLine();//press 0 or 1
                        int n;
                        bool d = int.TryParse(option, out n);
                        if (!d)//if he deside to adding a new bus line
                        {
                            Console.WriteLine("Please enter the number of the line that less than 4 digits");
                            string numline = Console.ReadLine();
                            int num = int.Parse(numline);
                            Console.WriteLine("Please enter the first station number of the line ");//enter the first  station
                            string numfirststation = Console.ReadLine();
                            Console.WriteLine("Please enter the last station number of the line ");//enter the last  station
                            string numlaststation = Console.ReadLine();
                            BusLineStation firststation = new BusLineStation();
                            firststation.ProbusStationKey = int.Parse(numfirststation);
                            BusLineStation laststation = new BusLineStation();
                            laststation.ProbusStationKey = int.Parse(numlaststation);
                            BusLine busline = new BusLine(num, firststation, laststation);



                            break;

                    case Options.Deletion:


                    case Options.Search:

                    case Options.Printing:

                    case Options.Exit:

                    default:
                        break;
                }
                Console.WriteLine("insert your choise please");
                o = (Options)int.Parse(Console.ReadLine());
            }
            while (o != Options.Exit);
            Console.ReadKey();
        }
    }
}
        }

     }
 }
    

