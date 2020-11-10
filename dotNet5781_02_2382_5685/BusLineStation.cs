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
                get { return TimeLastStation; }//לא להגריל זמן---לתקן
                set// random a time ,this the time frome the last station
                {
                    Random r = new Random();//לפתוח קונסט אינט שהוא קמ ממוצע לשה ואז לפי נוסחת מהירות כפול זמן=דרך
                    TimeSpan time = new TimeSpan(לפה את מכניסה )/*, r.Next(0)*/);
                    TimeLastStation = time;
                }
            }

        }
    }


