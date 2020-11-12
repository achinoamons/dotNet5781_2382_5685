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
    enum Areas { General = 1, North, South, East, West, Center, LowLand, Jerusalem };//we decided to to interurban bus lines
    class BusLine: IComparable
    {
        List<BusLineStation> Stations = new List<BusLineStation>();
        int numLine;//THE NUMBER OF THE LINE
        BusLineStation LastStation;//the last station of the busline
        BusLineStation FirstStation;//the first station of the busline
        string area;
        BusLine(int num, BusLineStation last, BusLineStation first)

        public int ProNumLine
        { 
            get => numLine;
            set {
                if(value<=0)
                    throw new BusException("Error!number of line cannot be negative or 0");
               else
                numLine = value; }
        } 
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
            string s = "Line number:" + numLine + "Line area: " + area;//Threading line number and line area

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
        public bool CheckStation(int numstation)
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
        public void AddStation(BusLineStation station)//add a new station after spesific station
        {
            bool isEmpty = !Stations.Any();//if the station us not empty
            if (isEmpty)//if the list is empty
            {
                Stations.Add(station);//
                ProFirstStation = ProLastStation = station;//update the first and last stations
            }
            else
            {
                bool b = false;
               
                foreach (BusLineStation busLineStation in Stations)//cheke if the afterstation is exist
                {

                    if (busLineStation.ProbusStationKey == station.ProbusStationKey)//if the station already exist
                    {
                        throw new BusException(" Error! This station already exist");
                    }
                }
                for(int i=0;i<Stations.Count;i++)//finding the suitable place for the station
                {

                    if (Stations[i].ProbusStationKey < station.ProbusStationKey&& Stations[i+1].ProbusStationKey> station.ProbusStationKey)//finding suitable place
                    {

                        Stations.Insert(i + 1, station);//adding
                        //updating the relevant fields
                        double dis = DistanceBetween2Stations(Stations[i], Stations[i+1]);
                        Stations[i+1].ProDistanceLastStation = dis;//updating the distance field of the station that i add;
                        Stations[i + 2].ProDistanceLastStation -= dis;
                        TimeSpan t = new TimeSpan(0, 0, 0);
                        t = TimeBetween2Stations(Stations[i], Stations[i + 1]);
                        Stations[i + 1].ProTimeLastStation = t;//updating the TIME field of the station that i add;
                        Stations[i + 2].ProTimeLastStation -= t;
                        break;

                    }
                }



            }
        }
        public void DeletStation(BusLineStation numstation)//delet station 
        {
            bool isEmpty = !Stations.Any();
            if (isEmpty)
            {
                throw new BusException("Error!, The list is empty ");
            }
            else
            {
                int counter = 0;
                foreach (BusLineStation busLineStation in Stations)//cheke if the station is exist
                {
                    if (busLineStation.ProbusStationKey == numstation.ProbusStationKey)
                    {
                        if (numstation.ProbusStationKey==ProFirstStation.ProbusStationKey)//if we want to delete the first station
                        {
                            //updating the relevant fields
                            Stations[1].ProDistanceLastStation = 0;
                            TimeSpan t = new TimeSpan(0, 0, 0);
                            Stations[1].ProTimeLastStation = t;
                            ProFirstStation = Stations[1];//update the first station field
                           Stations.RemoveAt(0);//delet the station
                            break;
                        }
                        if (numstation.ProbusStationKey == ProLastStation.ProbusStationKey)//if the delete station is the last
                        {
                            int g = Stations.Count;
                            ProLastStation = Stations[g-2];//because the index begin from 0
                            Stations.RemoveAt(g-1);
                            break;
                        }
                        else//deleting another station
                        {
                            //update the relevant fields
                            Stations[counter + 1].ProDistanceLastStation += Stations[counter].ProDistanceLastStation;
                            Stations[counter + 1].ProTimeLastStation += Stations[counter].ProTimeLastStation;
                            Stations.RemoveAt(counter);
                            break;
                        }
                        
                    }
                    counter++;
                }
                throw new BusException(" Error! This station does not exist");

            }
        }

        public double DistanceBetween2Stations(BusLineStation s1, BusLineStation s2)
        {
            double d = 0;

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {

                // BusLineStation bs1 = Stations.Find ( item => item.ProbusStationKey == s1.ProbusStationKey);//check if s1 exist
                // BusLineStation bs2 = Stations.Find(item => item.ProbusStationKey == s2.ProbusStationKey);//check if s2 exist

                //bool b = Stations.Find(s1);//to check if it exist
                //bool c = Stations.Find(s2);
                bool c = false, b = false;
                 for (int i = 0; i < Stations.Count; i++)//loking for the first station
                 {
                     if (Stations[i].ProbusStationKey == s1.ProbusStationKey)
                         b = true;
                     break;

                 }
                 for (int i = 0; i < Stations.Count; i++)//loking for the second station
                 {
                     if (Stations[i].ProbusStationKey == s2.ProbusStationKey)
                         c= true;
                     break;

                 }
                if (b && c)//if they both exist
                {
                    if (s1.ProbusStationKey == s2.ProbusStationKey)//if its the same station
                        return 0;
                    int min = 0, max = 0;
                    min = Math.Min(Stations.IndexOf(s1), Stations.IndexOf(s2));
                    max = Math.Max(Stations.IndexOf(s1), Stations.IndexOf(s2));
                    BusLine newbus = new BusLine();
                    for (int i = max; i <min; i--)
                    {
                        d += Stations[i].ProDistanceLastStation;
                    }
                     
                        return d;
                    
                }
                throw new BusException("Error!one or more of the stations isn't exist");
            }
            throw new BusException("Error!the list of stations already empty");

        }
        public TimeSpan TimeBetween2Stations(BusLineStation s1, BusLineStation s2)
        {
            TimeSpan t = new TimeSpan(00, 00, 00);//i strat in time 0

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                
                //למצוא דרך לרשום נכון את בי וסי לראות אם קיימים
                // bool b = Stations.Find(s1);//to check if it exist
                // bool c = Stations.Find(s2);
                bool b = false, c = false;
                for (int i = 0; i < Stations.Count; i++)//loking for the first station
                {
                    if (Stations[i].ProbusStationKey == s1.ProbusStationKey)
                        b = true;
                    break;

                }
                for (int i = 0; i < Stations.Count; i++)//loking for the second station
                {
                    if (Stations[i].ProbusStationKey == s2.ProbusStationKey)
                        c = true;
                    break;

                }
                if (b && c)

                {
                    if (s1.ProbusStationKey == s2.ProbusStationKey)//if its the same station
                        return t;
                    int min = 0, max = 0;
                    min = Math.Min(Stations.IndexOf(s1), Stations.IndexOf(s2));
                    max = Math.Max(Stations.IndexOf(s1), Stations.IndexOf(s2));
                    BusLine newbus = new BusLine();
                    for (int i = max; i < min; i--)
                    {
                        t += Stations[i].ProTimeLastStation;
                    }

                    return t;
                    
                }
                throw new BusException("Error!one or more of the stations isn't exist");
            }
            throw new BusException("Error!the list of stations already empty");

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
                throw new BusException("ERROR! the first station is not exist");
                }
                for (int i = 0; i < Stations.Count; i++)//loking for the second station
                {
                    if (Stations[i].ProbusStationKey == station2.ProbusStationKey)
                        index2 = i;
                }
                if (index2 == -1)//if the second station is not exsist
                {

                throw new BusException("ERROR! the second station is not exist");
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

        public int CompareTo(Object obj)//מה רוצים בסעיף 7 
        {
            BusLine bus = (BusLine)obj;

            //bus = (BusLine)obj;
            TimeSpan t = TimeBetween2Stations(this.ProFirstStation,this.ProLastStation);
            TimeSpan b = TimeBetween2Stations(bus.ProFirstStation, bus.ProLastStation);
            if (t > b)
                return 1;
            if (t < b)
                return -1;
            else return 0;

        }

    }
}












