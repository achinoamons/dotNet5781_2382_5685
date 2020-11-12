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
            int kamesh=90;//A field we set for kilometer per hour is a fixed value for all intercity lines
       public  BusLineStation()
        {
            Random r = new Random();
            DistanceLastStation = r.Next(500);
            double dis = ProDistanceLastStation;
            double kam = ProKamesh;
            double div = (dis / kam);
            TimeLastStation = TimeSpan.FromMinutes(div);//Initialization of the distance from a previous station according to a road formula

        }


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
                double dis = ProDistanceLastStation;
                double kam = ProKamesh;
                // long div = (long)(dis / kam);
                // TimeSpan time = new TimeSpan(div);
                double div = (dis / kam);
                TimeLastStation = TimeSpan.FromMinutes(div);//Initialization of the distance from a previous station according to a road formula


            }
        }

        }
    }


