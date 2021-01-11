using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
//     public int Code { get; set; }
//public AREA Area { get; set; }// area of line activitis
//public TimeSpan StartAt { get; set; }
//public TimeSpan FinishAt { get; set; }
//public TimeSpan Frequency { get; set; }//frequency

//public IEnumerable<STATIONLINE> StationListOfLine { get; set; }
{
   public class Line
    {
        // public  IEnumerable<BO.Station/*צריך לשים פה את העוקבות של לאה*/> ListOfStationsPass { get; set; }

        public IEnumerable<BO.LineStation> ListOfStationsPass { get; set; }
        public int Code { get; set; }//code of the line
       public int LineID { get; set; }//
       // public int FirstStation { get; set; }
        public int LastStation { get; set; }
        public Areas area { get; set; }
        // public override string ToString() => this.ToStringProperty();
        public override string ToString()
        {
            string str = Code + "   " + area + " ";
            return str;
        }
    }
}
