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
        static int help = 1;
        static int help1 = 2;
        //

        public static List<Line> ListLines;//
        public static List<LineStation> ListLineStations;//
        public static List<LineTrip> ListLineTrips;
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
            ListLines = new List<Line>
            {
                new Line

                {
                     LineID=1,
                      Code =11,
                    Area=Areas.Center,
                    FirstStation =1,
                     LastStation=2
                },

                new Line
                {
                    LineID=2,
                      Code =22,
                    Area=Areas.East,
                    FirstStation =1,
                     LastStation=3
                },

                new Line
                {
                   LineID=3,
                      Code =33,
                    Area=Areas.Jerusalem,
                    FirstStation =3,
                     LastStation=7
                }
            };
            //
            ListStations = new List<Station>();

           
            for (int i = 0; i < 4; i++)
                {

                Station st = new Station();
                st.CodeStation = help++;
                st.Latitude= (int)(r.NextDouble() * (31 - 33.3) + 31);
                st.Longitude = (int)(r.NextDouble() * (34.3 - 35.5) + 34.3);
                ListStations.Add(st);
                }
            ListStations[0].Name = "Shal st.-Gold st.";
            ListStations[1].Name = "Shal st.-Havaad Haleumi";
            ListStations[2].Name = "Shahal st.-Heler st.";
            ListStations[3].Name = "Tzomet givat Mordechai-Biat";
            ListStations[4].Name = "Shaarey-Zedek";
            //
            ListLineStations = new List<LineStation>();
            for (int i = 0; i < 4; i++)
            {

                Station st = new Station();
                st.CodeStation = help++;
                st.Latitude = (int)(r.NextDouble() * (31 - 33.3) + 31);
                st.Longitude = (int)(r.NextDouble() * (34.3 - 35.5) + 34.3);
                ListStations.Add(st);
            }



        }
    }
}
