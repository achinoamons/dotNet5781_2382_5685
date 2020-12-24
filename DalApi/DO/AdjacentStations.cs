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
        public int Station1Code { get; set; }//קוד תחנה ראשונה
        public int Station2Code { get; set; }//קוד תחנה שנחה
        public double Distance { get; set; }//מרחק בין תחנות
        public TimeSpan Time { get; set; }//זמן ממוצע בין התחנות 

    }
}
