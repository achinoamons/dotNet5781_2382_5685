using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation
    {
        IEnumerable<BO.Line> ListOfLines;
        public int CodeStation { get; set; }//מספר תחנה
        public string Name { get; set; }//שם תחנה
        public int LineStationIndex { get; set; }//מס תחנה בקו---- כלומר איזה מס תחנה אני בקו
        //שיכלולים
        public int PrevStationCode { get; set; }//תחנה קודמת
        public int NextStationCode { get; set; }//תחנה הבאה
        public double DistancePrevStation { get; set; }//מרחק מתחנה קודמת
        public double DistanceNextStation { get; set; }//מרחק מתחנה הבאה
        public TimeSpan TimePrevStation { get; set; }//זמן מתחנה קודמת
        public TimeSpan TimeNextStation { get; set; }//זמן מתחנה הבאה

    }
}
