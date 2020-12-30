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
        public int LineTripId { get; set; }//מזהה יחודי ספציפי שלה
        public int LineId { get; set; }//מזהה של קו---חייב להיות כזה קו
        public TimeSpan Frequency { get; set; }//תדירות כל כמה זמן יוצא
        public TimeSpan StartAt { get; set; }//הגרלה של זמן התחלה
        public TimeSpan TimeTrip { get; set; }//מציין את זמן  הנסיעה----שדה שאנחנו הוספנו
        public TimeSpan FinishAt { get; set; }//זמן סיום לפי משך הנסיעה וזמן התחלה
        public override string ToString() => this.ToStringProperty();
    }
}
