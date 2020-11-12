using System;
using System.Collections.Generic;
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
            BusLines list = new BusLines();//object of class BusLines
            List < BusStation> physical= new List<BusStation>();
            for(int i=0;i<40;i++)
            {
                physical[i] = new BusStation();//initialiation of 40 physical busstations
            }


            for (int i=0;i<10;i++)//initialitation of 10 lines
            {
                BusLineStation b = new BusLineStation();
                BusLineStation c = new BusLineStation();
                list[i] = new BusLine(++d,b,c,"Jerusalem");
            }
        }
    }
}
