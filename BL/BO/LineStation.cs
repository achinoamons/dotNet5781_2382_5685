//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BO
//    //   להעיף---צריך להעיףףף
//{
//    public class LineStation :Station 
//    {
//       IEnumerable<BO.Line> ListOfLines;
//        public int LineId { get; set; }//מזהה קו
//        public int StationCode { get; set; }//קוד תחנה פיזית
//        public int LineStationIndex { get; set; }//מס תחנה בקו---- כלומר איזה מס תחנה אני בקו
//        public int PrevStationCode { get; set; }
//        public int NextStationCode { get; set; }
//        public override string ToString() => this.ToStringProperty();



//        /*public double DistancePrevStation { get; set; }//מרחק מתחנה קודמת
//        public double DistanceNextStation { get; set; }//מרחק מתחנה הבאה
//        public TimeSpan TimePrevStation { get; set; }//זמן מתחנה קודמת
//        public TimeSpan TimeNextStation { get; set; }//זמן מתחנה הבאה
//        //public override string ToString() => this.ToStringProperty();*/
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO

{
    //public string StationName { get; set; }
    //public int CodeStation { get; set; }//cobe station 1
    //public int LineCode { get; set; }//lune number//name of line
    //                                 //public int PrevStation { get; set; }
    //public int NextStation { get; set; }//CODESTATION2
    //public double Distance { get; set; }
    //public TimeSpan Time { get; set; }
    //public override string ToString()
    //{
    //    string str = " StationName:" + StationName + " CodeStation: " + CodeStation + " Distance:" + Distance + " Time:" + Time;
    //    return str;
    //}
    public class LineStation
    {//הם הצמודות שלנו כביכול
        public string stationName { get; set; }
        public int Station1Code { get; set; }//code of first station
        public int Station2Code { get; set; }//code of last station
        public double Distance { get; set; }//distance
        public TimeSpan Time { get; set; }//time 
        public int CodeLine { get; set; }//name of line
        //public override string ToString() => this.ToStringProperty();
        public override string ToString()
        {
            string str = " StationName:" + stationName + " CodeStation: " + Station1Code + " Distance:" + Distance + " Time:" + Time;
            return str;
        }
    }
}