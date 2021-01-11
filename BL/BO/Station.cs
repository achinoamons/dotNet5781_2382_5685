using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //public AREA are { get; set; }
    //public int Code { get; set; }//station code
    //public string Name { get; set; }//station name

    //public IEnumerable<LINE> LinesOnThisStation { get; set; }// קווי אוטובוס שעוברים בתחנה
    //public IEnumerable<STATIONLINE> LinesAdjacentStations { get; set; }//רשימת תחנות עוקבות לתחנה זאת
    //public override string ToString()
    //{
    //    string str = Code + " " + Name + " ";
    //    return str;
    //}
    public  class Station
    {
         public Areas area { get; set; }
        public IEnumerable<BO.Line> ListOfLinesPass { get; set; }//רשימת קווים שעוברים בתחנה
         // public   IEnumerable<BO.AdjacentStations> ListOfAdjStations { get; set; }//list of adj to her
        public IEnumerable<BO.LineStation> ListOfAdjStations { get; set; }//list of adj to her
        public int CodeStation { get; set; }
        public string Name { get; set; }
        // public double Longitude { get; set; }
        // public double Latitude { get; set; }
        // public override string ToString() => this.ToStringProperty();
        public override string ToString()
        {
            string str = CodeStation + " " + Name + " ";
            return str;
        }
    }

    // a x b c d
    // ax
    //xb
    //ab
    //bc
    //cd


}
