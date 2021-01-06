using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DO;

namespace BO
{
    [Serializable]
    public class BadLineStationException : Exception//Exception for line station
    {
        public int ID;
        public BadLineStationException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineStationIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad LineStation : {ID}";


    }
    public class BadStationException : Exception//Exception for line station
    {
        public int ID;

        public BadStationException(string message) : base(message)
        {
        }

        public BadStationException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineStationIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad Station : {ID}";
    }
    public class BadLineException : Exception//Exception for line 
    {
        public int ID;
        public BadLineException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineStationIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad Line : {ID}";
    }
};
