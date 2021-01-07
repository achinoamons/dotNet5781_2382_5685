using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
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
        public override string ToString() => this.ToStringProperty();
    }

// a x b c d
// ax
//xb
//ab
//bc
//cd


}
