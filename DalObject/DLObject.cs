using System;
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
            if (DataSource.ListLines.FirstOrDefault(p => p.FirstStation == line.FirstStation&&p.LastStation==line.LastStation) != null)
                throw new DO.BadLineIdException( "Duplicate line");
            line.LineID= DO.Configuration.staticforline++;
            DataSource.ListLines.Add(line.Clone());
           
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
        public IEnumerable<DO.LineStation> GetAllLineStations() 
        {
            return from linest in DataSource.ListLineStations
                   select linest.Clone();
        }
        public IEnumerable<DO.LineStation> GetAllLineStations(Predicate<DO.LineStation> predicate) 
        {
            return from linest in DataSource.ListLineStations
                   where predicate(linest)
                   select linest.Clone();
        }
        public DO.LineStation GetLineStation(int id) 
        {
            DO.LineStation ls = DataSource.ListLineStations.Find(p => p.LineId == id);

            if (ls != null)
                return ls.Clone();
            else
                throw new DO.BadLineStationIdException(id, $"bad linestation line id: {id}");
        }
        public void AddLineStation(DO.LineStation linestation)//אין לנו עדיין תנאי סינון מתאים להוספת תחנת קו--צרך לשאול את המורה אם נכון
        {
            bool flag = false;
            for (int i = 0; i < DataSource.ListLineStations.Count(); i++)//to check if there is a physical station like this
            {
                if (DataSource.ListLineStations[i].StationCode == linestation.StationCode)
                {
                    flag = true;
                    break; 
                }
            }
            if(!flag)//if there is no station like this
                throw new DO.BadLineStationIdException(linestation.StationCode, "there is no station code like this ");
            if (DataSource.ListLineStations.FirstOrDefault(p => p.StationCode==linestation.StationCode&&p.PrevStationCode==linestation.PrevStationCode&&p.NextStationCode==linestation.NextStationCode&&p.LineStationIndex==linestation.LineStationIndex) != null)
                throw new DO.BadLineStationIdException(linestation.StationCode, "Duplicate line station ");
            DataSource.ListLineStations.Add(linestation.Clone());
            /*for (int i = 0; i < DataSource.ListLines.Count(); i++)
            {
                DataSource.ListLines[i].LineID++;//update the line id to be bigger in each one
            }*/
            DO.Configuration.staticforlinestation++;//?
        }
        public void UpdateLineStation(DO.LineStation linestation) 
        {
            DO.LineStation ls = DataSource.ListLineStations.Find(p => p.LineId == linestation.LineId);

            if (ls != null)
            {
                DataSource.ListLineStations.Remove(ls);
                DataSource.ListLineStations.Add(linestation.Clone());
            }
            else
                throw new DO.BadLineStationIdException(ls.LineId, $"bad line id of line station: {ls.StationCode}");
        }
        public void UpdateLineStation(int id, Action<DO.LineStation> update) { } //method that knows to updt specific fields in Person
        public void DeleteLineStation(int id)
        {
            DO.LineStation ls = DataSource.ListLineStations.Find(p => p.LineId == id);

            if (ls != null)
            {
                int g = ls.LineId;
                DataSource.ListLineStations.Remove(ls);
                for (int i = g; i < DataSource.ListLineStations.Count(); i++)
                {
                    DataSource.ListLineStations[i].LineId--;
                }
            }
            else
                throw new DO.BadLineStationIdException(id, $"bad line id of line station: {id}");
        }
        #endregion
        #region AdjacentStations
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            return from linestadj in DataSource.ListAdjacentStations
                   select linestadj.Clone();
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsby(Predicate<DO.AdjacentStations> predicate)
        {
            return from linestadj in DataSource.ListAdjacentStations
                   where predicate(linestadj)
                   select linestadj.Clone();
        }
        public DO.AdjacentStations GetAdjacentStations(int code1,int code2)
        {
            DO.AdjacentStations adj = DataSource.ListAdjacentStations.Find(p => p.Station1Code == code1&&p.Station2Code==code2);

            if (adj != null)
                return adj.Clone();
            else
                throw new DO.BadAdjacentStationsException(code1,code2, $"bad codes: {code1},{code2}");
        }
        public void AddAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            if (DataSource.ListAdjacentStations.FirstOrDefault(p => p.Station1Code == adjacentStations.Station1Code&& p.Station2Code == adjacentStations.Station2Code) != null)
                throw new DO.BadAdjacentStationsException(adjacentStations.Station1Code, adjacentStations.Station2Code, "Duplicate station1 and station2 code of adjacent station");
            DataSource.ListAdjacentStations.Add(adjacentStations.Clone());
            /*for (int i = 0; i < DataSource.ListLines.Count(); i++)
            {
                DataSource.ListLines[i].LineID++;//update the line id to be bigger in each one
            }*/
            //DO.Configuration.//?
        }
        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            DO.AdjacentStations adj = DataSource.ListAdjacentStations.Find(p => p.Station1Code == adjacentStations.Station1Code && p.Station2Code == adjacentStations.Station2Code);

            if (adj != null)
            {
                DataSource.ListAdjacentStations.Remove(adj);
                DataSource.ListAdjacentStations.Add(adjacentStations.Clone());
            }
            else
               throw new DO.BadAdjacentStationsException(adjacentStations.Station1Code, adjacentStations.Station2Code ,$"bad codes: {adjacentStations.Station1Code},{adjacentStations.Station2Code}");
        }
        public void UpdateAdjacentStations(int id, Action<DO.AdjacentStations> update) { }//method that knows to updt specific fields in Person
        public void DeleteAdjacentStations(int i,int j) 
        {
            DO.AdjacentStations adj = DataSource.ListAdjacentStations.Find(p => p.Station1Code == i && p.Station2Code == j);

            if (adj != null)
            {
              
                DataSource.ListAdjacentStations.Remove(adj);
            }
            else
                //throw new DO.BadLineStationIdException(id, $"bad line id of line station: {id}");
                throw new DO.BadAdjacentStationsException(i, j, $"bad codes: {i},{j} there are no such adjacent stations");
        }
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
        public IEnumerable<DO.Station> GetAllPersons() { }
        public IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate) { }
        public DO.Station GetStation(int id) { }
        public void AddStation(DO.Station station) { }
        public void UpdateStation(DO.Station station) { }
        public void UpdateStation(int id, Action<DO.Station> update) { } //method that knows to updt specific fields in Person
        public void DeleteStation(int id) { }
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