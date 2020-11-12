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
        }

     }
 }
    

