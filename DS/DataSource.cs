using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public  static class DataSource

    {
        //for randomalization initiations
        static Random r = new Random(DateTime.Now.Millisecond);
        static int help = 0;
        static int help1 = 1;
        //

        public static List<Line> ListLines;//
        public static List<LineStation> ListLineStations;//
        public static List<LineTrip> ListLineTrips;//
        public static List<Station> ListStations;//
        public static List<Trip> ListTrips;
        public static List<AdjacentStations> ListAdjacentStations;

        static DataSource()
        {
            InitAllLists();
        }
        static  void InitAllLists()
        {
            //
            ListLines = new List<Line>();
            for (int i = 1; i < 5; i++)
            {
                Line l = new Line();
                l.LineID = ++help;
                l.Code = help * 10;
                l.FirstStation = i;
                l.LastStation = i * help;
                ListLines.Add(l);
            }
            //
            ListStations = new List<Station>();

           
            for (int i = 0; i < 9; i++)
                {

                Station st = new Station();
                st.CodeStation = help1++;
                st.Latitude= (int)(r.NextDouble() * (31 - 33.3) + 31);
                st.Longitude = (int)(r.NextDouble() * (34.3 - 35.5) + 34.3);
                ListStations.Add(st);
                }
            ListStations[0].Name = "Shal st.-Gold st.";
            ListStations[1].Name = "Shal st.-Havaad Haleumi";
            ListStations[2].Name = "Shahal st.-Heler st.";
            ListStations[3].Name = "Tzomet givat Mordechai-Biat";
            ListStations[4].Name = "Shaarey-Zedek";
            ListStations[5].Name = "Malcha a";
            ListStations[6].Name = "Agudat Sport Beitar";
            ListStations[7].Name = "Gan Technology";
            ListStations[8].Name = "Hayarkon st. -Hanarkis st.";

            //
            ListLineStations = new List<LineStation>();
            for (int i = 1; i < 4; i++)
            {

                LineStation lst = new LineStation();
                lst.LineId = i;
                lst.StationCode = ListStations[i-1].CodeStation;//כלןמר לתחנות פיזיות 0 ו4 אין אוטובוס שעובר
                lst.PrevStationCode = r.Next(1, i - 1);
                lst.NextStationCode = r.Next(i - 1, 9);//כי עשיתי 9 תחנות פיזיות
                ListLineStations.Add(lst);
            }

            //
            ListLineTrips = new List<LineTrip>();//יציאת קו
            for (int i = 0; i < 4; i++)//5 כי הגדרתי רק 5 קוים
            {
                LineTrip lt = new LineTrip();
                lt.LineTripId = help1++;
                lt.LineId = ListLines[i].LineID;
                TimeSpan t =(TimeSpan.FromMinutes(r.Next(0, 60)));//תדירות בין 0 ל60
                lt.Frequency = t;
                int hours = r.Next(5, 24);
                int minutes = r.Next(0, 60);
                TimeSpan tt = new TimeSpan(hours, minutes,0);
                lt.StartAt = tt;
                int h = r.Next(0, 3);
                int m = r.Next(0, 60);
                TimeSpan ttt = new TimeSpan(h, m, 0);
                lt.TimeTrip = ttt;
                lt.FinishAt = tt + ttt;//זמן סיום----זה זמן התחלת נסיעה פלוס זמן הנסיעה
                ListLineTrips.Add(lt);//הוספה לרשימה

            }
            //
            ListTrips = new List<Trip>();
            for(int i = 1; i < 4; i++)
            {
                Trip t = new Trip();
                t.IdTrip = help1++;//מס הנסיעה של המשתמש
                int hours = r.Next(5, 24);
                int minutes = r.Next(0, 60);
                TimeSpan tt = new TimeSpan(hours, minutes, 0);
                t.InAt = tt;///זמן עליה לנסיעה מ5 בבוקר עד 12 בלילה
                t.InStation = r.Next(1, 10);//באיזה מס תחנה עלה-סהכ יש 9תחנות
                t.OutStation= r.Next(1, 10);//באיזה מס תחנה ירד-סהכ יש 9תחנות
                t.LineId = ListLines[i].LineID;//מספר הקו מתוך רשימת הקווים
                int h = r.Next(0, 3);//זמן נסיעה עד 3 שעות
                int m = r.Next(0, 60);
                TimeSpan ttt = new TimeSpan(h, m, 0);
                t.TimeTrip = ttt;//זמן הנסיעה
                t.OutAt = tt + ttt;//זמן ירידה מהנסיעה זה זמן עליה ועוד זמן הנסיעה 
                ListTrips.Add(t);
            }
            ListTrips[1].UserName = "tehila";
            ListTrips[2].UserName = "sara";
            ListTrips[3].UserName = "ayala";
            //
            ListAdjacentStations = new List<AdjacentStations>();
            for(int i = 0; i < 5; i++)
            {
                AdjacentStations a = new AdjacentStations();
                a.Station1Id = r.Next(1, 10);//מספר תחנה ראשונה -מבין 9 התחנות הקיימות 
                a.Station2Id= r.Next(1, 10);//מספר תחנה שניה -מבין 9 התחנות הקיימות 
                int h = r.Next(0, 3);//זמן בין 2 התחנות הוא מקסימום 3 שעות
                int m = r.Next(0, 60);
                TimeSpan t = new TimeSpan(h, m, 0);
                a.Time = t;//זמן בין 2 תחנות 
                a.Distance = r.Next(500);//מרחק בין תחנות מקסימום 500
                ListAdjacentStations.Add(a);
            }
            //









        }
    }
}
