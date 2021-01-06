//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DO;

//namespace DS
//{
//    public static class DataSource

//    {
//        //for randomalization initiations

//        public static Random r = new Random(DateTime.Now.Millisecond);


//        public static List<Line> ListLines = new List<Line>();
//        public static List<LineStation> ListLineStations = new List<LineStation>();
//        public static List<LineTrip> ListLineTrips = new List<LineTrip>();
//        public static List<Station> ListStations = new List<Station>();
//        public static List<Trip> ListTrips = new List<Trip>();
//        public static List<AdjacentStations> ListAdjacentStations = new List<AdjacentStations>();

//        static DataSource()
//        {
//            InitAllLists_temp();
//        }
//        static void InitAllLists_temp()
//        {
//            //send it to a function that add the stations for the list


//            CreateStations.create50Stations(ListStations);

//            //ListLines = new List<Line>();//רשימה של 10 קוים----1-2-3-4
          
//            for (int i = 1; i < 11; i++){

//                Line l = new Line();//create line
//                l.LineID = Configuration.staticline++;//מס  יחודי של הקו---מס רץ---לאזורים וכאלה
//                l.Code = Configuration.staticline * 10;//---אולי הפוך-----לשאול----מס הקו.. 
//                int h = r.Next(0, 8);
//                switch (h)
//                {
//                    case 0: { l.Area = Areas.General; break; }
//                    case 1: { l.Area = Areas.North; break; }
//                    case 2: { l.Area = Areas.South; break; }
//                    case 3: { l.Area = Areas.East; break; }
//                    case 4: { l.Area = Areas.West; break; }
//                    case 5: { l.Area = Areas.Center; break; }
//                    case 6: { l.Area = Areas.LowLand; break; }
//                    case 7: { l.Area = Areas.Jerusalem; break; }

//                }

//                //create 10 linestations for the  specific line
//                //create adjcent stations
//                for (int j = 1; i < 11; j++)
//                {
//                    double a = 0, b = 0;
//                    TimeSpan t = new TimeSpan();
//                    if (j == 1)
//                    {
//                        ListLineStations.Add(new LineStation() { LineId = i,
//                            StationCode = ListStations[Configuration.staticforlinestation].CodeStation,
//                            LineStationIndex = j, 
//                            PrevStationCode = 0,
//                            NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation });//0 because there is no prev station for first station
//                        a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation + 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation + 1].Longitude, 2));
//                        b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//                        t = TimeSpan.FromHours(b);
//              //          ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation + 1].CodeStation, Distance = a, Time = t });//
//                        l.FirstStation = ListStations[Configuration.staticforlinestation].CodeStation;
//                    }
//                    else if (j == 10)
//                    {
//                        ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = ListStations[Configuration.staticforlinestation -1].CodeStation, NextStationCode = 0 });//0 because there is no next station for last station
//                                                                                                                                                                                                                                                                                          // ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation-1].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation].CodeStation });//
//                        l.LastStation = ListStations[Configuration.staticforlinestation].CodeStation;
//                    }
//                    else
//                    {
//                        ListLineStations.Add(new LineStation() { LineId = i,
//                            StationCode = ListStations[Configuration.staticforlinestation].CodeStation, 
//                            LineStationIndex = j, PrevStationCode = ListStations[Configuration.staticforlinestation -1].CodeStation, 
//                            NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation });
//                        a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation + 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation + 1].Longitude, 2));
//                        b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//                                           //t = new TimeSpan((long)b);
//                        t = TimeSpan.FromHours(b);
//                    //    ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation + 1].CodeStation, Distance = a, Time = t });//
//                    }
//                    Configuration.staticforlinestation++;
//                    if (Configuration.staticforlinestation == 49)//in case that the physical station end---go to the begining of the list stations
//                        Configuration.staticforlinestation = 0;
//                }

                

//                ListLines.Add(l);
//            }
          
