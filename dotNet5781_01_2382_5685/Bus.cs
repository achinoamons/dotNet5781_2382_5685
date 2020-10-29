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
        DateTime StartDate;//Date of commencement of activity  Of the means of transport
        DateTime LastDate;//the last date of taking care of the bus
         double Kilometrath;
         double Fuel;
        public string ProNumBus//the property of NumBus
        {
            set
            { NumBus = value; }
            get { return NumBus;}
        }
        public DateTime ProStartDate//the property of StartDate
        {
            set
            { StartDate = value; }
            get { return StartDate; }
        }
        public DateTime ProLastDate//the property of LastDate
        {
            set
            { LastDate = value; }
            get { return LastDate; }
        }
        public double ProKilometrath//the property of Kilometrath
        {
            set
            { Kilometrath = value; }
            get { return Kilometrath; }
        }
        public double ProFuel//the property of Fuel
        {
            set
            { Fuel = value; }
            get { return Fuel; }
        }

      /* public Bus(string N="",double K=0, double F=0)
        {
             NumBus=N;
           // StartDate = S;
           // LastDate = L;
             Kilometrath = K; 
             Fuel=F;
        }*/
    }
}
