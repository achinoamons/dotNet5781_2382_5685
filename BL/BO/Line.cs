using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
   public class Line
    {
        public  IEnumerable<BO.Station> ListOfStationsPass { get; set; }
        public int Code { get; set; }//code of the line
        public int LineID { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }
        public Areas area { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
