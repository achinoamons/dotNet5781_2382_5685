using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DLAPI;
using DO;
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
        IEnumerable<Line> GetAllLines()
        { }
        IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate) { }
        Line GetLine(int id) { }
        void AddLine(Line line) { }
        void UpdateLine(Line line) { }
        void UpdateLine(int id, Action<Line> update) { }//method that knows to updt specific fields in Person
        void DeleteLine(int id) { }
        #endregion
        #region LineStation
        IEnumerable<LineStation> GetAllLineStations() { }
        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> predicate) { }
        LineStation GetLineStation(int id) { }
        void AddLineStation(LineStation linestation) { }
        void UpdateLineStation(LineStation linestation) { }
        void UpdateLineStation(int id, Action<LineStation> update) { } //method that knows to updt specific fields in Person
        void DeleteLineStation(int id) { }
        #endregion
        #region AdjacentStations
        IEnumerable<AdjacentStations> GetAllAdjacentStations() { }
        IEnumerable<AdjacentStations> GetAllAdjacentStationsby(Predicate<AdjacentStations> predicate) { }
        LineStation GetAdjacentStations(int id) { }
        void AddAdjacentStations(AdjacentStations adjacentStations) { }
        void UpdateAdjacentStations(AdjacentStations adjacentStations) { }
        void UpdateAdjacentStations(int id, Action<AdjacentStations> update) { }//method that knows to updt specific fields in Person
        void DeleteAdjacentStations(int id) { }
        #endregion
        #region Bus
        IEnumerable<Bus> GetAllBuses() { }
        IEnumerable<Bus> GetAllBusesby(Predicate<Bus> predicate) { }
        LineStation GetBus(int id) { }
        void AddBus(Bus bus) { }
        void UpdateBus(Bus bus) { }
        void UpdateBus(int id, Action<Bus> update) { }//method that knows to updt specific fields in Person
        void DeleteBus(int id) { }
        #endregion
        #region LineTrip
        IEnumerable<LineTrip> GetAllLineTripes() { }
        IEnumerable<LineTrip> GetAllLineTripesby(Predicate<LineTrip> predicate) { }
        LineStation GetLineTrip(int id) { }
        void AddLineTrip(LineTrip linetrip) { }
        void UpdateLineTrip(LineTrip linetrip) { }
        void UpdateLineTrip(int id, Action<LineTrip> update) { } //method that knows to updt specific fields in Person
        void DeleteLineTrip(int id) { }
        #endregion
        #region Station
        IEnumerable<Station> GetAllPersons() { }
        IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate) { }
        Station GetStation(int id) { }
        void AddStation(Station station) { }
        void UpdateStation(Station station) { }
        void UpdateStation(int id, Action<Station> update) { } //method that knows to updt specific fields in Person
        void DeleteStation(int id) { }
        #endregion
        #region Trip
        IEnumerable<Trip> GetAllTrips() { }
        IEnumerable<Trip> GetAllTripsBy(Predicate<Trip> predicate) { }
        Trip GetTrip(int id) { }
        void AddPerson(Trip t) { }
        void UpdateTrip(Trip t) { }
        void UpdateTrip(int id, Action<Trip> update) { } //method that knows to updt specific fields in Person
        void DeleteTrip(int id) { }
        #endregion
        #region User
        IEnumerable<User> GetAllUsers() { }
        IEnumerable<User> GetAllUsersBy(Predicate<User> predicate) { }
        User GetUser(int id) { }
        void AddUser(User user) { }
        void UpdateUser(User user) { }
        void UpdateUser(int id, Action<User> update) { } //method that knows to updt specific fields in Person
        void DeleteUser(int id) { }

        IEnumerable<Line> IDL.GetAllLines()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Line> IDL.GetAllLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }

        Line IDL.GetLine(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddLine(Line line)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateLine(Line line)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateLine(int id, Action<Line> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteLine(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineStation> IDL.GetAllLineStations()
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineStation> IDL.GetAllLineStations(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        LineStation IDL.GetLineStation(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddLineStation(LineStation linestation)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateLineStation(LineStation linestation)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateLineStation(int id, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteLineStation(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AdjacentStations> IDL.GetAllAdjacentStations()
        {
            throw new NotImplementedException();
        }

        IEnumerable<AdjacentStations> IDL.GetAllAdjacentStationsby(Predicate<AdjacentStations> predicate)
        {
            throw new NotImplementedException();
        }

        LineStation IDL.GetAdjacentStations(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddAdjacentStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateAdjacentStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateAdjacentStations(int id, Action<AdjacentStations> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteAdjacentStations(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bus> IDL.GetAllBuses()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bus> IDL.GetAllBusesby(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }

        LineStation IDL.GetBus(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateBus(int id, Action<Bus> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteBus(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineTrip> IDL.GetAllLineTripes()
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineTrip> IDL.GetAllLineTripesby(Predicate<LineTrip> predicate)
        {
            throw new NotImplementedException();
        }

        LineStation IDL.GetLineTrip(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddLineTrip(LineTrip linetrip)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateLineTrip(LineTrip linetrip)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateLineTrip(int id, Action<LineTrip> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteLineTrip(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Station> IDL.GetAllPersons()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Station> IDL.GetAllStationsBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }

        Station IDL.GetStation(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddStation(Station station)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateStation(int id, Action<Station> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteStation(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Trip> IDL.GetAllTrips()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Trip> IDL.GetAllTripsBy(Predicate<Trip> predicate)
        {
            throw new NotImplementedException();
        }

        Trip IDL.GetTrip(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddPerson(Trip t)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateTrip(Trip t)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateTrip(int id, Action<Trip> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteTrip(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IDL.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IDL.GetAllUsersBy(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }

        User IDL.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        void IDL.AddUser(User user)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        void IDL.UpdateUser(int id, Action<User> update)
        {
            throw new NotImplementedException();
        }

        void IDL.DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}