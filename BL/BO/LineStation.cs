using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
    //   להעיף---צריך להעיףףף
{
    public class LineStation
    {
        //{
        //   // IEnumerable<BO.Line> ListOfLines;
        //    public int LineId { get; set; }//מזהה קו
        //    public int StationCode { get; set; }//קוד תחנה פיזית
        //    public int LineStationIndex { get; set; }//מס תחנה בקו---- כלומר איזה מס תחנה אני בקו
        //    public int PrevStationCode { get; set; }
        //    public int NextStationCode { get; set; }
        //    public override string ToString() => this.ToStringProperty();


        public int LineId { get; set; }//מזהה קו
        public int StationCode { get; set; }//
        public int LineStationIndex { get; set; }
        public TimeSpan Time { get; set; }
        public double Distance { get; set; }


    }
}
