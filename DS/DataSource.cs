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
        //public static int staticline = 1;
        //public static int staticforlinestation = 0;//בשביל מילוי רשימת תחנות קו באמצעות רשימת תחנות פיזיות
        //public static int staticforlinetrip = 1;
        //

        public static List<Line> ListLines = new List<Line>();
        public static List<LineStation> ListLineStations = new List<LineStation>();
        public static List<LineTrip> ListLineTrips = new List<LineTrip>();
        public static List<Station> ListStations = new List<Station>();
        public static List<Trip> ListTrips = new List<Trip>();
        public static List<AdjacentStations> ListAdjacentStations =new List<AdjacentStations>();

         static DataSource()
        {
            InitAllLists_temp();
        }
        static void InitAllLists_temp()
        {
            //send it to a function that add the stations for the list
            ListStations = new List<Station>();

            CreateStations.create50Stations(ListStations);

        }
        static void InitAllLists()
        {
            //send it to a function that add the stations for the list
            ListStations = new List<Station>();

            //st.Add(new Station() { CodeStation = 10, Name = "fff", Latitude = 32.1, Longitude = 34.91 });


            CreateStations.create50Stations(ListStations);



            //
            ListLines = new List<Line>();//רשימה של 10 קוים----1-2-3-4
            for (int i = 1; i <11; i++)
            {
                Line l = new Line();//create line
                l.LineID = Configuration.staticline++;//מס  יחודי של הקו---מס רץ---לאזורים וכאלה
                l.Code = Configuration.staticline * 10;//---אולי הפוך-----לשאול----מס הקו.. 
                int h = r.Next(0,8);
                switch (h)
                {
                    case 0: { l.Area =Areas.General; break; }
                    case 1:{  l.Area = Areas.North; break; }
                    case 2: { l.Area = Areas.South; break; }
                    case 3: { l.Area = Areas.East; break; }
                    case 4: { l.Area = Areas.West; break; }
                    case 5: { l.Area = Areas.Center; break; }
                    case 6: { l.Area =Areas.LowLand; break; }
                    case 7: { l.Area =Areas.Jerusalem; break; }

                }
                                      
                ListLineStations = new List<LineStation>();//create 10 linestations for the  specific line
                ListAdjacentStations = new List<AdjacentStations>();//create adjcent stations
               /* for (int j = 1; i < 11; j++)
                {
                    double a,b = 0;
                    TimeSpan t = new TimeSpan();
                    if (j == 1)
                    {
                        ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = 0, NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation });//0 because there is no prev station for first station
                        a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation - 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation - 1].Longitude, 2));
                         b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
                        t = TimeSpan.FromHours(b);
                        ListAdjacentStations.Add(new AdjacentStations() {Station1Code= ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation+1].CodeStation,Distance=a,Time=t });//
                        l.FirstStation = ListStations[Configuration.staticforlinestation].CodeStation;
                    }
                    else if (j == 10)
                    {
                        ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = ListStations[Configuration.staticforlinestation - 1].CodeStation, NextStationCode = 0 });//0 because there is no next station for last station
                       // ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation-1].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation].CodeStation });//
                        l.LastStation = ListStations[Configuration.staticforlinestation].CodeStation;
                    }
                    else
                    {
                        ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = ListStations[Configuration.staticforlinestation - 1].CodeStation, NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation });
                         a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation - 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation - 1].Longitude, 2));
                         b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
                                            //t = new TimeSpan((long)b);
                        t = TimeSpan.FromHours(b);
                        ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation + 1].CodeStation, Distance = a, Time = t }) ;//
                        //ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation - 1].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation].CodeStation });//
                    }
                    Configuration.staticforlinestation++;
                    if (Configuration.staticforlinestation == 49)//in case that the physical station end---go to the begining of the list stations
                        Configuration.staticforlinestation = 0;
                }
                //

                //Distance = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation-1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation-1].Longitude, 2));
                /////////לא עשינו מרחק וזמן בין 2 תחנות עוקבותתת

                ListLines.Add(l);*/
            }
            //
           



            //
            ListLineTrips = new List<LineTrip>();//יציאת קו
            for (int i = 0; i < 10; i++)//
            {
                LineTrip lt = new LineTrip();
                lt.LineTripId = Configuration.staticforlinetrip++;
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
            for(int i = 1; i < 11; i++)
            {
                Trip t = new Trip();
                t.IdTrip = i;//מס הנסיעה של המשתמש
                int hours = r.Next(5, 24);
                int minutes = r.Next(0, 60);
                TimeSpan tt = new TimeSpan(hours, minutes, 0);
                t.InAt = tt;///זמן עליה לנסיעה מ5 בבוקר עד 12 בלילה
                //t.InStation = r.Next(1,i+1);//באיזה מס תחנה עלה-סהכ יש 9תחנות
                //t.OutStation= r.Next(i+1, 10);//באיזה מס תחנה ירד-סהכ יש 9תחנות
                t.InStation = ListLines[i - 1].FirstStation;//we decided that he begins at the first station
                t.OutStation = ListLines[i - 1].LastStation;//we decided that he ends at the last station
                t.LineId = ListLines[i-1].LineID;//מספר הקו מתוך רשימת הקווים
                int h = r.Next(0, 3);//זמן נסיעה עד 2 שעות
                int m = r.Next(1, 60);//פלוס כל הדקות
                TimeSpan ttt = new TimeSpan(h, m, 0);
                t.TimeTrip = ttt;//זמן הנסיעה
                t.OutAt = tt + ttt;//זמן ירידה מהנסיעה זה זמן עליה ועוד זמן הנסיעה 
                ListTrips.Add(t);
            }
            string[] arr =  { "Tehila","Sara","Ayala","Achinoam","Refael","Yaakov","Mimi","Lea","Chana","Eli" };
            for (int i = 0; i < 10; i++)
            {
                ListTrips[i].UserName = arr[i];
            }

            //
            //ListAdjacentStations = new List<AdjacentStations>();//מידע על 2 תחנות עוקבות
            //int c,b;TimeSpan t;
            //for(int i = 0; i < 50; i++)
            //{
            //    AdjacentStations a = new AdjacentStations();
            //AdjacentStations aa= new AdjacentStations();
            //     if(i==0)
            //   { a.Station1Code = ListStations[staticforadjstations].CodeStation;
            //    a.Station2Code = ListStations[staticforadjstations+1].CodeStation;
            //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations+1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations + 1].Longitude, 2));
            //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
            //     t = new TimeSpan((long)b);
            //    a.Time = t;//זמן בין 2 תחנות 
            //    a.Distance = b;// קממרחק בין תחנות מקסימום 5
            //   ListAdjacentStations.Add(a); }
            // if(i==10)
            //{
            // a.Station1Code = ListStations[staticforadjstations].CodeStation;
            //    a.Station2Code = ListStations[staticforadjstations-1].CodeStation;
            //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations-1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations -1].Longitude, 2));
            //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
            //     t = new TimeSpan((long)b);
            //    a.Time = t;//זמן בין 2 תחנות 
            //    a.Distance = b;// קממרחק בין תחנות מקסימום 5
            //   ListAdjacentStations.Add(a);
            //}
            //else//כל מקרה אחר---מ2 הכיוונים
            //{
            //     a.Station1Code = ListStations[staticforadjstations].CodeStation;
            //    a.Station2Code = ListStations[staticforadjstations -1].CodeStation;
            //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations-1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations -1].Longitude, 2));
            //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
            //     t = new TimeSpan((long)b);
            //    a.Time = t;//זמן בין 2 תחנות 
            //    a.Distance = b;//
            //    ListAdjacentStations.Add(a);

            //     aa.Station1Code = ListStations[staticforadjstations].CodeStation;
            //    aa.Station2Code = ListStations[staticforadjstations +1].CodeStation;
            //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations+1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations +1].Longitude, 2));
            //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
            //     t = new TimeSpan((long)b);
            //    aa.Time = t;//זמן בין 2 תחנות 
            //    aa.Distance = b;//
            //    ListAdjacentStations.Add(aa);
            //}
            //  
            //}
            ////









        }
    }
}