//            for (int i = 0; i < 10; i++)//
//            {
//                LineTrip lt = new LineTrip();
//                lt.LineTripId = Configuration.staticforlinetrip++;
//                lt.LineId = ListLines[i].LineID;
//                TimeSpan t = (TimeSpan.FromMinutes(r.Next(0, 60)));//תדירות בין 0 ל60
//                lt.Frequency = t;
//                int hours = r.Next(5, 24);
//                int minutes = r.Next(0, 60);
//                TimeSpan tt = new TimeSpan(hours, minutes, 0);
//                lt.StartAt = tt;//זמן יציאת קו
//                int h = r.Next(0, 3);
//                int m = r.Next(0, 60);
//                TimeSpan ttt = new TimeSpan(h, m, 0);
//                lt.TimeTrip = ttt;//משך זמן הנסיעה--שדה שהוספנו
//                lt.FinishAt = tt + ttt;//זמן סיום----זה זמן התחלת נסיעה פלוס זמן הנסיעה
//                ListLineTrips.Add(lt);//הוספה לרשימה

//            }
//            //
//            //ListTrips = new List<Trip>();
//            for (int i = 1; i < 11; i++)
//            {
//                Trip t = new Trip();
//                t.IdTrip = i;//מס הנסיעה של המשתמש
//                int hours = r.Next(5, 24);
//                int minutes = r.Next(0, 60);
//                TimeSpan tt = new TimeSpan(hours, minutes, 0);
//                t.InAt = tt;///זמן עליה לנסיעה מ5 בבוקר עד 12 בלילה
//                //t.InStation = r.Next(1,i+1);//באיזה מס תחנה עלה-סהכ יש 9תחנות
//                //t.OutStation= r.Next(i+1, 10);//באיזה מס תחנה ירד-סהכ יש 9תחנות
//                t.InStation = ListLines[i - 1].FirstStation;//we decided that he begins at the first station
//                t.OutStation = ListLines[i - 1].LastStation;//we decided that he ends at the last station
//                t.LineId = ListLines[i - 1].LineID;//מספר הקו מתוך רשימת הקווים
//                int h = r.Next(0, 3);//זמן נסיעה עד 2 שעות
//                int m = r.Next(1, 60);//פלוס כל הדקות
//                TimeSpan ttt = new TimeSpan(h, m, 0);
//                t.TimeTrip = ttt;//זמן הנסיעה
//                t.OutAt = tt + ttt;//זמן ירידה מהנסיעה זה זמן עליה ועוד זמן הנסיעה 
//                ListTrips.Add(t);
//            }
//            string[] arr = { "Tehila", "Sara", "Ayala", "Achinoam", "Refael", "Yaakov", "Mimi", "Lea", "Chana", "Eli" };
//            for (int i = 0; i < 10; i++)
//            {
//                ListTrips[i].UserName = arr[i];
//            }

//        }




//            //static void InitAllLists()
//            //{
//            //    //send it to a function that add the stations for the list
//            //    //ListStations = new List<Station>();

//            //    //st.Add(new Station() { CodeStation = 10, Name = "fff", Latitude = 32.1, Longitude = 34.91 });


//            //    CreateStations.create50Stations(ListStations);



//            //    //
//            //    ListLines = new List<Line>();//רשימה של 10 קוים----1-2-3-4
//            //    for (int i = 1; i <11; i++)
//            //    {
//            //        Line l = new Line();//create line
//            //        l.LineID = Configuration.staticline++;//מס  יחודי של הקו---מס רץ---לאזורים וכאלה
//            //        l.Code = Configuration.staticline * 10;//---אולי הפוך-----לשאול----מס הקו.. 
//            //        int h = r.Next(0,8);
//            //        switch (h)
//            //        {
//            //            case 0: { l.Area =Areas.General; break; }
//            //            case 1:{  l.Area = Areas.North; break; }
//            //            case 2: { l.Area = Areas.South; break; }
//            //            case 3: { l.Area = Areas.East; break; }
//            //            case 4: { l.Area = Areas.West; break; }
//            //            case 5: { l.Area = Areas.Center; break; }
//            //            case 6: { l.Area =Areas.LowLand; break; }
//            //            case 7: { l.Area =Areas.Jerusalem; break; }

//            //        }

