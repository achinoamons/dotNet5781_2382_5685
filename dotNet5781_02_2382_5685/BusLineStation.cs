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
            TimeSpan TimeLastStation;//Time from previous station//-לפי נוסחת מרחק-צריך להיות קשור למרחקקקקקק-לפי מהירות ממוצעת
            int kamesh;//A field we set for kilometer per hour is a fixed value for all intercity lines

        public double ProDistanceLastStation
            {
                get { return DistanceLastStation; }
                set //random a number ,this the distance frome the last station
                {
                   Random r = new Random();
                    DistanceLastStation = r.Next(500);

                }
            }
        public int ProKamesh
        {
            get{ return 90; }
        }
            public TimeSpan ProTimeLastStation
            {
                get { return TimeLastStation; }
                set
                {
                TimeSpan time = new TimeSpan();
                double dis= ProDistanceLastStation;
                double kam = ProKamesh;
                double div = (dis / kam);

                time =
                 TimeLastStation = time;
                }
            }

        }
    }


