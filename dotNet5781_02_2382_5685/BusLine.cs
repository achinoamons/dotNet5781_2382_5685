using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    enum Areas { General = 1, North, South, East, West, Center, LowLand, Jerusalem };
    class BusLine
    {
        List<BusLineStation> Stations = new List<BusLineStation>();
        string busLine;
        BusLineStation LastStation;//the last station of the busline
        BusLineStation FirstStation;//the first station of the busline
        string area;
        public string ProBusLine { get => busLine; set => busLine = value; }
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
        public override string ToString()//overriding tostring of object
        {
            string s = "Line number:" + busLine + "Line area: " + area;//Threading line number and line area

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                s += "The route of the line:";
                string str = "";
                foreach (BusLineStation busLineStation in Stations)//Threading all the routes
                {
                    str += busLineStation.ProbusStationKey;
                    str += ",";
                }
                s += str;
                return s;
            }
            else//if the station is empty
            {
                s += "There is no route to the line";
            }
            return s;
        }
        public bool CheckStation(string numstation)
        {
            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                foreach (BusLineStation busLineStation in Stations)//cheke if the station is exist
                {
                    if (busLineStation.ProbusStationKey == numstation)
                        return true;

                }
            }
            return false;
        }
        public void AddStation(BusLineStation station,BusLineStation afterstation)//add a new station after spesific station
        {
            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                bool b = false;
                int counter = 0;
                foreach (BusLineStation busLineStation in Stations)//cheke if the afterstation is exist
                {
                    if (busLineStation.ProbusStationKey == afterstation.ProbusStationKey)//if we found the afterstation
                    {
                        Stations.Insert(counter, station);//insert the new station
                        b= true;
                    }
                    if (b == true)
                        break;
                }

            }
            //תזרוק חריגה שהתחנה אחריה רצינו להוסיף את התחנה אינה קיימת אן שכל הרשימה ריקה

        }
    }
}

  
            
  






