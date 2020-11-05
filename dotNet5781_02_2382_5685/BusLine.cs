using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    enum Areas { General=1, North ,South,East,West,Center, LowLand,Jerusalem };
    class BusLine
    {
        List<BusLineStation> Stations = new List<BusLineStation>();
        string busLine;
        public string ProBusLine { get => busLine; set => busLine = value; }
        BusLineStation FirstStation;//the first station of the busline
        public BusLineStation ProFirstStation//property of the first station
        {
            set
            {
                FirstStation = value;
                Stations.Add(FirstStation);
            }
            get
            {
                return FirstStation;
            }
        }
        public BusLineStation ProLastStation//property of the last station
        {
            set
            {
                LastStation = value;
                Stations.Add(LastStation);
            }
            get
            {
                return LastStation;
            }
        }


        BusLineStation LastStation;//the last station of the busline
        BusLine()
        {
            Stations.Add(FirstStation);
            Stations.Add(LastStation);
        }
        string area;
        public string ProArea
         {
            set
            {
                area = value;
            }
            get
            {
                string ch = "";
                switch (int.Parse(area))//returning the field according to its name
                {
                    case 1:
                        ch = "General";
                        break;
                    case 2:
                        ch = "North";
                        break;
                    case 3:
                        ch = "South";
                        break;
                    case 4:
                        ch = "East";
                        break;
                    case 5:
                        ch = "West";
                        break;
                    case 6:
                        ch = "Center";
                        break;
                    case 7:
                        ch = "LowLand";
                        break;
                    case 8:
                        ch = "Jerusalem";
                        break;


                    default:
                        break;
                }
                return ch;


            }
        }

        



    }
}
