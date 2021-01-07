//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DO
//{
//    [Serializable]
//    public class BadLineIdException : Exception//for line
//    {
//        public int ID;
//        public BadLineIdException(int id) : base() => ID = id;

//        public BadLineIdException(string message) : base(message)
//        {
//        }

//        public BadLineIdException(int id, string message) :
//            base(message) => ID = id;
//        public BadLineIdException(int id, string message, Exception innerException) :
//            base(message, innerException) => ID = id;

//        public override string ToString() => base.ToString() + $", bad line id: {ID}";
//    }
//    public class BadLineStationIdException : Exception//for line station
//    {
//        public int ID;
//        public BadLineStationIdException(int id) : base() => ID = id;
//        public BadLineStationIdException(int id, string message) :
//            base(message) => ID = id;
//        public BadLineStationIdException(int id, string message, Exception innerException) :
//            base(message, innerException) => ID = id;

//        public override string ToString() => base.ToString() + $", bad linestation  line id: {ID}";
//    }
//    public class BadAdjacentStationsException : Exception//for adjacent stations
//    {
//        public int c1, c2;
//        public BadAdjacentStationsException(int i,int j) : base() =>c1=i ;
//        public BadAdjacentStationsException(int i,int j, string message) :
//            base(message) => c1 = i;
//        public BadAdjacentStationsException(int i,int j, string message, Exception innerException) :
//            base(message, innerException) => c1 = i;

//        public override string ToString() => base.ToString() + $", bad adjacentStations  codestation1: {c1} codestation2: {c2}";
//    }


//    public class BadStationException : Exception
//    {
//        public int codestation;
//        public BadStationException(int code) : base() => codestation = code;
//        public BadStationException(int code, string message) :
//            base(message) => codestation = code;
//        public BadStationException(int code, string message, Exception innerException) :
//            base(message, innerException) => codestation = code;

//        public override string ToString() => base.ToString() + $", bad codestation: {codestation}";
//    }

//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //class Exception



    [Serializable]
    public class OlreadtExistException : Exception
    {
        public OlreadtExistException() : base() { }
        public OlreadtExistException(string message) : base(message) { }
        public OlreadtExistException(string message, Exception inner) : base(message, inner) { }
        protected OlreadtExistException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        // special constructor for our custom exception

        override public string ToString()
        {
            return "OlreadtExistException: " + Message;
        }
    }

    public class NotExistException : Exception
    {
        public NotExistException() : base() { }
        public NotExistException(string message) : base(message) { }
        public NotExistException(string message, Exception inner) : base(message, inner) { }
        protected NotExistException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        // special constructor for our custom exception

        override public string ToString()
        {
            return "NotExistException:" + Message;
        }
    }
}

