

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

            return from line in DataSource.listLines
                   select line.Clone();
        }
        public IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate)
        {
            return from line in DataSource.listLines
                   where predicate(line)
                   select line.Clone();
        }
        public DO.Line GetLine(int id, DO.Areas area) //L
        {
            //DO.Line l = DataSource.listLines.Find(p => p.LineID == id);

            //if (l != null)
            //    return l.Clone();
            //else
            //    // throw new DO.BadLineIdException(id, $"bad line id: {id}");
            //    throw new DO.NotExistException(id+ $"bad line id");
            DO.Line line = DataSource.listLines.Find(b => b.Code == id && b.Area == area);
            if (line != null)
                return line.Clone();
            else throw new DO.NotExistException("THIS LINE DOSENT EXIST");
        }
        public DO.Line GetLine(int ID)//L
        {
            DO.Line l = DataSource.listLines.Find(b => b.LineID == ID);
            if (l != null)
                return l.Clone();
            else { throw new DO.NotExistException("THIS LINE DOSENT EXIST"); }//trhow
        }
        public void AddLine(DO.Line line)
        {
            if (DataSource.listLines.FirstOrDefault(p => p.FirstStation == line.FirstStation && p.LastStation == line.LastStation&&p.Code==line.Code) != null)
                // throw new DO.BadLineIdException("Duplicate line");
                throw new DO.OlreadtExistException("Duplicate line");
            line.LineID = DO.Configuration.staticline++;
            DataSource.listLines.Add(line.Clone());
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line l = DataSource.listLines.Find(/*/*p => p.LineID == line.LineIDשיניתי יום רביעי/*/p => p.Code == line.Code);

            if (l != null)
            {
                DataSource.listLines.Remove(l);
                DataSource.listLines.Add(line.Clone());
            }
            else
                //throw new DO.BadLineIdException(l.LineID, $"bad line id: {l.LineID}");
                throw new DO.NotExistException(l.LineID + " bad line id");
        }

        public void UpdateLine(int id, Action<DO.Line> update) //method that knows to updt specific fields in Line
        {

        }


        public void DeleteLine(int code, DO.Areas area)
        {
            DO.Line line = DataSource.listLines.Find(b => b.Code == code && b.Area == area);
            if (line != null)
            {
                DataSource.listLines.Remove(line);
            }
            else throw new DO.NotExistException("THIS LINE DOSENT EXIST");
        }


        #endregion
        #region LineStation
        public IEnumerable<DO.LineStation> GetAllLineStations()/*IEnumerable<DO.LineStation> GetAllLineStations()*/
        {
            return from linest in DataSource.listLineStation
                   select linest.Clone();
        }
        public IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.LineStation> predicate)
        {
            return from linest in DataSource.listLineStation
                   where predicate(linest)
                   select linest.Clone();
        }
        //public DO.LineStation GetLineStation(int id)
        //{
        //    DO.LineStation ls = DataSource.listLineStation.Find(p => p.LineId == id);

        //    if (ls != null)
        //        return ls.Clone();
        //    else
        //        // throw new DO.BadLineStationIdException(id, $"bad linestation line id: {id}");
        //        throw new DO.OlreadtExistException("the line statation" + id + "is not exist");

        //}
        public DO.LineStation GetLineStation(int lineCode1, int StationCode)//LEA
        {
            DO.LineStation a = DataSource.listLineStation.Find(x => x.lineCode == lineCode1 && x.StationCode == StationCode);
            if (a != null) return a.Clone();
            else throw new DO.OlreadtExistException();
        }

        public DO.LineStation GetLineStationLEA(int lineCode1, int StationCode)//L
        {
            DO.LineStation a = DataSource.listLineStation.Find(x => x.LineId == lineCode1 && x.StationCode == StationCode);
            if (a != null) return a.Clone();
            else throw new DO.NotExistException();
        }
        public IEnumerable<DO.LineStation> GetLineStationBy(Predicate<DO.LineStation> predicate)
        {
            return from linestation in DataSource.listLineStation
                   where predicate(linestation)
                   select linestation.Clone();
        }

        public void AddLineStation(DO.LineStation linestation)//אין לנו עדיין תנאי סינון מתאים להוספת תחנת קו--צרך לשאול את המורה אם נכון
        {
            bool flag = false;
            for (int i = 0; i < DataSource.listLineStation.Count(); i++)//to check if there is a physical station like this
            {
                if (DataSource.listLineStation[i].StationCode == linestation.StationCode)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)//if there is no station like this
                      //  throw new DO.BadLineStationIdException(linestation.StationCode, "there is no station code like this ");
                throw new DO.NotExistException("there is no station code like this " + linestation.StationCode);
            if (DataSource.listLineStation.FirstOrDefault(p => p.StationCode == linestation.StationCode && p.PrevStationCode == linestation.PrevStationCode && p.NextStationCode == linestation.NextStationCode && p.LineStationIndex == linestation.LineStationIndex) != null)
                //throw new DO.BadLineStationIdException(linestation.StationCode, "Duplicate line station ");
                throw new DO.OlreadtExistException(linestation.StationCode + " Duplicate line station ");
            DataSource.listLineStation.Add(linestation.Clone());
            /*for (int i = 0; i < DataSource.ListLines.Count(); i++)
            {
                DataSource.ListLines[i].LineID++;//update the line id to be bigger in each one
            }*/
            DO.Configuration.staticforlinestation++;//?
        }
        public bool UpdateLineStation(DO.LineStation linestation)
        {
            DO.LineStation ls = DataSource.listLineStation.Find(/*p => p.LineId == linestation.LineId  שיניתי ביום שני*/p => p.lineCode == linestation.lineCode&&p.StationCode == linestation.StationCode);

            if (ls != null)
            {
                DataSource.listLineStation.Remove(ls);
                DataSource.listLineStation.Add(linestation.Clone());
                return true;
            }
            else
                //throw new DO.BadLineStationIdException(ls.LineId, $"bad line id of line station: {ls.StationCode}");
                throw new DO.NotExistException("THIS LINE STATION DOSENT EXIST");
        }
        // public void UpdateLineStation(int id, Action<DO.LineStation> update) { } //method that knows to updt specific fields in Person
        public void DeleteLineStation(DO.LineStation l/*int id*/)
        {
            DO.LineStation a = DataSource.listLineStation.Find(x => x.lineCode == l.lineCode && x.StationCode == l.StationCode);
            if (a != null)
                DataSource.listLineStation.Remove(a);
            else throw new DO.NotExistException();

            //LineStation a = DataSource.listLineStation.Find(x => x.lineCode == l.lineCode && x.Station == l.Station);
            //if (a != null)
            //    DataSource.listLineStation.Remove(a);
            //else throw new DO.NotExistException();


            //DO.LineStation ls = DataSource.listLineStation.Find(p => p.lineCode == id);

            //if (ls != null)
            //{
            //    int g = ls.lineCode;
            //    DataSource.listLineStation.Remove(ls);
            //    for (int i = g; i < DataSource.listLineStation.Count(); i++)
            //    {
            //        DataSource.listLineStation[i].lineCode--;
            //    }
            //}
            //else
            //    //throw new DO.BadLineStationIdException(id, $"bad line id of line station: {id}");
            //    throw new DO.NotExistException($"bad line id of line station: {id}");
        }

        #endregion
        #region AdjacentStations

        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            return from linestadj in DataSource.listAdjacentStation
                   select linestadj.Clone();
        }

        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsby(Predicate<DO.AdjacentStations> predicate)
        {
            return from linestadj in DataSource.listAdjacentStation
                   where predicate(linestadj)
                   select linestadj.Clone();

        }

        public DO.AdjacentStations GetAdjacentStations(int code1, int code2 ,int lineCode)
        {
            DO.AdjacentStations adj = DataSource.listAdjacentStation.Find(p => p.Station1Code == code1 && p.Station2Code == code2 && p.lineCode == lineCode);

            if (adj != null)
                return adj.Clone();
            else
                // throw new DO.BadAdjacentStationsException(code1, code2, $"bad codes: {code1},{code2}");
                throw new DO.NotExistException("there is no adjacent station for codes" + code1 + code2);
        }

        //public AdjacentStations GetAdjacentStations(int codeStation1, int codeStation2, int lineCode)
        //{
        //    AdjacentStations a = DataSource.listAdjacentStation.Find(x => x.Station1 == codeStation1 && x.Station2 == codeStation2 && x.lineCode == lineCode);
        //    if (a != null) return a.Clone();
        //    else throw new NotExistException();
        //}

        public void AddAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            if (DataSource.listAdjacentStation.FirstOrDefault(p => p.Station1Code == adjacentStations.Station1Code && p.Station2Code == adjacentStations.Station2Code) != null)
                //throw new DO.BadAdjacentStationsException(adjacentStations.Station1Code, adjacentStations.Station2Code, "Duplicate station1 and station2 code of adjacent station");
                throw new DO.OlreadtExistException(adjacentStations.Station1Code + " " + adjacentStations.Station2Code + " Duplicate station1 and station2 code of adjacent station");
            DataSource.listAdjacentStation.Add(adjacentStations.Clone());
            /*for (int i = 0; i < DataSource.ListLines.Count(); i++)
            {
                DataSource.ListLines[i].LineID++;//update the line id to be bigger in each one
            }*/
            //DO.Configuration.//?
        }
        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            DO.AdjacentStations adj = DataSource.listAdjacentStation.Find(p => p.Station1Code == adjacentStations.Station1Code && p.Station2Code == adjacentStations.Station2Code);

            if (adj != null)
            {
                DataSource.listAdjacentStation.Remove(adj);
                DataSource.listAdjacentStation.Add(adjacentStations.Clone());
            }
            else
                //throw new DO.BadAdjacentStationsException(adjacentStations.Station1Code, adjacentStations.Station2Code, $"bad codes: {adjacentStations.Station1Code},{adjacentStations.Station2Code}");
                throw new DO.NotExistException(adjacentStations.Station1Code + adjacentStations.Station2Code + $"bad codes");
        }

      
        public void UpdateAdjacentStations(int id, Action<DO.AdjacentStations> update) { }//method that knows to updt specific fields in Person
       //public void DeleteAdjacentStations(int i, int j)
        //{
        //    DO.AdjacentStations adj = DataSource.listAdjacentStation.Find(p => p.Station1Code == i && p.Station2Code == j);                                                                                 

        //    if (adj != null)
        //    {

        //        DataSource.listAdjacentStation.Remove(adj);
        //    }
        //    else

        //        // throw new DO.BadAdjacentStationsException(i, j, $"bad codes: {i},{j} there are no such adjacent stations");
        //        throw new DO.NotExistException(i + " " + j + " there are no such adjacent stations");
        //}

        public void DeleteAdjacentStations(DO.AdjacentStations adjd)
        {
            DO.AdjacentStations a = DataSource.listAdjacentStation.Find(x => x.Station1Code == adjd.Station1Code && x.Station2Code == adjd.Station2Code && x.lineCode == adjd.lineCode);
            if (a != null) DataSource.listAdjacentStation.Remove(a);
            else throw new DO.NotExistException();
        }
        #endregion AdjacentStations
        /* #region Bus
         public IEnumerable<DO.Bus> GetAllBuses() { }
         public IEnumerable<DO.Bus> GetAllBusesby(Predicate<DO.Bus> predicate) { }
         public DO.LineStation GetBus(int id) { }
         public void AddBus(DO.Bus bus) { }
         public void UpdateBus(DO.Bus bus) { }
         public void UpdateBus(int id, Action<DO.Bus> update) { }//method that knows to updt specific fields in Person
         public void DeleteBus(int id) { }
         #endregion*/
        #region LineTrip
        //public IEnumerable<DO.LineTrip> GetAllLineTripes() { }
        //public IEnumerable<DO.LineTrip> GetAllLineTripesby(Predicate<DO.LineTrip> predicate) { }
        //public DO.LineStation GetLineTrip(int id) { }
        //public void AddLineTrip(DO.LineTrip linetrip) { }
        //public void UpdateLineTrip(DO.LineTrip linetrip) { }
        //  public void UpdateLineTrip(int id, Action<DO.LineTrip> update) { } //method that knows to updt specific fields in Person
        // public void DeleteLineTrip(int linecode) 
        //{
        //       DO.LineTrip lt = DataSource.listLineTrip.Find(b => b.LineId`== linecode);
        //        if (lt != null)
        //        { DataSource.listLineTrip.Remove(lt); }
        //        else throw new DO.NotExistException();

        //    //public void DeleteLineTrip(int lineCode)
        //    //{
        //    //    LineTrip lt = DataSource.listLineTrip.Find(b => b.LineID == lineCode);
        //    //    if (lt != null)
        //    //    { DataSource.listLineTrip.Remove(lt); }
        //    //    else throw new DO.NotExistException();

        //    //}


        //}
        #endregion
        #region Station
        public IEnumerable<DO.Station> GetAllStations()
        {

            return from station in DataSource.listStations
                   select station.Clone();

        }
        public IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate)
        {
            return from Station in DataSource.listStations
                   where predicate(Station)
                   select Station.Clone();
        }
        public DO.Station GetStation(int CodeStation)
        {
            DO.Station S = DataSource.listStations.Find(p => p.CodeStation == CodeStation);

            if (S != null)
                return S.Clone();
            else
                //throw new DO.BadStationException(CodeStation, $"bad Station CodeStation: {CodeStation}");
                throw new DO.NotExistException(CodeStation + "bad Station CodeStation:");
        }
        public void AddStation(DO.Station station)
        {
            if (DataSource.listStations.FirstOrDefault(p => p.CodeStation == station.CodeStation) != null)
                //throw new DO.BadStationException(station.CodeStation, "Duplicate station CodeStation");
                throw new DO.OlreadtExistException(station.CodeStation + "Duplicate station CodeStation");
            DataSource.listStations.Add(station.Clone());


        }
        public IEnumerable<DO.Station> GetSortStations()
        {
            var v = from st in DataSource.listStations
                    orderby st.CodeStation
                    select st;
            return v;
        }
        public void UpdateStation(DO.Station station, int prevcode)

        {
            DO.Station S = DataSource.listStations.Find(/*p => p.CodeStation == station.CodeStation*/p => p.CodeStation == prevcode);

            if (S != null)
            {
                DataSource.listStations.Remove(S);
                DataSource.listStations.Add(station.Clone());

            }
            else
                // throw new DO.BadStationException(S.CodeStation, $"Station CodeStation: {S.CodeStation}");
                throw new DO.NotExistException(S.CodeStation + "Station is not exist");
        }
        public void UpdateStationName(DO.Station station, int prevcode)
        {
            DO.Station S = DataSource.listStations.Find(p => p.CodeStation == prevcode);

            if (S != null)
            {
                int i = DataSource.listStations.IndexOf(S);
                DataSource.listStations[i].Name = station.Name;
                

            }
            else
                // throw new DO.BadStationException(S.CodeStation, $"Station CodeStation: {S.CodeStation}");
                throw new DO.NotExistException(S.CodeStation + "Station is not exist");
        }
        public void UpdateStation(int codestation, Action<DO.Station> update) { } //method that knows to updt specific fields in Person
        public void DeleteStation(int codestation)
        {
            DO.Station station = DataSource.listStations.Find(p => p.CodeStation == codestation);

            if (station != null)
            {
                //int g = station.CodeStation;
                DataSource.listStations.Remove(station);
                for (int i = 0; i < DataSource.listAdjacentStation.Count(); i++)//DELETING THE ADJ OF THE STATION
                {
                    if (DataSource.listAdjacentStation[i].Station1Code == station.CodeStation || DataSource.listAdjacentStation[i].Station2Code == station.CodeStation)
                        DataSource.listAdjacentStation.Remove(DataSource.listAdjacentStation[i]);

                }
                //    for (int i = g; i < DataSource.ListLines.Count(); i++)
                //    {
                //        DataSource.ListLines[i].LineID--;
                //    }

            }
            else
                // throw new DO.BadStationException(codestation, $"bad station codestation: {codestation}");
                throw new DO.NotExistException(codestation + "bad station codestation");
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
