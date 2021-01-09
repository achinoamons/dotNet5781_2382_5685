
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
//using BO;
using DLAPI;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public void AddLine(BO.Line line)
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(BO.LineStation linestation)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BO.Line> GetAllLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.LineStation> GetAllLineStations()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BO.Line> GetAllLinesPassByStation(int code)// מחזיר רשימת כל הקווים שעוברים בתחנה-קבלתי קוד תחנה
        {
            var v = from ls in dl.GetAllLineStationsBy(p => p.StationCode == code)//
                    select ls;//
            return from st in v
                   from line in dl.GetAllLines()// 
                   let linebo = line.CopyPropertiesToNew(typeof(BO.Line)) as BO.Line
                   where st.LineId == linebo.LineID//
                   select linebo;

        }
        public BO.Line GetLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Line> GetLineBy(Predicate<BO.Line> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineStation
        BO.LineStation LineStationDoBoAdapter(DO.LineStation lsdo)
        {
            BO.LineStation lsbo = new BO.LineStation();
            lsdo.CopyPropertiesTo(lsbo);
            return lsbo;
        }
    //    public BO.LineStation GetLineStation(int id)//
    //    {
    //        DO.LineStation dlinestion;

    //        try
    //        {
    //            dlinestion = dl.GetLineStation(id);
    //            //dstation = dl.GetStation(code);
    //        }
    //        catch (DO.BadLineStationIdException ex)
    //        {
    //            throw new BO.BadLineStationException("This linestation is not exist ", ex);
    //        }
    //        BO.LineStation bls = new BO.LineStation();
    //        bls = LineStationDoBoAdapter(dlinestion);
    //        bls.

    //}
        public IEnumerable<BO.LineStation> GetAllLineStationsByLineID(int lineid)
        {
            return from ls1 in dl.GetAllLineStationsBy(s2 => s2.LineId == lineid)
                   select ls1.CopyPropertiesToNew(typeof(BO.LineStation)) as BO.LineStation;
        }
        public IEnumerable<BO.LineStation> GetAllLineStationsByStationCode(int code)
        {
            return from ls1 in dl.GetAllLineStationsBy(s2 => s2.StationCode == code)
                   select ls1.CopyPropertiesToNew(typeof(BO.LineStation)) as BO.LineStation;
        }


        public void UpdateLine(BO.Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int id, Action<BO.Line> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(BO.LineStation linestation)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int id, Action<BO.LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Station
        public IEnumerable<BO.Station> GetAllStations()//מחזיר את רשימת כל התחנות הפיזיות 
        {
            return from station in dl.GetAllStations()
                   let BOstation = station.CopyPropertiesToNew(typeof(BO.Station)) as BO.Station
                   select BOstation;
            

        }
        //public IEnumerable<BO.Line> ListOfLinesPass()
        //{
        //    return GetAllLinesPassByStation();
        //}
        public void AddStation(BO.Station station)
        {
            DO.Station dostation = station.CopyPropertiesToNew(typeof(DO.Station)) as DO.Station;
            /* try
             {
                 var v = dl.GetAllStationsBy(p => p.CodeStation == dostation.CodeStation);
                 if (v != null)
                     throw new BO.OlreadtExistExceptionBO("this station "+station.CodeStation+ " already exist");
                 else
                 dl.AddStation(dostation);
             }
             catch (BO.OlreadtExistExceptionBO ex)
             {
                 throw new BO.OlreadtExistExceptionBO("this station already exist", ex);
             }*/
            try
            {
                dl.AddStation(dostation);
            }
            catch (DO.OlreadtExistException ex)
            {
                throw new BO.OlreadtExistExceptionBO("this station already exist", ex);
            }
            
        }
         public void DeleteStation(int id)
        {
            //IEnumerable<DO.LineStation> LS= dl.GetAllLineStationsBy(p => p.StationCode == id);
            //if (!LS.Any())
            //{
            //    throw new BO.NotExistExceptionBO("you cannot delete the line");
            //}
            //IEnumerable<DO.Station> LS = dl.GetAllStationsBy(p => p.CodeStation == id);
            //if (!LS.Any())
            //{
            //    throw new BO.NotExistExceptionBO("you cannot delete the station");
            //}

            //else
            try
            { dl.DeleteStation(id); }
            catch (DO.NotExistException ex)
            {
                throw new BO.OlreadtExistExceptionBO("this station is not exist", ex);
            }
        }
        public BO.Station GetStation(int code)//מחזיר פרטי תחנה בודדת 
        {
            DO.Station dostation = new DO.Station();
            try
            {
                dostation = dl.GetStation(code);
            }
            catch (DO.NotExistException ex)
            {
                throw new BO.NotExistExceptionBO("station code does not exist ", ex);
            }

            BO.Station st = new BO.Station();
            dostation.CopyPropertiesTo(st);
            st.ListOfLinesPass = GetAllLinesPassByStation(st.CodeStation);//קוראת לפונק שמחזירה רשימת קווים שעוברים בתחנה



            // var v = dl.GetAllAdjacentStationsby(p => p.Station1Code == st.CodeStation);//list of adjacent stations

            //st.ListOfAdjStations = from adj in v
            //                       from sttt in dl.GetAllLineStations()// 
            //                       let linestationbo = sttt.CopyPropertiesToNew(typeof(BO.LineStation)) as BO.LineStation
            //                       where adj.Station1Code == sttt.StationCode//
            //                       select linestationbo;
            IEnumerable < DO.AdjacentStations > adj= dl.GetAllAdjacentStations();
           st.ListOfAdjStations= from a in adj
            where a.Station1Code == st.CodeStation
            select new BO.LineStation { Station1Code = a.Station1Code };



           



            return st;

        }
        public void UpdateStation(BO.Station bostation,int prevcode) 
        {
            DO.Station dostation = bostation.CopyPropertiesToNew(typeof(DO.Station)) as DO.Station;

            try 
            {
                dl.UpdateStation(dostation,prevcode);

            }
            catch (DO.NotExistException ex)
            {
                throw new BO.NotExistExceptionBO("station code does not exist ", ex);
            }
        }
        public void AddLineToStation(BO.Station station, BO.Line line)//מוסיפה קו לתחנה וג"כ תוסיף את התחנה לקו 
        {

           /* DO.Station dostation;
            DO.Line doline;
            try
            {
                dostation = dl.GetStation(station.CodeStation);
                doline = dl.GetLine(line.LineID);
                BO.Station bostation = new BO.Station();
                BO.Line boline = new BO.Line();
                dostation.CopyPropertiesTo(bostation);
                doline.CopyPropertiesTo(boline);
                //throw new Exception("station code does not exist");
                if (!(boline.ListOfStationsPass.Contains(bostation)))//לבדוק שהתחנה לא קיימת ברשימת הקוים 
                {
                    int i = boline.ListOfStationsPass.ToList().Count();//num of station in the list
                    BO.Station bohelpstat = new BO.Station();
                    bohelpstat = boline.ListOfStationsPass.ToList()[i - 1];
                    boline.ListOfStationsPass.ToList().Add(bostation);
                    //AddAdjacentStations(bohelpstat, bostation);//קריאה לפונק שמעדכנת 2 תחנות עוקבות ברשימת התחנות העוקבות 

                }
                else
                {
                    throw new Exception("the station is exist in the listlinesstations of the line");
                }
                if (!(bostation.ListOfLinesPass.Contains(boline)))//לבדוק אם הקו אינו קיים ברשימת התחנות  
                {
                    bostation.ListOfLinesPass.ToList().Add(boline);
                }
                else
                {
                    throw new Exception("the line is exist in the listlines");
                }
            }
            catch (DO.BadStationException ex)
            {
                throw new BO.BadStationException("", ex);
            }*/
        }
        public void DeletLinefromStation(BO.Station station, BO.Line line)//מחיקת קו מתחנה וג"כ תחנה מקו
        {
          /*  DO.Station dostation;
            DO.Line doline;
            try
            {
                dostation = dl.GetStation(station.CodeStation);
                doline = dl.GetLine(line.LineID);
                BO.Station bostation = new BO.Station();
                BO.Line boline = new BO.Line();
                dostation.CopyPropertiesTo(bostation);
                doline.CopyPropertiesTo(boline);
                if ((boline.ListOfStationsPass.Contains(bostation)))//לבדוק שהתחנה  קיימת ברשימת הקוים 
                {
                    boline.ListOfStationsPass.ToList().Remove(bostation);
                }
                else
                {
                    throw new Exception("the station is ont exist in the listlinesstations of the line");
                }
                if ((bostation.ListOfLinesPass.Contains(boline)))//לבדוק אם הקו  קיים ברשימת התחנות  
                {
                    bostation.ListOfLinesPass.ToList().Remove(boline);
                }
                else
                {
                    throw new Exception("the line is not exist in the listlines");
                }
            }
            catch (DO.BadStationException ex)
            {
                throw new BO.BadStationException("", ex);
            }*/
        }

        #endregion
        #region AdjacentStations
         public IEnumerable<BO.AdjacentStations> GetAllAdjacentStations()//מחזיר את רשימת כל התחנות העוקבות 
        {
            return from adjacentStations in dl.GetAllAdjacentStations()
                   let BOadjacentStations = adjacentStations.CopyPropertiesToNew(typeof(BO.AdjacentStations)) as BO.AdjacentStations
                   select BOadjacentStations;
        }
       /* public void AddAdjacentStations(BO.Station st1, BO.Station st2)//פונקציה שמוסיפה תחנות עוקבות לרשימה
        {
            try
            {
                BO.AdjacentStations boadj = new BO.AdjacentStations();
                DO.AdjacentStations doadj = new DO.AdjacentStations();
                boadj.Station1Code = st1.CodeStation;
                boadj.Station2Code = st2.CodeStation;
                double distance = Math.Sqrt(Math.Pow(st1.Latitude - st2.Latitude, 2) + Math.Pow(st1.Longitude - st2.Longitude, 2));
                boadj.Distance = distance;
                double time= (distance * 0.5) / 70;
                TimeSpan t = new TimeSpan();
                t = TimeSpan.FromHours(time);
                boadj.Time = t;
                boadj.CopyPropertiesTo(doadj);

                dl.AddAdjacentStations(doadj);//נקרא לפונק בדו להוסיף אובייקט לרשימת תחנות צמודות
            }  
            catch (DO.BadStationException ex)
            {
                throw new BO.BadStationException("", ex);
            }
        }*/
        #endregion
    }

}