//            //        //create 10 linestations for the  specific line
//            //       //create adjcent stations
//            //        for (int j = 1; i < 11; j++)
//            //        {
//            //            double a=0,b = 0;
//            //            TimeSpan t = new TimeSpan();
//            //            if (j == 1)
//            //            {
//            //                ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = 0, NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation });//0 because there is no prev station for first station
//            //                a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation +1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation +1].Longitude, 2));
//            //                 b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//            //                t = TimeSpan.FromHours(b);
//            //                ListAdjacentStations.Add(new AdjacentStations() {Station1Code= ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation+1].CodeStation,Distance=a,Time=t });//
//            //                l.FirstStation = ListStations[Configuration.staticforlinestation].CodeStation;
//            //            }
//            //            else if (j == 10)
//            //            {
//            //                ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = ListStations[Configuration.staticforlinestation - 1].CodeStation, NextStationCode = 0 });//0 because there is no next station for last station
//            //               // ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation-1].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation].CodeStation });//
//            //                l.LastStation = ListStations[Configuration.staticforlinestation].CodeStation;
//            //            }
//            //            else
//            //            {
//            //                ListLineStations.Add(new LineStation() { LineId = i, StationCode = ListStations[Configuration.staticforlinestation].CodeStation, LineStationIndex = j, PrevStationCode = ListStations[Configuration.staticforlinestation - 1].CodeStation, NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation });
//            //                 a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation + 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation + 1].Longitude, 2));
//            //                 b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//            //                                    //t = new TimeSpan((long)b);
//            //                t = TimeSpan.FromHours(b);
//            //                ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation + 1].CodeStation, Distance = a, Time = t }) ;//
//            //                //ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation - 1].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation].CodeStation });//
//            //            }
//            //            Configuration.staticforlinestation++;
//            //            if (Configuration.staticforlinestation == 49)//in case that the physical station end---go to the begining of the list stations
//            //                Configuration.staticforlinestation = 0;
//            //        }
//            //        //


//            //        /////////לא עשינו מרחק וזמן בין 2 תחנות עוקבותתת

//            //        ListLines.Add(l);
//            //    }
//            //    //




//            //    //


//            //    //
//            //    //ListAdjacentStations = new List<AdjacentStations>();//מידע על 2 תחנות עוקבות
//            //    //int c,b;TimeSpan t;
//            //    //for(int i = 0; i < 50; i++)
//            //    //{
//            //    //    AdjacentStations a = new AdjacentStations();
//            //    //AdjacentStations aa= new AdjacentStations();
//            //    //     if(i==0)
//            //    //   { a.Station1Code = ListStations[staticforadjstations].CodeStation;
//            //    //    a.Station2Code = ListStations[staticforadjstations+1].CodeStation;
//            //    //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations+1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations + 1].Longitude, 2));
//            //    //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//            //    //     t = new TimeSpan((long)b);
//            //    //    a.Time = t;//זמן בין 2 תחנות 
//            //    //    a.Distance = b;// קממרחק בין תחנות מקסימום 5
//            //    //   ListAdjacentStations.Add(a); }
//            //    // if(i==10)
//            //    //{
//            //    // a.Station1Code = ListStations[staticforadjstations].CodeStation;
//            //    //    a.Station2Code = ListStations[staticforadjstations-1].CodeStation;
//            //    //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations-1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations -1].Longitude, 2));
//            //    //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//            //    //     t = new TimeSpan((long)b);
//            //    //    a.Time = t;//זמן בין 2 תחנות 
//            //    //    a.Distance = b;// קממרחק בין תחנות מקסימום 5
//            //    //   ListAdjacentStations.Add(a);
//            //    //}
//            //    //else//כל מקרה אחר---מ2 הכיוונים
//            //    //{
//            //    //     a.Station1Code = ListStations[staticforadjstations].CodeStation;
//            //    //    a.Station2Code = ListStations[staticforadjstations -1].CodeStation;
//            //    //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations-1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations -1].Longitude, 2));
//            //    //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//            //    //     t = new TimeSpan((long)b);
//            //    //    a.Time = t;//זמן בין 2 תחנות 
//            //    //    a.Distance = b;//
//            //    //    ListAdjacentStations.Add(a);

