using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DO;
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
        IEnumerable<DO.Line> GetAllLines();
        IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate);
        DO.Line GetLine(int id, DO.Areas area);
        DO.Line GetLine(int ID);
        void AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void UpdateLine(int id, Action<DO.Line> update); //method that knows to updt specific fields in Person
        void DeleteLine(int code, DO.Areas area);
        #endregion
       #region LineStation
        IEnumerable<DO.LineStation> GetAllLineStations();
        ////DO.LineStation GetLineStation(int lineCode, int StationCode);
        IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.LineStation> predicate);
        DO.LineStation GetLineStation(int id);
        DO.LineStation GetLineStationLEA(int lineCode1, int StationCode);
        IEnumerable<DO.LineStation> GetLineStationBy(Predicate<DO.LineStation> predicate);
        void AddLineStation(DO.LineStation linestation);
        void UpdateLineStation(DO.LineStation linestation);
       // void UpdateLineStation(int id, Action<DO.LineStation> update); //method that knows to updt specific fields in Person
        void DeleteLineStation(DO.LineStation l);
        #endregion
        #region AdjacentStations
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStations();
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsby(Predicate<DO.AdjacentStations> predicate);
        DO.AdjacentStations GetAdjacentStations(int i,int j);
        void AddAdjacentStations(DO.AdjacentStations adjacentStations);
        void UpdateAdjacentStations(DO.AdjacentStations adjacentStations);
        void UpdateAdjacentStations(int id, Action<DO.AdjacentStations> update); //method that knows to updt specific fields in Person
        void DeleteAdjacentStations(int i,int j);
        #endregion
       /* #region Bus
        IEnumerable<DO.Bus> GetAllBuses();
        IEnumerable<DO.Bus> GetAllBusesby(Predicate<DO.Bus> predicate);
        DO.LineStation GetBus(int id);
        void AddBus(DO.Bus bus);
        void UpdateBus(DO.Bus bus);
        void UpdateBus(int id, Action<DO.Bus> update); //method that knows to updt specific fields in Person
        void DeleteBus(int id);
        #endregion*/
        //#region LineTrip
        //IEnumerable<DO.LineTrip> GetAllLineTripes();
        //IEnumerable<DO.LineTrip> GetAllLineTripesby(Predicate<DO.LineTrip> predicate);
        //DO.LineStation GetLineTrip(int id);
        //void AddLineTrip(DO.LineTrip linetrip);
        //void UpdateLineTrip(DO.LineTrip linetrip);
        //void UpdateLineTrip(int id, Action<DO.LineTrip> update); //method that knows to updt specific fields in Person
        //void DeleteLineTrip(int id);
       // #endregion
       #region Station
        IEnumerable<DO.Station> GetAllStations();
        IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate);
        DO.Station GetStation(int id);
        void AddStation(DO.Station station);
        void UpdateStation(DO.Station station,int i);
        void UpdateStation(int id, Action<DO.Station> update); //method that knows to updt specific fields in Person
        void DeleteStation(int id);
        IEnumerable<DO.Station> GetSortStations();
        #endregion
        /* #region Trip
         IEnumerable<DO.Trip> GetAllTrips();
         IEnumerable<DO.Trip> GetAllTripsBy(Predicate<DO.Trip> predicate);
         DO.Trip GetTrip(int id);
         void AddPerson(DO.Trip t);
         void UpdateTrip(DO.Trip t);
         void UpdateTrip(int id, Action<DO.Trip> update); //method that knows to updt specific fields in Person
         void DeleteTrip(int id);
         #endregion*/
        /*#region User
         IEnumerable<DO.User> GetAllUsers();
         IEnumerable<DO.User> GetAllUsersBy(Predicate<DO.User> predicate);
         DO.User GetUser(int id);
         void AddUser(DO.User user);
         void UpdateUser(DO.User user);
         void UpdateUser(int id, Action<DO.User> update); //method that knows to updt specific fields in Person
         void DeleteUser(int id);
         #endregion*/
    }
}
