using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
        // מה קורה במידה וזה התחנה הרששונה שרוצים להוסיף
        public void AddStation(BusLineStation station, BusLineStation afterstation)//add a new station after spesific station
        {
            bool isEmpty = !Stations.Any();//if the station us not empty
            if (isEmpty && afterstation == null)//if the station is the first station
            {
                Stations.Add(station);
            }
            else
            {
                bool b = false;
                int counter = 0;
                foreach (BusLineStation busLineStation in Stations)//cheke if the afterstation is exist
                {
                    if (busLineStation.ProbusStationKey == afterstation.ProbusStationKey)//if we found the afterstation
                    {
                        Stations.Insert(counter, station);//insert the new station
                        b = true;
                    }
                    else
                        counter++;
                    if (b == true)
                        break;

                }
            }


        }
        public void DeletStation(string numstation)//delet station 
        {
            bool isEmpty = !Stations.Any();
            if (isEmpty)
            {
                //תזרוק חריגה שאין שום תחנה והרשימה ריקה אז אין את מי למחוק
            }
            else
            {
                int counter = 0;
                foreach (BusLineStation busLineStation in Stations)//cheke if the station is exist
                {
                    if (busLineStation.ProbusStationKey == numstation)
                    {
                        Stations.RemoveAt(counter);//delet the station
                        break;
                    }
                    counter++;
                }
                //לזרוק חריגה שהוא לא מצא תחנה בשם הזה

            }
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
    

public BusLine SubLine (BusLineStation station1, BusLineStation station2)//Returns a new Autos subline
        {

                int index1 = -1, index2 = -1;
                for (int i = 0; i < Stations.Count; i++)//loking for the first station
                {
                    if (Stations[i].ProbusStationKey == station1.ProbusStationKey)
                        index1 = i;
                }
                if (index1 == -1)//if the first station is not exsist
                {
                    //תזרוק שגיאה לא קיימת התחנה הראשונה
                }
                for (int i = 0; i < Stations.Count; i++)//loking for the second station
                {
                    if (Stations[i].ProbusStationKey == station2.ProbusStationKey)
                        index2 = i;
                }
                if (index2 == -1)//if the second station is not exsist
                {
                    //תזרוק שגיאה לא קיימת התחנה השניה
                }
                int min = 0, max = 0;
                min = Math.Min(index1, index2);
                max = Math.Max(index1, index2);
                BusLine newbus = new BusLine();
                for (int i = min,  j=0 ; i <= max; i++,j++)
                {
                    newbus.Stations[j] = Stations[i];//copy the sub line to the new bus
                }
                return newbus;
           
            }
    }
}












