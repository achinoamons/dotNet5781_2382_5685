﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLAPI
//{
//   public interface IBL
//    {
//        #region Line
//        IEnumerable<BO.Line> GetAllLines();//show all lines
//        BO.Line GetLine();//show the line--when use it---show details of the line stations of the line
//        IEnumerable<BO.Line> GetLineBy(Predicate<BO.Line> predicate);//shoe line by predicate
//        void AddLine(BO.Line line);
//        void UpdateLine(BO.Line line);
//        void UpdateLine(int id, Action<BO.Line> update); //method that knows to update specific fields in line
//        void DeleteLine(int id);
//        #endregion

//        #region LineStation
//        IEnumerable<BO.LineStation> GetAllLineStations();//show all linestations
//        BO.LineStation GetLineStation(int code);//show the linestation--
//        IEnumerable<BO.LineStation> GetLineStationBy(Predicate<BO.LineStation> predicate);//shoe linestation by predicate
//        void AddLineStation(BO.LineStation linestation);
//        void UpdateLineStation(BO.LineStation linestation);
//        void UpdateLineStation(int id, Action<BO.LineStation> update); //method that knows to update specific fields in linestation
//        void DeleteLineStation(int id);
//        #endregion

//        #region Station
//        IEnumerable<BO.LineStation> GetAllStations();//show all stations
//        BO.Station GetStation(int code);//show the linestation--
//        IEnumerable<BO.LineStation> GetStationBy(Predicate<BO.LineStation> predicate);//shoe linestation by predicate
//        void AddStation(BO.LineStation linestation);
//        void UpdateStation(BO.LineStation linestation);
//        void UpdateStation(int id, Action<BO.LineStation> update); //method that knows to update specific fields in linestation
//        void DeleteStation(int id);
//        #endregion

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAPI
{
    public interface IBL
    {
        #region Line
        IEnumerable<BO.Line> GetAllLines();//show all lines
        IEnumerable<BO.Line> GetAllLinesPassByStation(int code);
        BO.Line GetLine(int i, BO.Areas area);//show the line--when use it---show details of the line stations of the line
        //IEnumerable<BO.Line> GetLineBy(Predicate<BO.Line> predicate);//shoe line by predicate
        void AddLine(BO.Line line);
        void UpdateLine(BO.Line line);
        //void UpdateLine(int id, Action<BO.Line> update); //method that knows to update specific fields in line
        void DeleteLine(int code, BO.Areas area);
        #endregion

        #region LineStation
        //  IEnumerable<BO.LineStation> GetAllLineStations();//show all linestations


        IEnumerable<BO.LineStation> GetAllLineStationsByLineCode(int LineCode);
        List<BO.LineStation> GetAllLineStationsByLineCodeByOrder(int LineCode);

        //BO.LineStation GetLineStation(int code);//show the linestation--
        // IEnumerable<BO.LineStation> GetLineStationBy(Predicate<BO.LineStation> predicate);//shoe linestation by predicate
        void AddLineStation(BO.LineStation linestation);
        void UpdateLineStation(BO.LineStation linestation);
        void UpdateLineStation(int id, Action<BO.LineStation> update); //method that knows to update specific fields in linestation
        bool DeleteLineStation(BO.LineStation ls);
        //void UpdateCode2(BO.LineStation l, int num);
        #endregion

        #region Station
        IEnumerable<BO.Station> GetAllStations();//show all stations

        BO.Station GetStation(int code);//show the linestation--
       // IEnumerable<BO.Station> GetAllStationsPassByLine(int code);//get list of stations for specific line
       // IEnumerable<BO.LineStation> GetStationBy(Predicate<BO.LineStation> predicate);//shoe linestation by predicate
        void AddStation(BO.Station linestation);
        void AddLineToStation(BO.Station station, BO.Line line);
        void DeletLinefromStation(BO.Station station, BO.Line line);
        void UpdateStation(BO.Station linestation,int i);
      //  void UpdateStation(int id, Action<BO.LineStation> update); //method that knows to update specific fields in linestation
        void DeleteStation(int id);
        IEnumerable<BO.Station> GetSortStations();
        #endregion
        #region AdjacentStations
        IEnumerable<BO.AdjacentStations> GetAllAdjacentStations();//show all AdjacentStations
       // void AddAdjacentStations(BO.Station c1,BO.Station c2);

        #endregion

    }
}