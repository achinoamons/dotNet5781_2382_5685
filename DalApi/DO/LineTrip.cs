using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{/// <summary>
/// יציאת קו
/// </summary>
    public class LineTrip
    {
        public int LineTripId { get; set; }
        public int LineId { get; set; }
        public TimeSpan Frequency { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan FinishAt { get; set; }

    }
}
