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
        BusLineStation LastStation;//the last station of the busline
        BusLineStation FirstStation;//the first station of the busline
        string area;
        public string ProBusLine { get => busLine; set => busLine = value; 
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
        BusLine()
        {
            Stations.Add(FirstStation);
            Stations.Add(LastStation);
        }
       
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




                    default:
                        break;
                }
                return ch;


            }
        }

        



    }
}
