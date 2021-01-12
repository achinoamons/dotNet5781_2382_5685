using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{/// <summary>
/// describes a logical station
/// </summary>
    public class LineStation
    {
        public int LineId { get; set; }//מזהה קו
        public int StationCode { get; set; }//קוד תחנה פיזית
        public int LineStationIndex { get; set;}//מס תחנה בקו---- כלומר איזה מס תחנה אני בקו
        public int PrevStationCode { get; set;}
        public int NextStationCode { get; set;}
        public int lineCode { get; set; }//number line//שדה שהוספתי ביום שני
        public override string ToString() => this.ToStringProperty();

    }
}
