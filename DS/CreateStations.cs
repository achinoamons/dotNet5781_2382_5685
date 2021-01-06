using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public class CreateStations
    {
        // public static Random r = new Random(DateTime.Now.Millisecond);

        public static void create50Stations(List<Station> st)
        // public static void create50Stations(List<Station> st,List<LineStation> ListLineStations,List<LineTrip> ListLineTrips,
        //   List<Station>ListStations, List<Trip>ListTrips,List<AdjacentStations> ListAdjacentStations,List<Line>ListLines){ 

        {

            st.Add(new Station() { CodeStation = 38831, Name = "בי'ס בר לב/בן יהודה", Latitude = 32.183921, Longitude = 34.917806 });
            st.Add(new Station() { CodeStation = 38832, Name = "הרצל/צומת בילו", Latitude = 31.870034, Longitude = 34.819541 });
            st.Add(new Station() { CodeStation = 38833, Name = "הנחשול/הדייגים", Latitude = 31.984553, Longitude = 34.782828 });
            st.Add(new Station() { CodeStation = 38834, Name = "פריד/ששת הימים", Latitude = 31.88855, Longitude = 34.790904 });
            st.Add(new Station() { CodeStation = 38836, Name = "ת. מרכזית לוד/הורדה", Latitude = 31.956392, Longitude = 34.898098 });
            st.Add(new Station() { CodeStation = 38837, Name = "חנה אברך/וולקני", Latitude = 31.892166, Longitude = 34.796071 });
            st.Add(new Station() { CodeStation = 38838, Name = "הרצל/משה שרת", Latitude = 31.857565, Longitude = 34.824106 });
            st.Add(new Station() { CodeStation = 38839, Name = "הבנים/אלי כהן", Latitude = 31.862305, Longitude = 34.821857 });
            st.Add(new Station() { CodeStation = 38840, Name = "ויצמן/הבנים", Latitude = 31.865085, Longitude = 34.822237 });
            st.Add(new Station() { CodeStation = 38841, Name = "האירוס/הכלנית", Latitude = 31.865222, Longitude = 34.818957 });

            st.Add(new Station() { CodeStation = 38842, Name = "הכלנית/הנרקיס", Latitude = 31.867597, Longitude = 34.818392 });
            st.Add(new Station() { CodeStation = 38844, Name = "אלי כהן/לוחמי הגטאות", Latitude = 31.86244, Longitude = 34.827023 });
            st.Add(new Station() { CodeStation = 38845, Name = "שבזי/שבת אחים", Latitude = 31.863501, Longitude = 34.828702 });
            st.Add(new Station() { CodeStation = 38846, Name = "שבזי/ויצמן", Latitude = 31.865348, Longitude = 34.827102 });
            st.Add(new Station() { CodeStation = 38847, Name = "חיים בר לב/שדרות יצחק רבין", Latitude = 31.977409, Longitude = 34.763896 });
            st.Add(new Station() { CodeStation = 38848, Name = "מרכז לבריאות הנפש לב השרון", Latitude = 32.300345, Longitude = 34.912708 });
            st.Add(new Station() { CodeStation = 38849, Name = "מרכז לבריאות הנפש לב השרון", Latitude = 32.301347, Longitude = 34.912602 });
            st.Add(new Station() { CodeStation = 38852, Name = "הולצמן/המדע", Latitude = 31.914255, Longitude = 34.807944 });
            st.Add(new Station() { CodeStation = 38854, Name = "מחנה צריפין/מועדון", Latitude = 31.963668, Longitude = 34.836363 });
            st.Add(new Station() { CodeStation = 38855, Name = "הרצל/גולני", Latitude = 31.856115, Longitude = 34.825249 });

            st.Add(new Station() { CodeStation = 38856, Name = "הרותם/הדגניות", Latitude = 31.874963, Longitude = 34.81249 });
            st.Add(new Station() { CodeStation = 38859, Name = "הערבה", Latitude = 32.300035, Longitude = 34.910842 });
            st.Add(new Station() { CodeStation = 38860, Name = "מבוא הגפן/מורד התאנה", Latitude = 32.305234, Longitude = 34.948647 });
            st.Add(new Station() { CodeStation = 38861, Name = "מבוא הגפן/ההרחבה", Latitude = 32.304022, Longitude = 34.943393 });
            st.Add(new Station() { CodeStation = 38862, Name = "ההרחבה א", Latitude = 32.302957, Longitude = 34.940529 });
            ///////////////
            st.Add(new Station() { CodeStation = 38863, Name = "ההרחבה ב", Latitude = 32.300264, Longitude = 34.939512 });
            st.Add(new Station() { CodeStation = 38864, Name = "ההרחבה/הותיקים", Latitude = 32.298171, Longitude = 34.939512 });
            st.Add(new Station() { CodeStation = 38865, Name = "רשות שדות התעופה/העליה", Latitude = 31.990876, Longitude = 34.8976 });
            st.Add(new Station() { CodeStation = 38866, Name = "כנף/ברוש", Latitude = 31.998767, Longitude = 34.879725 });
            st.Add(new Station() { CodeStation = 38867, Name = "החבורה/דב הוז", Latitude = 31.883019, Longitude = 34.818708 });

            st.Add(new Station() { CodeStation = 38869, Name = "בית הלוי ה", Latitude = 32.349776, Longitude = 34.926837 });
            st.Add(new Station() { CodeStation = 38870, Name = "הראשונים/כביש 5700", Latitude = 32.352953, Longitude = 34.899465 });
            st.Add(new Station() { CodeStation = 38872, Name = "הגאון בן איש חי/צאלון", Latitude = 31.897286, Longitude = 34.775083 });
            st.Add(new Station() { CodeStation = 38873, Name = "עוקשי/לוי אשכול", Latitude = 31.883941, Longitude = 34.807039 });
            st.Add(new Station() { CodeStation = 38875, Name = "מנוחה ונחלה/יהודה גורודיסקי", Latitude = 31.896762, Longitude = 34.816752 });
            st.Add(new Station() { CodeStation = 38876, Name = "גורודסקי/יחיאל פלדי", Latitude = 31.898463, Longitude = 34.823461 });
            st.Add(new Station() { CodeStation = 38877, Name = "דרך מנחם בגין/יעקב חזן", Latitude = 32.076535, Longitude = 34.904907 });
            st.Add(new Station() { CodeStation = 38878, Name = "דרך הפארק/הרב נריה", Latitude = 32.299994, Longitude = 34.878765 });
            st.Add(new Station() { CodeStation = 38879, Name = "התאנה/הגפן", Latitude = 31.865457, Longitude = 34.859437 });
            st.Add(new Station() { CodeStation = 3880, Name = "התאנה/האלון", Latitude = 31.866772, Longitude = 34.864555 });

            st.Add(new Station() { CodeStation = 3881, Name = "דרך הפרחים/יסמין", Latitude = 31.809325, Longitude = 31.809325 });
            st.Add(new Station() { CodeStation = 3883, Name = "יצחק רבין/פנחס ספיר", Latitude = 31.80037, Longitude = 34.778239 });
            st.Add(new Station() { CodeStation = 3884, Name = "מנחם בגין/יצחק רבין", Latitude = 31.799224, Longitude = 34.782985 });
            st.Add(new Station() { CodeStation = 3885, Name = "חיים הרצוג/דולב", Latitude = 31.800334, Longitude = 34.785069 });
            st.Add(new Station() { CodeStation = 3886, Name = "בית ספר גוונים/ארז", Latitude = 31.802319, Longitude = 34.786735 });
            st.Add(new Station() { CodeStation = 3887, Name = "דרך האילנות/אלון", Latitude = 31.804595, Longitude = 34.786623 });
            st.Add(new Station() { CodeStation = 3888, Name = "דרך האילנות/מנחם בגין", Latitude = 31.805041, Longitude = 34.785098 });
            st.Add(new Station() { CodeStation = 3889, Name = "העצמאות/וייצמן", Latitude = 31.816751, Longitude = 34.782252 });
            st.Add(new Station() { CodeStation = 3890, Name = "וייצמן/מרבד הקסמים", Latitude = 31.816579, Longitude = 34.779753 });
            st.Add(new Station() { CodeStation = 3891, Name = "צאלה/אלמוג", Latitude = 31.801182, Longitude = 31.801182 });


        }
    }
}

            //-----------------------------------------------------------------------------------------

