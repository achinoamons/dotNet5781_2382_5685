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
        public static List<Line> ListLines;
        public static List<LineStation> ListLineStations;
        public static List<LineTrip> ListLineTrips;
        public static List<Station> ListStations;
        public static List<Trip> ListTrips;
        public static List<AdjacentStations> ListAdjacentStations;

        static DataSource()
        {
            InitAllLists();
        }
        static  void InitAllLists()
        {


        }
    }
}
