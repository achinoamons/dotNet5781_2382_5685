using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class Line
    {
        IEnumerable<BO.LineStation> ListOfStations;
        public int LineID { get; set; }//קןד מזהה רץ יחודי---ספציפי לדוג קו 5
        public int Code { get; set; }//קוד ספציפי לדו קו 5 ירושלים וקו 5 ת"א---אז לכל 1 יהיה קוד שונה
        public int FirstStation { get; set; }
        public int LastStation { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
