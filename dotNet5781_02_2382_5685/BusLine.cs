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
        string busLine;//
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
                Areas a;
                a= (Areas)int.Parse(area);
                string ch = "";
                switch (a)//returning the field according to its name
                {
                    case Areas.General:
                        ch = "General";
                        break;
                    case Areas.North:
                        ch = "North";
                        break;
                    case Areas.South:
                        ch = "South";
                        break;
                    case Areas.East:
                        ch = "East";
                        break;
                    case Areas.West:
                        ch = "West";
                        break;
                    case Areas.Center:
                        ch = "Center";
                        break;
                    case Areas.LowLand:
                        ch = "LowLand";
                        break;
                    case Areas.Jerusalem:
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
