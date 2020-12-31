﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DLAPI;
using DS;

namespace DL
{
    sealed class DLObject : IDL    //internal

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        //Implement IDL methods, CRUD
        #region Line
        public IEnumerable<DO.Line> GetAllLines() 
        {
            
            return from line in DataSource.ListLines
                   select line.Clone();
        }
       public IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate) 
        { 
           return from line in DataSource.ListLines
                  where predicate(line)
                  select line.Clone();
        }
        public DO.Line GetLine(int id) 
        {
            DO.Line l = DataSource.ListLines.Find(p => p.LineID == id);

            if (l != null)
                return l.Clone();
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public void AddLine(DO.Line line)
        {
            if (DataSource.ListLines.FirstOrDefault(p => p.LineID == line.LineID) != null)
                throw new DO.BadLineIdException(line.LineID, "Duplicate line ID");
            DataSource.ListLines.Add(line.Clone());
            /*for (int i = 0; i < DataSource.ListLines.Count(); i++)
            {
                DataSource.ListLines[i].LineID++;//update the line id to be bigger in each one
            }*/
            DO.Configuration.staticforline++;//?
        }
        public void UpdateLine(DO.Line line) 
        {
            DO.Line l = DataSource.ListLines.Find(p => p.LineID == line.LineID);

            if (l != null)
            {
                DataSource.ListLines.Remove(l);
                DataSource.ListLines.Add(line.Clone());
            }
            else
                throw new DO.BadLineIdException(l.LineID, $"bad line id: {l.LineID}");
        }
      
        public void UpdateLine(int id, Action<DO.Line> update) //method that knows to updt specific fields in Line
        {

        }
            public void DeleteLine(int id)
        {
            DO.Line line = DataSource.ListLines.Find(p => p.LineID == id);

            if (line != null)
            {
                int g= line.LineID;
                DataSource.ListLines.Remove(line);
                for (int i =g ; i <DataSource.ListLines.Count(); i++)
                {
                    DataSource.ListLines[i].LineID--;
                }
                 
            }
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        #endregion
        #region LineStation
        public IEnumerable<DO.LineStation> GetAllLineStations() { }
        public IEnumerable<DO.LineStation> GetAllLineStations(Predicate<DO.LineStation> predicate) { }
        public DO.LineStation GetLineStation(int id) { }
        public void AddLineStation(DO.LineStation linestation) { }
        public void UpdateLineStation(DO.LineStation linestation) { }
        public void UpdateLineStation(int id, Action<DO.LineStation> update) { } //method that knows to updt specific fields in Person
        public void DeleteLineStation(int id) { }
        #endregion
        #region AdjacentStations
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations() { }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsby(Predicate<DO.AdjacentStations> predicate) { }
        public DO.LineStation GetAdjacentStations(int id) { }
        public void AddAdjacentStations(DO.AdjacentStations adjacentStations) { }
        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations) { }
        public void UpdateAdjacentStations(int id, Action<DO.AdjacentStations> update) { }//method that knows to updt specific fields in Person
        public void DeleteAdjacentStations(int id) { }
        #endregion
       /* #region Bus
        public IEnumerable<DO.Bus> GetAllBuses() { }
        public IEnumerable<DO.Bus> GetAllBusesby(Predicate<DO.Bus> predicate) { }
        public DO.LineStation GetBus(int id) { }
        public void AddBus(DO.Bus bus) { }
        public void UpdateBus(DO.Bus bus) { }
        public void UpdateBus(int id, Action<DO.Bus> update) { }//method that knows to updt specific fields in Person
        public void DeleteBus(int id) { }
        #endregion*/
       /* #region LineTrip
        public IEnumerable<DO.LineTrip> GetAllLineTripes() { }
        public IEnumerable<DO.LineTrip> GetAllLineTripesby(Predicate<DO.LineTrip> predicate) { }
        public DO.LineStation GetLineTrip(int id) { }
        public void AddLineTrip(DO.LineTrip linetrip) { }
        public void UpdateLineTrip(DO.LineTrip linetrip) { }
        public void UpdateLineTrip(int id, Action<DO.LineTrip> update) { } //method that knows to updt specific fields in Person
        public void DeleteLineTrip(int id) { }
        #endregion*/
        #region Station
        public IEnumerable<DO.Station> GetAllStations() 
        {
            return from Station in DataSource.ListStations
                   select Station.Clone();

        }
        public IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in DataSource.ListStations
                   where predicate(Station)
                   select Station.Clone();
        }
        public DO.Station GetStation(int CodeStation)
        {
            DO.Station S = DataSource.ListStations.Find(p => p.CodeStation== CodeStation);

            if (S != null)
                return S.Clone();
            else
                throw new DO.BadLineIdException(CodeStation, $"bad Station CodeStation: {CodeStation}");
        }
        public void AddStation(DO.Station station)
        {
            if (DataSource.ListStations.FirstOrDefault(p => p.CodeStation == station.CodeStation) != null)
                throw new DO.BadLineIdException(station.CodeStation, "Duplicate station CodeStation");
            DataSource.ListStations.Add(station.Clone());

          
        }
        public void UpdateStation(DO.Station station)

        {
            DO.Station S = DataSource.ListStations.Find(p => p.CodeStation == station.CodeStation);

            if (S != null)
            {
                DataSource.ListStations.Remove(S);
                DataSource.ListStations.Add(station.Clone());
            }
            else
                throw new DO.BadLineIdException(S.CodeStation, $"Station CodeStation: {S.CodeStation}");
        }
        public void UpdateStation(int codestation, Action<DO.Station> update) { } //method that knows to updt specific fields in Person
        public void DeleteStation(int codestation)
        {
            DO.Station station = DataSource.ListStations.Find(p => p.CodeStation == codestation);

            if (station != null)
            {
                //int g = station.CodeStation;
                DataSource.ListStations.Remove(station);
            //    for (int i = g; i < DataSource.ListLines.Count(); i++)
            //    {
            //        DataSource.ListLines[i].LineID--;
            //    }

            }
            else
                throw new DO.BadLineIdException(codestation, $"bad station codestation: {codestation}");
        }

        #endregion
        /*#region Trip
        public IEnumerable<DO.Trip> GetAllTrips() { }
        public IEnumerable<DO.Trip> GetAllTripsBy(Predicate<DO.Trip> predicate) { }
        public DO.Trip GetTrip(int id) { }
        public void AddPerson(DO.Trip t) { }
        public void UpdateTrip(DO.Trip t) { }
        public void UpdateTrip(int id, Action<DO.Trip> update) { } //method that knows to updt specific fields in Person
        public void DeleteTrip(int id) { }
        #endregion*/
        /* #region User
         public IEnumerable<DO.User> GetAllUsers() { }
         public IEnumerable<DO.User> GetAllUsersBy(Predicate<DO.User> predicate) { }
         public DO.User GetUser(int id) { }
         public void AddUser(DO.User user) { }
         public void UpdateUser(DO.User user) { }
         public void UpdateUser(int id, Action<DO.User> update) { } //method that knows to updt specific fields in Person
         public void DeleteUser(int id) { }
         #endregion*/
    }
}