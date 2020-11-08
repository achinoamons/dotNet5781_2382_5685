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
                Areas a;
                a = (Areas)int.Parse(area);
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
        public void AddStation(BusLineStation station, BusLineStation afterstation)//add a new station after spesific station
        {
            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                bool b = false;
                int counter = 0;
                foreach (BusLineStation busLineStation in Stations)//cheke if the afterstation is exist
                {
                    if (busLineStation.ProbusStationKey == afterstation.ProbusStationKey)//if we found the afterstation
                        //אחינועם שואלת:אבל מה קורה אם אני רוצה להוסיף תחנה שכבר קיימת?
                    {
                        Stations.Insert(counter, station);//insert the new station
                        b = true;
                    }
                    if (b == true)
                        break;
                }

            }
            //תזרוק חריגה שהתחנה אחריה רצינו להוסיף את התחנה אינה קיימת אן שכל הרשימה ריקה

        }
        public double DistanceBetween2Stations(BusLineStation s1, BusLineStation s2)
        {
            double d = 0;

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                bool flag = false;
                //למצוא דרך לרשום נכון את בי וסי לראות אם קיימים
                bool b = Stations.Find(s1);//to check if it exist
                bool c = Stations.Find(s2);
                if (b && c)
                {
                    if (Stations.IndexOf(s1) > Stations.IndexOf(s2))//s1 is the second station
                    {
                        foreach (BusLineStation busLineStation in Enumerable.Reverse(Stations))//
                        {
                            if (busLineStation.ProbusStationKey == s1.ProbusStationKey)//if i find s1
                            { flag = true; }
                            if (flag)
                            {
                                while (busLineStation.ProbusStationKey != s2.ProbusStationKey)//כל עוד לא הגעתי למחרוזת השניה
                                { d += busLineStation.ProDistanceLastStation; }
                                break;
                            }


                        }
                        return d;
                    }

                    else if (Stations.IndexOf(s1) <= Stations.IndexOf(s2))//s2 is second station or equal
                    {
                        foreach (BusLineStation busLineStation in Enumerable.Reverse(Stations))//
                        {
                            if (busLineStation.ProbusStationKey == s2.ProbusStationKey)
                            {//if i find s2
                                flag = true;
                            }
                            if (flag)
                            {
                                while (busLineStation.ProbusStationKey != s1.ProbusStationKey)
                                { d += busLineStation.ProDistanceLastStation; }
                                break;
                            }

                        }
                        return d;
                    }
                }
                //אלס-זרוק חריגה שאחד מהתחנות או שניהם בכלל לא נמצאים
            }
            //אלס---זרוק חריגה שהרשימה בכלל ריקה

        }
        public TimeSpan TimeBetween2Stations(BusLineStation s1, BusLineStation s2)
        {
            TimeSpan t = new TimeSpan(00, 00, 00);//i strat in time 0

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                bool flag = false;
                //למצוא דרך לרשום נכון את בי וסי לראות אם קיימים
                bool b = Stations.Find(s1);//to check if it exist
                bool c = Stations.Find(s2);
                if (b && c)
                {
                    if (Stations.IndexOf(s1) > Stations.IndexOf(s2))//s1 is the second station
                    {
                        foreach (BusLineStation busLineStation in Enumerable.Reverse(Stations))//
                        {
                            if (busLineStation.ProbusStationKey == s1.ProbusStationKey)//if i find s1
                            { flag = true; }
                            if (flag)
                            {
                                while (busLineStation.ProbusStationKey != s2.ProbusStationKey)//כל עוד לא הגעתי למחרוזת השניה
                                { t += busLineStation.ProTimeLastStation; }
                                break;
                            }


                        }
                        return t;
                    }
                    else if (Stations.IndexOf(s1) <= Stations.IndexOf(s2))//s2 is second station or equal
                    {
                        foreach (BusLineStation busLineStation in Enumerable.Reverse(Stations))//
                        {
                            if (busLineStation.ProbusStationKey == s2.ProbusStationKey)
                            {//if i find s2
                                flag = true;
                            }
                            if (flag)
                            {
                                while (busLineStation.ProbusStationKey != s1.ProbusStationKey)
                                { t += busLineStation.ProTimeLastStation; }
                                break;
                            }

                        }
                        return t;
                    }
                }
                //אלס-זרוק חריגה שאחד מהתחנות או שניהם בכלל לא נמצאים
            }
            //אלס---זרוק חריגה שהרשימה בכלל ריקה

        }
   }
 }
    


  
            
  






