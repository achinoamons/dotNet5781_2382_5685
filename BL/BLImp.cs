﻿using System;
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
                    select ls;//מחזיר רשימה של תחנות קו במקום רשימת קוים
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
        /*public BO.LineStation GetLineStation(int id)//
        {
            DO.LineStation dlinestion;
            
            try
            {
                dlinestion = dl.GetLineStation(id);
                //dstation = dl.GetStation(code);
            }
            catch (DO.BadLineStationIdException ex)
            {
                throw new BO.BadLineStationException("This linestation is not exist ", ex);
            }
            BO.LineStation bls = new BO.LineStation();
            bls=LineStationDoBoAdapter(dlinestion);
            bls.

    }*/
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
        public BO.Station GetStation(int code)//מחזיר פרטי תחנה בודדת 
        {
            DO.Station dostation;
            try
            {
                dostation = dl.GetStation(code);
            }
            catch (DO.BadStationException ex)
            {
                throw new BO.BadStationException("station code does not exist ", ex);
            }

            BO.Station st = new BO.Station();
            dostation.CopyPropertiesTo(st);
            st.ListOfLinesPass = GetAllLinesPassByStation(st.CodeStation);//קוראת לפונק שמחזירה רשימת קווים שעוברים בתחנה
            //st.ListOfLinesPass = from ls in dl.GetAllLineStationsBy(p => p.StationCode == st.CodeStation)//list of lines pass
            //                     let BOline = ls.CopyPropertiesToNew(typeof(BO.Line)) as BO.Line
            //                     select BOline;

            st.ListOfAdjStations = from ls in dl.GetAllAdjacentStationsby(p => p.Station1Code == st.CodeStation || p.Station2Code == st.CodeStation)//list of adjacent stations
                                   let BOADJ = ls.CopyPropertiesToNew(typeof(BO.AdjacentStations)) as BO.AdjacentStations
                                   select BOADJ;
            return st;

        }
        public void AddLineToStation(BO.Station station, BO.Line line)//מוסיפה קו לתחנה וג"כ תוסיף את התחנה לקו 
        {

            DO.Station dostation;
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
                    boline.ListOfStationsPass.ToList().Add(bostation);
                    boline.ListOfAdjStations.ToList().
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
            }
        }
        public void DeletLinefromStation(BO.Station station, BO.Line line)//מחיקת קו מתחנה וג"כ תחנה מקו
        {
            DO.Station dostation;
            DO.Line doline;
            try
            {
                dostation = dl.GetStation(station.CodeStation);
                doline = dl.GetLine(line.LineID);
                BO.Station bostation = new BO.Station();
                BO.Line boline = new BO.Line();
                dostation.CopyPropertiesTo(bostation);
                doline.CopyPropertiesTo(boline);
                if ((boline.ListOfStations.Contains(bostation)))//לבדוק שהתחנה  קיימת ברשימת הקוים 
                {
                    boline.ListOfStations.ToList().Remove(bostation);
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
            }
        }

        #endregion
    }







}
}
