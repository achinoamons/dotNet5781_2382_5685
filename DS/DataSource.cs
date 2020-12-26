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

       public static Random r = new Random(DateTime.Now.Millisecond);
       public static int staticline = 1;
       public  static int staticstation = 1000;//code of station is 4 digits
       public  static int staticlinestation = 1000;
       public static int help1 = 1;
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
            ListLines = new List<Line>();//רשימה של 10 קוים----1-2-3-4
            for (int i = 1; i <11; i++)
            {//1000---1050
                Line l = new Line();
                l.LineID = staticline++;//מס  יחודי של הקו
                l.Code = staticline * 10;//קוד הקו---יותר לאזורים וכאלה.. 
               //פה אני צריכה ליצור 10 תחנות קו ולהכניס לרשימת תחנות קו--ולפה מכניסה רק ראשון ואחרון
                
                l.FirstStation = 1000;
                if (i <= 5)
                { l.LastStation = 1000 + i * 10; }//
                else { l.LastStation = 1000 + i * 5; }//כדי לתת לכל קו 10 תחנות לפחות
                ListLines.Add(l);
            }
            //
            ListStations = new List<Station>();//רשימת תחנות פיזיות---50 תחנות
            CreateStations.create50Stations(ListStations);
            
           /* for (int i = 0; i < 50; i++)
                {

              Station st = new Station();
                st.CodeStation = staticstation++;
                 st.Latitude= (r.NextDouble() * (31 - 33.3) + 31);
                 st.Longitude = (r.NextDouble() * (34.3 - 35.5) + 34.3);
               //  st.Name = stationnames[i];
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
            ListStations[8].Name = "Hayarkon st. -Hanarkis st.";*/
              ///////////////////////////////////////////////////////

            //העברנו להערה כי הקטע הזה קורה בתוך אתחול של קוים
            //ListLineStations = new List<LineStation>();//רשימת תחנות לוגיות
            //for (int i = 1; i <= 50; i++)
            //{
                
            //    LineStation lst = new LineStation();
            //    lst.LineId = ListLines[i-1].LineID;
            //    lst.StationCode = ListStations[i].CodeStation;//כלןמר קוד התחנה הפיזית 
            //    lst.PrevStationCode = r.Next(1, i+1);
            //    lst.NextStationCode = r.Next(i+1 , 10);//כי עשיתי 9 תחנות פיזיות
            //    ListLineStations.Add(lst);
            //}

            //
            ListLineTrips = new List<LineTrip>();//יציאת קו
            for (int i = 0; i < 4; i++)//5 כי הגדרתי רק 5 קוים
            {
                LineTrip lt = new LineTrip();
                lt.LineTripId = help1++;//בגלל שכבר השתמשנו לאתחולים אחרים-זה מתחיל פה מ10 כי היה פור של 9 לתחנות פיזיות
                lt.LineId = ListLines[i].LineID;
                TimeSpan t =(TimeSpan.FromMinutes(r.Next(0, 60)));//תדירות בין 0 ל60
                lt.Frequency = t;
                int hours = r.Next(5, 24);
                int minutes = r.Next(0, 60);
                TimeSpan tt = new TimeSpan(hours, minutes,0);
                lt.StartAt = tt;//זמן יציאת קו
                int h = r.Next(0, 3);
                int m = r.Next(0, 60);
                TimeSpan ttt = new TimeSpan(h, m, 0);
                lt.TimeTrip = ttt;//משך זמן הנסיעה--שדה שהוספנו
                lt.FinishAt = tt + ttt;//זמן סיום----זה זמן התחלת נסיעה פלוס זמן הנסיעה
                ListLineTrips.Add(lt);//הוספה לרשימה

            }
            //
            ListTrips = new List<Trip>();
            for(int i = 1; i < 5; i++)
            {
                Trip t = new Trip();
                t.IdTrip = i;//מס הנסיעה של המשתמש
                int hours = r.Next(5, 24);
                int minutes = r.Next(0, 60);
                TimeSpan tt = new TimeSpan(hours, minutes, 0);
                t.InAt = tt;///זמן עליה לנסיעה מ5 בבוקר עד 12 בלילה
                t.InStation = r.Next(1,i+1);//באיזה מס תחנה עלה-סהכ יש 9תחנות
                t.OutStation= r.Next(i+1, 10);//באיזה מס תחנה ירד-סהכ יש 9תחנות
                t.LineId = ListLines[i-1].LineID;//מספר הקו מתוך רשימת הקווים
                int h = r.Next(0, 3);//זמן נסיעה עד 2 שעות
                int m = r.Next(1, 60);//פלוס כל הדקות
                TimeSpan ttt = new TimeSpan(h, m, 0);
                t.TimeTrip = ttt;//זמן הנסיעה
                t.OutAt = tt + ttt;//זמן ירידה מהנסיעה זה זמן עליה ועוד זמן הנסיעה 
                ListTrips.Add(t);
            }
            ListTrips[1].UserName = "Tehila";
            ListTrips[2].UserName = "Sara";
            ListTrips[3].UserName = "Ayala";
            ListTrips[3].UserName = "Achinoam";
            //
            ListAdjacentStations = new List<AdjacentStations>();//מידע על 2 תחנות עוקבות
            for(int i = 1; i < 6; i++)
            {//אם יהיה צורך לעשות תחנות עוקבות להכל---צריך לעשות
                AdjacentStations a = new AdjacentStations();
                a.Station1Code = r.Next(1, i+1);//מספר תחנה ראשונה -מבין 9 התחנות הקיימות 
                a.Station2Code= a.Station1Code+1;//מספר תחנה שניה -המס העוקב למס התחנה הראשונה 
                //int h = r.Next(0, 3);//זמן בין 2 התחנות הוא מקסימום 2 שעות
                int m = r.Next(0,30);
                TimeSpan t = new TimeSpan(0, m, 0);//המרחק המקסימלי בין 2 תחנות הוא מקסימום חצי שעה
                a.Time = t;//זמן בין 2 תחנות 
                a.Distance = r.Next(5);// קממרחק בין תחנות מקסימום 5
                ListAdjacentStations.Add(a);
            }
            //









        }
    }
}
