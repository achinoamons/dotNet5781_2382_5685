using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
        class BusLineStation:BusStation 
        {
       
            double DistanceLastStation;//Distance from previous station
            TimeSpan TimeLastStation;//Time from previous station
        

            public double ProDistanceLastStation
            {
                get { return DistanceLastStation; }
                set //random a number ,this the distance frome the last station
                {
                    Random r = new Random();
                    DistanceLastStation = r.Next(500);

                }
            }
            public TimeSpan ProTimeLastStation
            {
                get { return TimeLastStation; }
                set// random a time ,this the time frome the last station
                {
                    Random r = new Random();
                    TimeSpan time = new TimeSpan(r.Next(23), r.Next(59), r.Next(59)/*, r.Next(0)*/);
                    TimeLastStation = time;
                }
            }

        }
    }


