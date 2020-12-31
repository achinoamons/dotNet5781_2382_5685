using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    public class BadLineStationIdException : Exception
    {
        public int ID;
        public BadLineStationIdException(int id) : base() => ID = id;
        public BadLineStationIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineStationIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad linestation  line id: {ID}";
    }
    public class BadAdjacentStationsException : Exception
    {
        public int c1, c2;
        public BadAdjacentStationsException(int i,int j) : base() =>c1=i ;
        public BadAdjacentStationsException(int i,int j, string message) :
            base(message) => c1 = i;
        public BadAdjacentStationsException(int i,int j, string message, Exception innerException) :
            base(message, innerException) => c1 = i;

        public override string ToString() => base.ToString() + $", bad adjacentStations  codestation1: {c1} codestation2: {c2}";
    }
    public class BadodeStationException : Exception
    {
        public int codestation;
        public BadodeStationException(int code) : base() => codestation = code;
        public BadodeStationException(int code, string message) :
            base(message) => codestation = code;
        public BadodeStationException(int code, string message, Exception innerException) :
            base(message, innerException) => codestation = code;

        public override string ToString() => base.ToString() + $", bad codestation: {codestation}";
    }

    /*public class BadPersonIdCourseIDException : Exception
    {
        public int personID;
        public int courseID;
        public BadPersonIdCourseIDException(int perID, int crsID) : base() { personID = perID; courseID = crsID; }
        public BadPersonIdCourseIDException(int perID, int crsID, string message) :
            base(message)
        { personID = perID; courseID = crsID; }
        public BadPersonIdCourseIDException(int perID, int crsID, string message, Exception innerException) :
            base(message, innerException)
        { personID = perID; courseID = crsID; }

        public override string ToString() => base.ToString() + $", bad person id: {personID} and course id: {courseID}";
    }*/

}