/*
            for (int i = 1; i < 11; i++)
            {

                Line l = new Line();//create line
                l.LineID = Configuration.staticline++;//מס  יחודי של הקו---מס רץ---לאזורים וכאלה
                l.Code = Configuration.staticline * 10;//---אולי הפוך-----לשאול----מס הקו.. 
                int h = r.Next(0, 8);
                switch (h)
                {
                    case 0: { l.Area = Areas.General; break; }
                    case 1: { l.Area = Areas.North; break; }
                    case 2: { l.Area = Areas.South; break; }
                    case 3: { l.Area = Areas.East; break; }
                    case 4: { l.Area = Areas.West; break; }
                    case 5: { l.Area = Areas.Center; break; }
                    case 6: { l.Area = Areas.LowLand; break; }
                    case 7: { l.Area = Areas.Jerusalem; break; }

                }

                //create 10 linestations for the  specific line
                //create adjcent stations
                for (int j = 1; i < 11; j++)
                {
                    double a = 0, b = 0;
                    TimeSpan t = new TimeSpan();
                    if (j == 1)
                    {
                        ListLineStations.Add(new LineStation()
                        {
                            LineId = i,
                            StationCode = ListStations[Configuration.staticforlinestation].CodeStation,
                            LineStationIndex = j,
                            PrevStationCode = 0,
                            NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation
                        });//0 because there is no prev station for first station
                        a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation + 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation + 1].Longitude, 2));
                        b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
                        t = TimeSpan.FromHours(b);
                        ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation + 1].CodeStation, Distance = a, Time = t });//
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
                        ListLineStations.Add(new LineStation()
                        {
                            LineId = i,
                            StationCode = ListStations[Configuration.staticforlinestation].CodeStation,
                            LineStationIndex = j,
                            PrevStationCode = ListStations[Configuration.staticforlinestation - 1].CodeStation,
                            NextStationCode = ListStations[Configuration.staticforlinestation + 1].CodeStation
                        });
                        a = Math.Sqrt(Math.Pow(ListStations[Configuration.staticforlinestation].Latitude - ListStations[Configuration.staticforlinestation + 1].Latitude, 2) + Math.Pow(ListStations[Configuration.staticforlinestation].Longitude - ListStations[Configuration.staticforlinestation + 1].Longitude, 2));
                        b = (a * 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
                                           //t = new TimeSpan((long)b);
                        t = TimeSpan.FromHours(b);
                        ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation + 1].CodeStation, Distance = a, Time = t });//
                        //ListAdjacentStations.Add(new AdjacentStations() { Station1Code = ListStations[Configuration.staticforlinestation - 1].CodeStation, Station2Code = ListStations[Configuration.staticforlinestation].CodeStation });//
                    }
                    Configuration.staticforlinestation++;
                    if (Configuration.staticforlinestation == 49)//in case that the physical station end---go to the begining of the list stations
                        Configuration.staticforlinestation = 0;
                }
                //




                ListLines.Add(l);
            }

            for (int i = 0; i < 10; i++)//
            {
                LineTrip lt = new LineTrip();
                lt.LineTripId = Configuration.staticforlinetrip++;
                lt.LineId = ListLines[i].LineID;
                TimeSpan t = (TimeSpan.FromMinutes(r.Next(0, 60)));//תדירות בין 0 ל60
                lt.Frequency = t;
                int hours = r.Next(5, 24);
                int minutes = r.Next(0, 60);
                TimeSpan tt = new TimeSpan(hours, minutes, 0);
                lt.StartAt = tt;//זמן יציאת קו
                int h = r.Next(0, 3);
                int m = r.Next(0, 60);
                TimeSpan ttt = new TimeSpan(h, m, 0);
                lt.TimeTrip = ttt;//משך זמן הנסיעה--שדה שהוספנו
                lt.FinishAt = tt + ttt;//זמן סיום----זה זמן התחלת נסיעה פלוס זמן הנסיעה
                ListLineTrips.Add(lt);//הוספה לרשימה

            }
            //
            //ListTrips = new List<Trip>();
            for (int i = 1; i < 11; i++)
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
                t.LineId = ListLines[i - 1].LineID;//מספר הקו מתוך רשימת הקווים
                int h = r.Next(0, 3);//זמן נסיעה עד 2 שעות
                int m = r.Next(1, 60);//פלוס כל הדקות
                TimeSpan ttt = new TimeSpan(h, m, 0);
                t.TimeTrip = ttt;//זמן הנסיעה
                t.OutAt = tt + ttt;//זמן ירידה מהנסיעה זה זמן עליה ועוד זמן הנסיעה 
                ListTrips.Add(t);
            }
            string[] arr = { "Tehila", "Sara", "Ayala", "Achinoam", "Refael", "Yaakov", "Mimi", "Lea", "Chana", "Eli" };
            for (int i = 0; i < 10; i++)
            {
                ListTrips[i].UserName = arr[i];
            }

        }
    }
    }
}*/
