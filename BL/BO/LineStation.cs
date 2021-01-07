using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
    //   להעיף---צריך להעיףףף
{
    public class LineStation :Station 
    {
       IEnumerable<BO.Line> ListOfLines;
        public int LineId { get; set; }//מזהה קו
        public int StationCode { get; set; }//קוד תחנה פיזית
        public int LineStationIndex { get; set; }//מס תחנה בקו---- כלומר איזה מס תחנה אני בקו
        public int PrevStationCode { get; set; }
        public int NextStationCode { get; set; }
        public override string ToString() => this.ToStringProperty();

        
       
        /*public double DistancePrevStation { get; set; }//מרחק מתחנה קודמת
        public double DistanceNextStation { get; set; }//מרחק מתחנה הבאה
        public TimeSpan TimePrevStation { get; set; }//זמן מתחנה קודמת
        public TimeSpan TimeNextStation { get; set; }//זמן מתחנה הבאה
        //public override string ToString() => this.ToStringProperty();*/
    }
}
