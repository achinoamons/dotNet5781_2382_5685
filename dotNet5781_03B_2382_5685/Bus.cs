using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_2382_5685
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
        double KilometrathAfterTipul;//km after treatment

        public string ProNumBus//the property of NumBus
        {
            set
            { NumBus = value; }
            get { return NumBus; }
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
        public double ProKilometrathAfterTipul//the property of Fuel
        {
            set
            { KilometrathAfterTipul = value; }
            get { return KilometrathAfterTipul; }
        }
        static Random r = new Random(DateTime.Now.Millisecond);
        public static bool AddBus(List<Bus> L1, string num, int D, ref DateTime date)//מוסיפה אוטובוס
        {
            //int counter = 0;
            bool isEmpty = !L1.Any();
            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is already a bus like this
                    {
                        Console.WriteLine("the bus is already exist-insert again");
                        return false;

                    }


                }
            }

            if ((date.Year < 2018 && D == 7) || (date.Year >= 2018 && D == 8))//Input integrity checker
            {
                return true;
            }

            else
                Console.WriteLine("wrong input-try again");
            return false;



        }
        public static void ChooseBusForTravel(List<Bus> L1, string num)
        {
            bool isEmpty = !L1.Any();

            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is  a bus like this
                    {
                       // DateTime currentDate = DateTime.Now;
                        ////  if more than a year has passed since the previous treatment
                     
                        double g = r.Next(1200);
                        if ((bus.ProKilometrathAfterTipul)+g>=20000||(DateTime.Now-bus.ProLastDate).TotalDays>=365)
                        {
                            Console.WriteLine("The bus cannot make the trip");
                            return;

                            
                        }
                        if(bus.ProFuel-g<0)//if i dont have enoufh fual for the travel
                        {
                            Console.WriteLine("The bus cannot make the trip");
                            return;
                        }
                        else//if he can take the travel
                        {
                            //uptade the relevant fields
                            bus.ProKilometrath += g;//
                            bus.ProKilometrathAfterTipul += g;
                            bus.ProFuel -= g;
                            Console.WriteLine("success-uptading the relevant fields");
                        }
                        
                    }
                    
                       

                }
                Console.WriteLine("The bus does not exist in the system");//if i didnt fint
                return;

            }

            else//if  list is empty
            {
                Console.WriteLine("The bus does not exist in the system");
                //return false;
            }

        }
        public static void FuelOrCare(List<Bus> L1, string num, int n)
        {
            bool isEmpty = !L1.Any();
            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is already a bus like this
                    {
                        if (n == 1)//if is delek
                        {
                            bus.ProFuel += 1200;//update the fuel more a 1200
                            Console.WriteLine("The bus got fuel successfully");
                            return;
                        }
                        else
                        {
                            DateTime currentDate = DateTime.Now;
                            bus.ProLastDate = currentDate;//updet tha last day that was tipul
                            bus.ProKilometrathAfterTipul = 0;
                            Console.WriteLine("The bus was handled successfully");
                            return;
                        }
                    }
                }
                //Console.WriteLine("The bus does not exist in the system");//if the bus is not exist

            }

            Console.WriteLine("The bus does not exist in the system");//if the bus is not exist
        }
        public static void ShowKmSinceLastTreatment(List<Bus> L1)
        {
            bool isEmpty = !L1.Any();
            if (!isEmpty)
            {
                foreach (Bus bus in L1)//Presentation of the km since the last treatment for all vehicles in the company.
                {
                    Console.Write("Registration Number:");
                    if (bus.ProStartDate.Year < 2018)//print 7 digits
                    {

                        Console.WriteLine("{0}-{1}-{2}", bus.ProNumBus.Substring(0, 2), bus.ProNumBus.Substring(2, 3), bus.ProNumBus.Substring(5, 2));
                    }
                    else//print 8 digits
                    {
                        Console.WriteLine("{0}-{1}-{2}", bus.ProNumBus.Substring(0, 3), bus.ProNumBus.Substring(3, 2), bus.ProNumBus.Substring(5, 3));

                    }
                    Console.WriteLine("Km since last treatment:{0}", bus.ProKilometrathAfterTipul);

                }
            }
        }

    }
}
