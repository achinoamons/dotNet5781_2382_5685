using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
  public  class AdjacentStations
    {
        public int Station1Code { get; set; }//code of first station
        public int Station2Code { get; set; }//code of last station
        public double Distance { get; set; }//distance
        public TimeSpan Time { get; set; }//time 
        public override string ToString() => this.ToStringProperty();
    }
}