//            //    //     aa.Station1Code = ListStations[staticforadjstations].CodeStation;
//            //    //    aa.Station2Code = ListStations[staticforadjstations +1].CodeStation;
//            //    //    c = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforadjstations].Latitude - ListStations[Configuration.staticforadjstations+1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforadjstations].Longitude - ListStations[Configuration.staticforadjstations +1].Longitude, 2));
//            //    //     b = (c * 1.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
//            //    //     t = new TimeSpan((long)b);
//            //    //    aa.Time = t;//זמן בין 2 תחנות 
//            //    //    aa.Distance = b;//
//            //    //    ListAdjacentStations.Add(aa);
//            //    //}
//            //    //  
//            //    //}
//            //    ////









//        }
//}
////////////////////////////////////////
////////////////////////
//////////////////////////////////////////
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using static DO.Bus;
using static DO.Line;

     
namespace DS
{

    public static class DataSource
    {
        public static List<Bus> listBus;
        public static List<Station> listStations;
        public static List<User> listUsers;
        public static List<AdjacentStations> listAdjacentStation;
        public static List<Trip> listTrip;
        public static List<LineTrip> listLineTrip;
        public static List<LineStation> listLineStation;
        public static List<Line> listLine;
        //public static List<BusOnTrip> listBusOnTrip;
        public static object listUser;


        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            listBus = new List<Bus>();
            for (int i = 0; i < 20; i++)
            {
                Bus b = new Bus
                {
                    LicenceNum = 1245670 + i,
                    Mileage = 100.0,
                    FuelRemain = 50.3,
                    Status = STATUS.ReadyForRide
                };
                listBus.Add(b);
            }
            listStations = new List<Station>
            {
                #region Boot stations//איתחול תחנות
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Latitude = 31.825302,
                    longitude = 35.188624
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Latitude = 31.738425,
                    longitude = 35.228765
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Latitude = 31.738676,
                    longitude = 35.226704
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Latitude = 31.789128,
                    longitude = 35.206146
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.766358,
                    longitude = 35.240417
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Latitude = 31.790758,
                    longitude = 35.209791
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.768643,
                    longitude = 35.238509
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.769899,
                    longitude = 35.23973
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.767064,
                    longitude = 35.238443
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765863,
                    longitude = 35.247198
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.799804,
                    longitude = 35.213021
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765717,
                    longitude = 35.247102
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767265,
                    longitude = 35.246594
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767084,
                    longitude = 35.246655
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.768759,
                    longitude = 31.768759
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.77002,
                    longitude = 35.24348
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8003,
                    longitude = 35.208257
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8,
                    longitude = 35.214106
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Latitude = 31.797708,
                    longitude = 35.217133
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.217057
                },
                //20
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.213728
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Latitude = 31.796818,
                    longitude = 35.212936
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Latitude = 31.796129,
                    longitude = 35.212698
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Latitude = 31.794631,
                    longitude = 35.21161
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Latitude = 31.79508,
                    longitude = 35.211684
                },
                //25
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Latitude = 31.796255,
                    longitude = 35.211065
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Latitude = 31.798423,
                    longitude = 35.209575
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Latitude = 31.798689,
                    longitude = 35.208878
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Latitude = 31.799165,
                    longitude = 35.206918
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Latitude = 31.797829,
                    longitude = 35.205601
                },

                //#endregion //30
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Latitude = 31.840063,
                    longitude = 35.240062

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Latitude = 31.838481,
                    longitude = 35.23972
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
            Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Latitude = 31.837748,
                    longitude = 35.231598
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Latitude = 31.840279,
                    longitude = 35.246272
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Latitude = 31.843598,
                    longitude = 35.243639
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Latitude = 31.766256,
                    longitude = 35.173
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Latitude = 31.76736,
                    longitude = 35.184771
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Latitude = 31.770543,
                    longitude = 35.183999
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Latitude = 31.768465,
                    longitude = 35.178701
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Latitude = 31.759534,
                    longitude = 35.173688
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Latitude = 31.761447,
                    longitude = 35.175929
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.761447,
                    longitude = 35.199936
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.759186,
                    longitude = 35.189336
                },


             new Station
            {
            Code = 1518,
            Name = "פרץ ברנשטיין/נזר דוד",
            Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
            Latitude = 31.759121,
            longitude = 35.189178
        },
              new Station
              {
            Code = 1522,
            Name = "מוזיאון ישראל/רופין",
            Address = "  רחוב:דרך רופין  עיר: ירושלים ",
            Latitude = 31.774484,
            longitude = 35.204882
                },

             new Station
                  {
             Code = 1523,
            Name = "הרצוג/טשרניחובסקי",
            Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
            Latitude = 31.769652,
            longitude = 35.208248
                },
              new Station
                {
              Code = 1524,
            Name = "רופין/שד' הזז",
            Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
            Latitude = 31.769652,
            longitude = 35.208248,
                 },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Latitude = 31.796033,
                    longitude =35.206094
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Latitude = 31.794958,
                    longitude =35.205216
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Latitude = 31.79617,
                    longitude =35.206158
                }

                
                #endregion
            };
            listUsers = new List<User>();

            listLine = new List<Line>
            {
          #region Initialize lines//איתחול קווים
                new Line
                {
                    ID=1,
                    Code=32,
                    Area=AREA.CENTER,
                    FirstStation=73,
                   LastStation = 89,
                   StationNum=10
                },
                new Line
                {
                     ID=2,
                    Code=45,
                    Area=AREA.CENTER,
                    FirstStation=89,
                   LastStation = 105,
                   StationNum=10
                },
                new Line
                {
                    ID=3,
                    Code=36,
                    Area=AREA.CENTER,
                    FirstStation=105,
                   LastStation = 116,
                   StationNum=10
                },
                new Line
                {
                    ID=4,
                    Code=50,
                    Area=AREA.CENTER,
                    FirstStation=73,
                   LastStation = 122,
                   StationNum=50
                },
                new Line
                {
                    ID=5,
                    Code=56,
                    Area=AREA.CENTER,
                    FirstStation=122,
                   LastStation = 1511,
                   StationNum=11
                },
                new Line
                {
                    ID=6,
                    Code=28,
                    Area=AREA.CENTER,
                    FirstStation=1492,
                   LastStation = 1523,
                   StationNum=12
                },
                new Line
                {
                    ID=7,
                    Code=69,
                    Area=AREA.CENTER,
                    FirstStation=1485,
                   LastStation = 1510,
                   StationNum=10
                },
                new Line
                {
                    ID=8,
                    Code=58,
                    Area=AREA.CENTER,
                    FirstStation=105,
                   LastStation = 119,
                   StationNum=12
                },
                new Line
                {
                    ID=9,
                    Code=92,
                    Area=AREA.CENTER,
                    FirstStation=77,
                   LastStation = 95,
                   StationNum=13
                },
                new Line
                {
                    ID=10,
                    Code=55,
                    Area=AREA.CENTER,
                    FirstStation=1485,
                   LastStation = 1514,
                   StationNum=13
                },

#endregion
                
        };
            DO.StaticRunNumbers.RUNNUMBERLineID += 10;

            listLineStation = new List<LineStation>
            {
                new LineStation{ LineID=1,Station=73, LineStationIndex=1, NextStation=76, PrevStation=0},
                new LineStation{ LineID=1,Station=76, LineStationIndex=1, NextStation=77, PrevStation=73}

            };

            listAdjacentStation = new List<AdjacentStations>
            {
                new AdjacentStations{ Distance=10, Station1=73, Station2=76, Time=new TimeSpan(0,10,30)}
            };
            listLineTrip = new List<LineTrip>
            {
                new LineTrip{ ID=1, LineID=1, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=2, LineID=2, StartAt=new TimeSpan(7,30,0), FinishAt=new TimeSpan(23,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=3, LineID=3, StartAt=new TimeSpan(8,0,0), FinishAt=new TimeSpan(22,30,0), Frequency=new TimeSpan(0,20,0)},
                new LineTrip{ ID=4, LineID=4, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=5, LineID=5, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=6, LineID=6, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=7, LineID=7, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=8, LineID=8, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=9, LineID=9, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=10, LineID=10, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)}
            };
        }

    }
}



