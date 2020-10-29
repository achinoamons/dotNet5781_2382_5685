using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_2382_5685
{
    /// <summary>
    /// class of bus that describe a bus
    /// </summary>
    class Bus
    {
         string NumBus;
         string StartDate;//Date of commencement of activity  Of the means of transport
         string LastDate;//the last date of taking care of the bus
         double Kilometrath;
         double Fuel;
        public string N//the property of NumBus
        {
            set
            { NumBus = value; }
            get { return NumBus;}
        }
        public string S//the property of StartDate
        {
            set
            { StartDate = value; }
            get { return StartDate; }
        }
        public string L//the property of LastDate
        {
            set
            { LastDate = value; }
            get { return LastDate; }
        }
        public double K//the property of Kilometrath
        {
            set
            { Kilometrath = value; }
            get { return Kilometrath; }
        }
        public double F//the property of Fuel
        {
            set
            { Fuel = value; }
            get { return Fuel; }
        }


    }
}
