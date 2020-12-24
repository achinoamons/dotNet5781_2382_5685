using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// 
    /// מידע על 2 תחנות עוקבות
    /// </summary>
    public class AdjacentStations
    {
        public int Station1 { get; set; }
        public int CodeStation1 { get; set; }
        public int CodeStation2 { get; set; }
        public int Station2 { get; set; }
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }

    }
}
