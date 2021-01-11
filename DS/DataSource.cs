
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
        public static List<Line> listLines;




        //public static List<BusOnTrip> listBusOnTrip;
        public static object listUser;
       
        public static Random r = new Random(DateTime.Now.Millisecond);


        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            #region buses//איתחול אוטובוסים
            listBus = new List<Bus>();
            for (int i = 0; i < 20; i++)
            {
                Bus b = new Bus
                {
                    LicenseNum = 1245670 + i,
                    Mileage = 100.0,
                    FuelTank = 50.3,
                    Status = BusStatus.readyForTravel
                };
                listBus.Add(b);
            }
            #endregion

            #region Boot stations//איתחול תחנות
            listStations = new List<Station>();
            listStations.Add(new Station() { CodeStation = 38831, Name = "בי'ס בר לב/בן יהודה", Latitude = 32.183921, Longitude = 34.917806 });
            listStations.Add(new Station() { CodeStation = 38832, Name = "הרצל/צומת בילו", Latitude = 31.870034, Longitude = 34.819541 });
            listStations.Add(new Station() { CodeStation = 38833, Name = "הנחשול/הדייגים", Latitude = 31.984553, Longitude = 34.782828 });
            listStations.Add(new Station() { CodeStation = 38834, Name = "פריד/ששת הימים", Latitude = 31.88855, Longitude = 34.790904 });
            listStations.Add(new Station() { CodeStation = 38836, Name = "ת. מרכזית לוד/הורדה", Latitude = 31.956392, Longitude = 34.898098 });
            listStations.Add(new Station() { CodeStation = 38837, Name = "חנה אברך/וולקני", Latitude = 31.892166, Longitude = 34.796071 });
            listStations.Add(new Station() { CodeStation = 38838, Name = "הרצל/משה שרת", Latitude = 31.857565, Longitude = 34.824106 });
            listStations.Add(new Station() { CodeStation = 38839, Name = "הבנים/אלי כהן", Latitude = 31.862305, Longitude = 34.821857 });
            listStations.Add(new Station() { CodeStation = 38840, Name = "ויצמן/הבנים", Latitude = 31.865085, Longitude = 34.822237 });
            listStations.Add(new Station() { CodeStation = 38841, Name = "האירוס/הכלנית", Latitude = 31.865222, Longitude = 34.818957 });

            listStations.Add(new Station() { CodeStation = 38842, Name = "הכלנית/הנרקיס", Latitude = 31.867597, Longitude = 34.818392 });
            listStations.Add(new Station() { CodeStation = 38844, Name = "אלי כהן/לוחמי הגטאות", Latitude = 31.86244, Longitude = 34.827023 });
            listStations.Add(new Station() { CodeStation = 38845, Name = "שבזי/שבת אחים", Latitude = 31.863501, Longitude = 34.828702 });
            listStations.Add(new Station() { CodeStation = 38846, Name = "שבזי/ויצמן", Latitude = 31.865348, Longitude = 34.827102 });
            listStations.Add(new Station() { CodeStation = 38847, Name = "חיים בר לב/שדרות יצחק רבין", Latitude = 31.977409, Longitude = 34.763896 });
            listStations.Add(new Station() { CodeStation = 38848, Name = "מרכז לבריאות הנפש לב השרון", Latitude = 32.300345, Longitude = 34.912708 });
            listStations.Add(new Station() { CodeStation = 38849, Name = "מרכז לבריאות הנפש לב השרון", Latitude = 32.301347, Longitude = 34.912602 });
            listStations.Add(new Station() { CodeStation = 38852, Name = "הולצמן/המדע", Latitude = 31.914255, Longitude = 34.807944 });
            listStations.Add(new Station() { CodeStation = 38854, Name = "מחנה צריפין/מועדון", Latitude = 31.963668, Longitude = 34.836363 });
            listStations.Add(new Station() { CodeStation = 38855, Name = "הרצל/גולני", Latitude = 31.856115, Longitude = 34.825249 });

            listStations.Add(new Station() { CodeStation = 38856, Name = "הרותם/הדגניות", Latitude = 31.874963, Longitude = 34.81249 });
            listStations.Add(new Station() { CodeStation = 38859, Name = "הערבה", Latitude = 32.300035, Longitude = 34.910842 });
            listStations.Add(new Station() { CodeStation = 38860, Name = "מבוא הגפן/מורד התאנה", Latitude = 32.305234, Longitude = 34.948647 });
            listStations.Add(new Station() { CodeStation = 38861, Name = "מבוא הגפן/ההרחבה", Latitude = 32.304022, Longitude = 34.943393 });
            listStations.Add(new Station() { CodeStation = 38862, Name = "ההרחבה א", Latitude = 32.302957, Longitude = 34.940529 });
            ///////////////
            listStations.Add(new Station() { CodeStation = 38863, Name = "ההרחבה ב", Latitude = 32.300264, Longitude = 34.939512 });
            listStations.Add(new Station() { CodeStation = 38864, Name = "ההרחבה/הותיקים", Latitude = 32.298171, Longitude = 34.939512 });
            listStations.Add(new Station() { CodeStation = 38865, Name = "רשות שדות התעופה/העליה", Latitude = 31.990876, Longitude = 34.8976 });
            listStations.Add(new Station() { CodeStation = 38866, Name = "כנף/ברוש", Latitude = 31.998767, Longitude = 34.879725 });
            listStations.Add(new Station() { CodeStation = 38867, Name = "החבורה/דב הוז", Latitude = 31.883019, Longitude = 34.818708 });

            listStations.Add(new Station() { CodeStation = 38869, Name = "בית הלוי ה", Latitude = 32.349776, Longitude = 34.926837 });
            listStations.Add(new Station() { CodeStation = 38870, Name = "הראשונים/כביש 5700", Latitude = 32.352953, Longitude = 34.899465 });
            listStations.Add(new Station() { CodeStation = 38872, Name = "הגאון בן איש חי/צאלון", Latitude = 31.897286, Longitude = 34.775083 });
            listStations.Add(new Station() { CodeStation = 38873, Name = "עוקשי/לוי אשכול", Latitude = 31.883941, Longitude = 34.807039 });
            listStations.Add(new Station() { CodeStation = 38875, Name = "מנוחה ונחלה/יהודה גורודיסקי", Latitude = 31.896762, Longitude = 34.816752 });
            listStations.Add(new Station() { CodeStation = 38876, Name = "גורודסקי/יחיאל פלדי", Latitude = 31.898463, Longitude = 34.823461 });
            listStations.Add(new Station() { CodeStation = 38877, Name = "דרך מנחם בגין/יעקב חזן", Latitude = 32.076535, Longitude = 34.904907 });
            listStations.Add(new Station() { CodeStation = 38878, Name = "דרך הפארק/הרב נריה", Latitude = 32.299994, Longitude = 34.878765 });
            listStations.Add(new Station() { CodeStation = 38879, Name = "התאנה/הגפן", Latitude = 31.865457, Longitude = 34.859437 });
            listStations.Add(new Station() { CodeStation = 3880, Name = "התאנה/האלון", Latitude = 31.866772, Longitude = 34.864555 });

            listStations.Add(new Station() { CodeStation = 3881, Name = "דרך הפרחים/יסמין", Latitude = 31.809325, Longitude = 31.809325 });
            listStations.Add(new Station() { CodeStation = 3883, Name = "יצחק רבין/פנחס ספיר", Latitude = 31.80037, Longitude = 34.778239 });
            listStations.Add(new Station() { CodeStation = 3884, Name = "מנחם בגין/יצחק רבין", Latitude = 31.799224, Longitude = 34.782985 });
            listStations.Add(new Station() { CodeStation = 3885, Name = "חיים הרצוג/דולב", Latitude = 31.800334, Longitude = 34.785069 });
            listStations.Add(new Station() { CodeStation = 3886, Name = "בית ספר גוונים/ארז", Latitude = 31.802319, Longitude = 34.786735 });
            listStations.Add(new Station() { CodeStation = 3887, Name = "דרך האילנות/אלון", Latitude = 31.804595, Longitude = 34.786623 });
            listStations.Add(new Station() { CodeStation = 3888, Name = "דרך האילנות/מנחם בגין", Latitude = 31.805041, Longitude = 34.785098 });
            listStations.Add(new Station() { CodeStation = 3889, Name = "העצמאות/וייצמן", Latitude = 31.816751, Longitude = 34.782252 });
            listStations.Add(new Station() { CodeStation = 3890, Name = "וייצמן/מרבד הקסמים", Latitude = 31.816579, Longitude = 34.779753 });
            listStations.Add(new Station() { CodeStation = 3891, Name = "צאלה/אלמוג", Latitude = 31.801182, Longitude = 31.801182 });

            #endregion

            
            #region lines//איתחול קווים

            listLines = new List<Line>();
            {
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 75, Area = Areas.Jerusalem, FirstStation = listStations[0].CodeStation, LastStation = listStations[4].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 76, Area = Areas.Jerusalem, FirstStation = listStations[5].CodeStation, LastStation = listStations[9].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 77, Area = Areas.Jerusalem, FirstStation = listStations[10].CodeStation, LastStation = listStations[14].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 78, Area = Areas.Jerusalem, FirstStation = listStations[15].CodeStation, LastStation = listStations[19].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 79, Area = Areas.Jerusalem, FirstStation = listStations[20].CodeStation, LastStation = listStations[24].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 80, Area = Areas.Jerusalem, FirstStation = listStations[25].CodeStation, LastStation = listStations[29].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 81, Area = Areas.Jerusalem, FirstStation = listStations[30].CodeStation, LastStation = listStations[34].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 82, Area = Areas.Jerusalem, FirstStation = listStations[35].CodeStation, LastStation = listStations[39].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 83, Area = Areas.Jerusalem, FirstStation = listStations[40].CodeStation, LastStation = listStations[44].CodeStation, });
                listLines.Add(new Line() { LineID = Configuration.staticline++, Code = 84, Area = Areas.Jerusalem, FirstStation = listStations[45].CodeStation, LastStation = listStations[49].CodeStation });



                #endregion lines

                #region LineStation//איתחול תחנות קו

                listLineStation = new List<LineStation>();
                {
                    ////linestation for line 1
                    ///

                    listLineStation.Add(new LineStation() { LineId = 1, StationCode = listStations[0].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[1].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 1, StationCode = listStations[1].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[0].CodeStation, NextStationCode = listStations[2].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 1, StationCode = listStations[2].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[1].CodeStation, NextStationCode = listStations[3].CodeStation });

                    listLineStation.Add(new LineStation() { LineId = 1, StationCode = listStations[3].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[2].CodeStation, NextStationCode = listStations[4].CodeStation });

                    listLineStation.Add(new LineStation() { LineId = 1, StationCode = listStations[4].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[3].CodeStation, NextStationCode = 0 });
                    ////linestation for line 2
                    listLineStation.Add(new LineStation() { LineId = 2, StationCode = listStations[5].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[6].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 2, StationCode = listStations[6].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[5].CodeStation, NextStationCode = listStations[7].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 2, StationCode = listStations[7].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[6].CodeStation, NextStationCode = listStations[8].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 2, StationCode = listStations[8].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[7].CodeStation, NextStationCode = listStations[9].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 2, StationCode = listStations[9].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[8].CodeStation, NextStationCode = 0 });
                    ////linestation for line 3
                    listLineStation.Add(new LineStation() { LineId = 3, StationCode = listStations[10].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[11].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 3, StationCode = listStations[11].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[10].CodeStation, NextStationCode = listStations[12].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 3, StationCode = listStations[12].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[11].CodeStation, NextStationCode = listStations[13].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 3, StationCode = listStations[13].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[12].CodeStation, NextStationCode = listStations[14].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 3, StationCode = listStations[14].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[13].CodeStation, NextStationCode = 0 });
                    ////linestation for line 4
                    listLineStation.Add(new LineStation() { LineId = 4, StationCode = listStations[15].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[16].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 4, StationCode = listStations[16].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[15].CodeStation, NextStationCode = listStations[17].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 4, StationCode = listStations[17].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[16].CodeStation, NextStationCode = listStations[18].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 4, StationCode = listStations[18].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[17].CodeStation, NextStationCode = listStations[19].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 4, StationCode = listStations[19].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[18].CodeStation, NextStationCode = 0 });
                    ////linestation for line 5
                    listLineStation.Add(new LineStation() { LineId = 5, StationCode = listStations[20].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[19].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 5, StationCode = listStations[21].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[20].CodeStation, NextStationCode = listStations[22].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 5, StationCode = listStations[22].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[21].CodeStation, NextStationCode = listStations[23].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 5, StationCode = listStations[23].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[22].CodeStation, NextStationCode = listStations[24].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 5, StationCode = listStations[24].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[23].CodeStation, NextStationCode = 0 });

                    ////linestation for line 6
                    listLineStation.Add(new LineStation() { LineId = 6, StationCode = listStations[25].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[26].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 6, StationCode = listStations[26].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[25].CodeStation, NextStationCode = listStations[27].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 6, StationCode = listStations[27].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[26].CodeStation, NextStationCode = listStations[28].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 6, StationCode = listStations[28].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[27].CodeStation, NextStationCode = listStations[29].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 6, StationCode = listStations[29].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[28].CodeStation, NextStationCode = 0 });

                    ////linestation for line 7
                    listLineStation.Add(new LineStation() { LineId = 7, StationCode = listStations[30].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[31].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 7, StationCode = listStations[31].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[30].CodeStation, NextStationCode = listStations[32].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 7, StationCode = listStations[32].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[31].CodeStation, NextStationCode = listStations[33].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 7, StationCode = listStations[33].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[32].CodeStation, NextStationCode = listStations[34].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 7, StationCode = listStations[34].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[33].CodeStation, NextStationCode = 0 });
                    ////linestation for line 8
                    listLineStation.Add(new LineStation() { LineId = 8, StationCode = listStations[35].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[36].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 8, StationCode = listStations[36].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[35].CodeStation, NextStationCode = listStations[37].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 8, StationCode = listStations[37].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[36].CodeStation, NextStationCode = listStations[38].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 8, StationCode = listStations[38].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[37].CodeStation, NextStationCode = listStations[39].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 8, StationCode = listStations[39].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[38].CodeStation, NextStationCode = 0 });

                    ////linestation for line 9
                    listLineStation.Add(new LineStation() { LineId = 9, StationCode = listStations[40].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[41].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 9, StationCode = listStations[41].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[40].CodeStation, NextStationCode = listStations[42].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 9, StationCode = listStations[42].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[41].CodeStation, NextStationCode = listStations[43].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 9, StationCode = listStations[43].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[42].CodeStation, NextStationCode = listStations[44].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 9, StationCode = listStations[44].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[43].CodeStation, NextStationCode = 0 });
                    ////linestation for line 10
                    listLineStation.Add(new LineStation() { LineId = 10, StationCode = listStations[45].CodeStation, LineStationIndex = 1, PrevStationCode = 0, NextStationCode = listStations[46].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 10, StationCode = listStations[46].CodeStation, LineStationIndex = 2, PrevStationCode = listStations[45].CodeStation, NextStationCode = listStations[47].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 10, StationCode = listStations[47].CodeStation, LineStationIndex = 3, PrevStationCode = listStations[46].CodeStation, NextStationCode = listStations[48].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 10, StationCode = listStations[48].CodeStation, LineStationIndex = 4, PrevStationCode = listStations[47].CodeStation, NextStationCode = listStations[49].CodeStation });
                    listLineStation.Add(new LineStation() { LineId = 10, StationCode = listStations[49].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[48].CodeStation, NextStationCode = 0 });

                    listLineStation.Add(new LineStation() { LineId = 1, StationCode = listStations[49].CodeStation, LineStationIndex = 5, PrevStationCode = listStations[48].CodeStation, NextStationCode = 0 });
                    #endregion listLineStation




                    #region InitialLineTrip//בונוס

                    //listLineTrip = new List<LineTrip>
                    //{
                    //    new LineTrip
                    //    {
                    //        LineId = 1,
                    //        StartAt = new TimeSpan(7,0,0),
                    //        FinishAt = new TimeSpan(23,0,0),
                    //        Frequency = new TimeSpan(0,30,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 2,
                    //        StartAt = new TimeSpan(6,15,0),
                    //        FinishAt = new TimeSpan(18,45,0),
                    //        Frequency = new TimeSpan(0,30,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 3,
                    //        StartAt = new TimeSpan(8,20,0),
                    //        FinishAt = new TimeSpan(23,40,0),
                    //        Frequency = new TimeSpan(0,20,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 4,
                    //        StartAt = new TimeSpan(7,0,0),
                    //        FinishAt = new TimeSpan(21,0,0),
                    //        Frequency = new TimeSpan(1,0,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 5,
                    //        StartAt = new TimeSpan(8,30,0),
                    //        FinishAt = new TimeSpan(22,0,0),
                    //        Frequency = new TimeSpan(0,20,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 6,
                    //        StartAt = new TimeSpan(7,0,0),
                    //        FinishAt = new TimeSpan(0,0,0),
                    //        Frequency = new TimeSpan(0,15,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 7,
                    //        StartAt = new TimeSpan(9,30,0),
                    //        FinishAt = new TimeSpan(21,30,0),
                    //        Frequency = new TimeSpan(1,0,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 8,
                    //        StartAt = new TimeSpan(14,0,0),
                    //        FinishAt = new TimeSpan(1,0,0),
                    //        Frequency = new TimeSpan(30,0,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 9,
                    //        StartAt = new TimeSpan(6,20,0),
                    //        FinishAt = new TimeSpan(0,10,0),
                    //        Frequency = new TimeSpan(0,10,0)
                    //    },
                    //    new LineTrip
                    //    {
                    //        LineId = 10,
                    //        StartAt = new TimeSpan(7,45,0),
                    //        FinishAt = new TimeSpan(13,0,0),
                    //        Frequency = new TimeSpan(0,15,0)
                    //    }
                    //};

                    #endregion lLineTrip
                    #region AdjacentStations//איתחול תחנות עוקבות 

                    listAdjacentStation = new List<AdjacentStations>();
                    double a = 0, b = 0;
                    TimeSpan t = new TimeSpan();

                    for (int i = 0; i < listLineStation.Count; i++)
                    {
                        if (listLineStation[i].NextStationCode != 0)
                        {
                            
                            AdjacentStations ads = new AdjacentStations();
                            ads.Station1Code = listLineStation[i].StationCode;
                            ads.Station2Code = listLineStation[i].NextStationCode;
                            a = Math.Sqrt(Math.Pow(listStations[listStations.IndexOf(listStations.Find(p => p.CodeStation == ads.Station1Code))].Latitude - listStations[listStations.IndexOf(listStations.Find(p => p.CodeStation == ads.Station2Code))].Latitude, 2) + Math.Pow(listStations[listStations.IndexOf(listStations.Find(p => p.CodeStation == ads.Station1Code))].Longitude - listStations[listStations.IndexOf(listStations.Find(p => p.CodeStation == ads.Station2Code))].Longitude, 2));
                            //b = (a + 0.5) / 70;//דרך לחלק למהירות שווה זמן--ומהירות ממוצעת 70
                            //t = TimeSpan.FromHours(b);
                            ads.Distance = (a + 0.5) /*b*/;

                            ads.Time = TimeSpan.FromHours((a + 0.5) / 70);
                          
                            listAdjacentStation.Add(ads);
                        }
                    }

                    #endregion AdjacentStations
                }
            }
        }
    }
}

#region ours
////using System;
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



//           for (int i = 1; i < 11; i++){

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
//}}
//////////////////////////////////////////////////////////////////////////////////
#endregion






