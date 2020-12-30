using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{/// <summary>
/// נסיעת משתמש
/// </summary>
   public class Trip
    {
        public int IdTrip { get; set; }//מספר נסיעה של המשתמש-מזהה יחודי
        public string UserName { get; set; }//שם משתמש
        public int LineId { get; set; }//מזהה קו-מספר הקו
        public int InStation { get; set; }//תחנת עלייה
        public TimeSpan InAt { get; set; }//זמן עליה
        public TimeSpan TimeTrip { get; set; }//זמן הנסיעה-אני הוספתי 
        public int OutStation { get; set; }//תחנת ירידה
        public TimeSpan OutAt { get; set; }//זמן ירידה
        public override string ToString() => this.ToStringProperty();
    }
}
