//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
////using DO;

//namespace BO
//{
//    [Serializable]
//    public class BadLineStationException : Exception//Exception for line station
//    {
//        public int ID;
//        public BadLineStationException(string message, Exception innerException) :
//            base(message, innerException) => ID = ((DO.BadLineStationIdException)innerException).ID;
//        public override string ToString() => base.ToString() + $", bad LineStation : {ID}";


//    }
//    public class BadStationException : Exception//Exception for line station
//    {
//        public int ID;

//        public BadStationException(string message) : base(message)
//        {
//        }

//        public BadStationException(string message, Exception innerException) :
//            base(message, innerException) => ID = ((DO.BadStationException)innerException);
//        public override string ToString() => base.ToString() + $", bad Station : {ID}";
//    }
//    public class BadLineException : Exception//Exception for line 
//    {
//        public int ID;
//        public BadLineException(string message, Exception innerException) :
//            base(message, innerException) => ID = ((DO.BadLineStationIdException)innerException).ID;
//        public override string ToString() => base.ToString() + $", bad Line : {ID}";
//    }
//};
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{


    //class Exception



    [Serializable]
    public class OlreadtExistExceptionBO : Exception
    {
        public OlreadtExistExceptionBO() : base() { }
        public OlreadtExistExceptionBO(string message) : base(message) { }
        public OlreadtExistExceptionBO(string message, Exception inner) : base(message, inner) { }
        protected OlreadtExistExceptionBO(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        // special constructor for our custom exception

        override public string ToString()
        {
            return "OlreadtExistException: " + Message;
        }
    }

    public class NotExistExceptionBO : Exception
    {
        public NotExistExceptionBO() : base() { }
        public NotExistExceptionBO(string message) : base(message) { }
        public NotExistExceptionBO(string message, Exception inner) : base(message, inner) { }
        protected NotExistExceptionBO(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        // special constructor for our custom exception

        override public string ToString()
        {
            return "NotExistException:" + Message;
        }
    }
}
