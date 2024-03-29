﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    enum Areas { General , North, South, East, West, Center, LowLand, Jerusalem };//we decided to to interurban bus lines
    /// <summary>
    /// a class that describes bus line
    /// </summary>
  public  class BusLine : IComparable
    {
        //לזכור לטפל בבעיה של תחנה ראשונה ואחרונה
        List<BusLineStation> Stations = new List<BusLineStation>();
        int numLine;//THE NUMBER OF THE LINE
        BusLineStation LastStation;//the last station of the busline
        BusLineStation FirstStation;//the first station of the busline
        string area;
        TimeSpan totaltraveltime;
        int backOrForth;//a field that mark if the line is 1 way or 2 way(in case of same number line)
        public int ProbackOrForth//
          {
            set
            {

                if(value==0||value==1)
                {
                    backOrForth = value;

                }
                else
                    throw new BusException("Error!number must be 0 or 1");
            }
            get
            {
                return backOrForth;
            }
          }



        public  TimeSpan Prototaltraveltime//property of the general time
        {
            set
            {
                totaltraveltime = TimeBetween2Stations(FirstStation, LastStation);
            }
            get
            {
                return totaltraveltime;
            }
        }
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
                Stations.Insert(0,FirstStation);
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
      

        public string ProArea
        {
            set
            {
                area = value;
            }
            get
            {
                /* Areas a;
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
                 return ch;*/
                return area;
            }
                

            }
        
        public List<BusLineStation> ProStations
        {
            set { Stations = value; }
            get { return Stations; }
        }
        
        BusLine() { }
       static Random r = new Random(DateTime.Now.Millisecond);
        public BusLine(int num/*, BusLineStation first, BusLineStation last*/,int choise)
        {
            if (num <= 0||num>999)
                throw new BusException("Error!number of line cannot be negative or 0");
            else
            {
                numLine = num;
            }
             //FirstStation = null;
            // Stations.Insert(0, FirstStation); ;
           // LastStation = null;
            //  Stations.Add(LastStation);
            //area = a;
            if (choise == 0 || choise == 1)
            {
                backOrForth = choise;

            }
            else
                throw new BusException("Error!number must be 0 or 1");
           
           //Random r = new Random(DateTime.Now.Millisecond);
            int help=r.Next(8);
            switch(help)
            {
                case 0: { area = "General";break; }
                case 1: { area = "North"; break; }
                case 2: { area = "South"; break; }
                case 3: { area = "East"; break; }
                case 4: { area = "West"; break; }
                case 5: { area = "Center"; break; }
                case 6: { area = "LowLand"; break; }
                case 7: { area = "Jerusalem"; break; }
                 
            }


        }
        public override string ToString()//overriding tostring of object
        {
            string s = "Line number: " + numLine +" " +"Line area: " + area;//Threading line number and line area

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                s += "The route of the line:";
                 string str = "";
                for (int i = 0; i < this.ProStations.Count; i++)//Threading all the routes
                {
                    str +=this. ProStations[i].ProbusStationKey;
                    str += ",";
                }
                s += str;

              
                return s;
            }
            else//if the station is empty
            {
                s += " There is no route to the line";
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
            bool isEmpty = !Stations.Any();//if the list of station us not empty
            if (isEmpty)//if the list is empty-add to start
            {
                Stations.Add(station);//
                ProFirstStation =ProLastStation=station;//update the first and last stations
            }
            else
            {
                //bool b = false;

                foreach (BusLineStation busLineStation in Stations)//
                {

                    if (busLineStation.ProbusStationKey == station.ProbusStationKey)//if the station already exist
                    {
                        throw new BusException(" Error! This station already exist");
                    }
                }
                //if i want to add to the end
                if (Stations[0].ProbusStationKey > station.ProbusStationKey)//add to the start
                {
                   // Stations.Insert(0,station);
                    this.ProFirstStation = station;

                    return;
                }
                if (Stations[Stations.Count - 1].ProbusStationKey<station.ProbusStationKey)//add to the end
                {
                    Stations.Add(station);
                    //this.ProLastStation = station;
                   
                    return;
                }
                for (int i = 0; i < Stations.Count-1; i++)//finding the suitable place for the station
                {

                    if (Stations[i].ProbusStationKey < station.ProbusStationKey && Stations[i + 1].ProbusStationKey > station.ProbusStationKey)//finding suitable place
                    {

                        Stations.Insert(i + 1, station);//adding
                        //updating the relevant fields
                        double dis1 = DistanceBetween2Stations(Stations[i], Stations[i + 1]);
                        Stations[i + 1].ProDistanceLastStation = dis1;//updating the distance field of the station that i add;
                        double dis2 = DistanceBetween2Stations(Stations[i + 1], Stations[i + 2]);//updating the distance field of the after station that i add;
                        Stations[i + 2].ProDistanceLastStation = dis2;
                        TimeSpan t1 = new TimeSpan(0, 0, 0);
                        TimeSpan t2 = new TimeSpan(0, 0, 0);
                        t1 = TimeBetween2Stations(Stations[i], Stations[i + 1]);
                        Stations[i + 1].ProTimeLastStation = t1;//updating the TIME field of the station that i add;
                        t2 = TimeBetween2Stations(Stations[i + 1], Stations[i + 2]);//updating the TIME field of the after station that i add;
                        Stations[i + 2].ProTimeLastStation = t2;
                        return;

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


            int counter = 0;
             foreach (BusLineStation busLineStation in Stations)//check if the station is exist
             {
                 if (busLineStation.ProbusStationKey == numstation.ProbusStationKey)
                 {
                   if (numstation.ProbusStationKey==this.Stations[0].ProbusStationKey)//if we want to delete the first station
                   {
                       //updating the relevant fields
                       Stations[1].ProDistanceLastStation = 0;
                       TimeSpan t = new TimeSpan(0, 0, 0);
                       Stations[1].ProTimeLastStation = t;
                       ProFirstStation = Stations[1];//update the first station field
                      Stations.RemoveAt(0);//delet the station
                        return;
                   }
                   if (numstation.ProbusStationKey == this.Stations[Stations.Count-1].ProbusStationKey)//if the delete station is the last
                   {
                       int g = Stations.Count;
                       ProLastStation = Stations[g-2];//because the index begin from 0
                       Stations.RemoveAt(g-1);
                        return;
                   }
                

                 else//if (Stations.Contains(counter + 1)) //update the relevant fields of the next station---if exist 
                 {
                     Stations[counter + 1].ProDistanceLastStation += Stations[counter].ProDistanceLastStation;
                     Stations[counter + 1].ProTimeLastStation += Stations[counter].ProTimeLastStation;

                     Stations.RemoveAt(counter);//remove the station
                        return;
                 }
                     }
             counter++;
         }
         throw new BusException(" Error! This station does not exist");
           /* foreach (BusLineStation busLineStation in Stations)//check if the station is exist
            {
                if (busLineStation.ProbusStationKey == numstation.ProbusStationKey)
                {
                    this.Stations.Remove(numstation);

                    return;

                }
            }
            throw new BusException(" Error! This station does not exist");*/
        }




            public double DistanceBetween2Stations(BusLineStation s1, BusLineStation s2)
        {
            double d = 0;

            bool isEmpty = !Stations.Any();//if the station us not empty
            if (!isEmpty)
            {
                int g = 0, l = 0;
                // BusLineStation bs1 = Stations.Find ( item => item.ProbusStationKey == s1.ProbusStationKey);//check if s1 exist
                // BusLineStation bs2 = Stations.Find(item => item.ProbusStationKey == s2.ProbusStationKey);//check if s2 exist

                //bool b = Stations.Find(s1);//to check if it exist
                //bool c = Stations.Find(s2);
                bool c = false, b = false;
                 for (int i = 0; i < Stations.Count; i++)//looking for the first station
                 {
                    if (Stations[i].ProbusStationKey == s1.ProbusStationKey)
                    {
                        l = i;
                        b = true;
                        break;
                    }

                 }
                 for (int i = 0; i < Stations.Count; i++)//looking for the second station
                 {
                    if (Stations[i].ProbusStationKey == s2.ProbusStationKey)
                    {
                        c = true;
                        break;
                        g = i;
                    }

                 }
                if (b && c)//if they both exist
                {
                    if (s1.ProbusStationKey == s2.ProbusStationKey)//if its the same station
                        return 0;
                    int min = 0, max = 0;
                    // min = Math.Min(Stations.IndexOf(s1), Stations.IndexOf(s2));
                    // max = Math.Max(Stations.IndexOf(s1), Stations.IndexOf(s2));
                    min = Math.Min(g, l);
                    max = Math.Max(g, l);
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
                int g=0,l=0;
                
                bool b = false, c = false;
                for (int i = 0; i < Stations.Count; i++)//looking for the first station
                {
                    
                    if (Stations[i].ProbusStationKey == s1.ProbusStationKey)
                    {
                        l = i;
                        b = true;
                        break;
                    }

                }
                for (int i = 0; i < Stations.Count; i++)//looking for the second station
                {
                    
                    if (Stations[i].ProbusStationKey == s2.ProbusStationKey)
                    {
                        g = i;
                        c = true;
                        break;
                    }

                }
                if (b && c)//if the stations both exist

                {
                    if (s1.ProbusStationKey == s2.ProbusStationKey)//if its the same station
                        return t;
                    int min = 0, max = 0;
                    min = Math.Min(g,l);
                    //  max = Math.Max(Stations.IndexOf, Stations.IndexOf(s2));
                    max = Math.Max(g, l);
                   // BusLine newbus = new BusLine();
                    for (int i = max; i > min; i--)
                    {
                        //t.Add(Stations[i].ProTimeLastStation);
                        t += Stations[i].ProTimeLastStation;
                    }

                    return t;
                    
                }
                throw new BusException("Error!one or more of the stations isn't exist");
            }
            throw new BusException("Error!the list of stations is empty");

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
                for (int i = min,  m=0 ; i <= max; i++,m++)
                {
                    newbus.ProStations.Add( Stations[i]);//copy the sub line to the new bus
                }
                return newbus;
           
            }

        public int CompareTo(Object obj)//7 
        {
            BusLine bus = (BusLine)obj;
            /* TimeSpan t = TimeBetween2Stations(this.ProFirstStation,this.ProLastStation);
              TimeSpan b = TimeBetween2Stations(bus.ProFirstStation, bus.ProLastStation);
              if (t > b)
                  return 1;
              if (t < b)
                  return -1;
              else return 0;*/
            return Prototaltraveltime.CompareTo(bus.Prototaltraveltime);
           

        }
        
    }
 }














