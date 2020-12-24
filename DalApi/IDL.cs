using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace DLAPI
{
    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL
    {
        #region Line
        IEnumerable<Line> GetAllLines();
        IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        Line GetLine(int id);
        void AddLine(Line line);
        void UpdateLine(Line line);
        void UpdateLine(int id, Action<Line> update); //method that knows to updt specific fields in Person
        void DeleteLine(int id);
        #endregion
        #region LineStation
        IEnumerable<LineStation> GetAllLineStations();
        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> predicate);
        LineStation GetLineStation(int id);
        void AddLineStation(LineStation linestation);
        void UpdateLineStation(LineStation linestation);
        void UpdateLineStation(int id, Action<LineStation> update); //method that knows to updt specific fields in Person
        void DeleteLineStation(int id);
        #endregion
        #region AdjacentStations
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        IEnumerable<AdjacentStations> GetAllAdjacentStationsby(Predicate<AdjacentStations> predicate);
        LineStation GetAdjacentStations(int id);
        void AddAdjacentStations(AdjacentStations adjacentStations);
        void UpdateAdjacentStations(AdjacentStations adjacentStations);
        void UpdateAdjacentStations(int id, Action<AdjacentStations> update); //method that knows to updt specific fields in Person
        void DeleteAdjacentStations(int id);
        #endregion
        #region Bus
        IEnumerable<Bus> GetAllBuses();
        IEnumerable<Bus> GetAllBusesby(Predicate<Bus> predicate);
        LineStation GetBus(int id);
        void AddBus(Bus bus);
        void UpdateBus(Bus bus);
        void UpdateBus(int id, Action<Bus> update); //method that knows to updt specific fields in Person
        void DeleteBus(int id);
        #endregion
        #region LineTrip
        IEnumerable<LineTrip> GetAllLineTripes();
        IEnumerable<LineTrip> GetAllLineTripesby(Predicate<LineTrip> predicate);
        LineStation GetLineTrip(int id);
        void AddLineTrip(LineTrip linetrip);
        void UpdateLineTrip(LineTrip linetrip);
        void UpdateLineTrip(int id, Action<LineTrip> update); //method that knows to updt specific fields in Person
        void DeleteLineTrip(int id);
        #endregion

        #region Station
        IEnumerable<Station> GetAllPersons();
        IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        Station GetStation(int id);
        void AddStation(Station station);
        void UpdateStation(Station station);
        void UpdateStation(int id, Action<Station> update); //method that knows to updt specific fields in Person
        void DeleteStation(int id);
        #endregion
        #region Trip
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsBy(Predicate<Trip> predicate);
        Trip GetTrip(int id);
        void AddPerson(Trip t);
        void UpdateTrip(Trip t);
        void UpdateTrip(int id, Action<Trip> update); //method that knows to updt specific fields in Person
        void DeleteTrip(int id);
        #endregion
        #region User
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetAllUsersBy(Predicate<User> predicate);
        User GetUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void UpdateUser(int id, Action<User> update); //method that knows to updt specific fields in Person
        void DeleteUser(int id);
        #endregion
    }
}
