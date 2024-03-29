﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_01_2382_5685
{
    class Program
    {
        enum Options
        {Add,Choose,FuelOrCare,Show,Bye};
       static Random r = new Random(DateTime.Now.Millisecond);
        public static bool CheckForAdd( List<Bus> L1 , string num,int D, ref DateTime date)
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
       public static void Checkforchoose(List<Bus> L1, string num)
        {
            bool isEmpty = !L1.Any();

            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is already a bus like this
                    {
                        DateTime currentDate = DateTime.Now;
                        //// Only if less than a year has passed since the previous treatment
                        if ((bus.ProLastDate.Year == currentDate.Year) || ((bus.ProLastDate.Year + 1 == currentDate.Year) && (12 - bus.ProLastDate.Month + currentDate.Month <= 12)))
                        {
                            
                            double g = r.Next(1200); 
                            
                            if (bus.ProKilometrathAfterTipul + g <= 20000)
                            {
                                bus.ProKilometrath += g;//
                                bus.ProKilometrathAfterTipul +=g;//uptade the relevant fields
                                Console.WriteLine("success-uptading the relevant fields");
                            }
                            else
                                Console.WriteLine("The bus cannot make the trip");

                        }
                        else
                            Console.WriteLine("The bus cannot make the trip");//because more than a year has pass since the last treatment

                        break;
                    }
                    else
                        Console.WriteLine("The bus does not exist in the system");

                }
            }

            else
            {
                Console.WriteLine("The bus does not exist in the system");
                //return false;
            }

        }
        public static void  CheckforFuelOrCare(List<Bus> L1, string num,int n)
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
        public static void checkForShow(List<Bus> L1)
        {
            bool isEmpty = !L1.Any();
            if (!isEmpty)
            {
                foreach (Bus bus in L1)//Presentation of the km since the last treatment for all vehicles in the company.
                {
                    Console.Write("Registration Number:");
                    if (bus.ProStartDate.Year<2018)//print 7 digits
                    {

                        Console.WriteLine("{0}-{1}-{2}" ,bus.ProNumBus.Substring(0, 2), bus.ProNumBus.Substring(2, 3), bus.ProNumBus.Substring(5, 2));
                    }
                    else//print 8 digits
                    {
                        Console.WriteLine("{0}-{1}-{2}", bus.ProNumBus.Substring(0, 3), bus.ProNumBus.Substring(3, 2), bus.ProNumBus.Substring(5, 3));
                        
                    }
                    Console.WriteLine("Km since last treatment:{0}",bus.ProKilometrathAfterTipul);

                }
            }
        }
        static void Main(string[] args)
        {
            List<Bus> L1 = new List<Bus>();
            Console.WriteLine("Please enter one of the following options:");
 
            Console.WriteLine("0-Add a bus to the list of buses in the company");
            Console.WriteLine("1-Choosing a bus for travel");
            Console.WriteLine("2-Performing refueling or handling of a bus");
            Console.WriteLine("3-Show the mileage since the last treatment for all vehicles in the compan");
            Console.WriteLine("4-finish");
            Console.WriteLine("insert your choise please");
            Options o;
            o = (Options)int.Parse(Console.ReadLine());
            

            do
            {
                switch (o)
                {
                    case Options.Add:
                        Console.WriteLine("please enter Licensing number");
                        string num = Console.ReadLine();//num of registration
                        Console.WriteLine("Please enter date of commencement of activity");
                        DateTime date;//Activity start date
                        string s = Console.ReadLine();
                       // DateTime date = DateTime.Parse(Console.ReadLine());
                        int D = num.Length;
                        //bool b = DateTime.TryParse(s, out date);//I received string input from the user and converted
                        System.Globalization.CultureInfo hebrew = new System.Globalization.CultureInfo("he-IL");
                        bool b = DateTime.TryParseExact(s, "dd/MM/yyyy", hebrew, System.Globalization.DateTimeStyles.None, out date);
                        if (b)
                        {
                            if (Program.CheckForAdd(L1, num, D, ref date))
                            {
                                Bus B = new Bus();
                               
                                B.ProNumBus = num;
                                B.ProStartDate = date;
                                B.ProLastDate = date;//Update that last treatment date is the start date of activity
                                L1.Add(B);
                                Console.WriteLine("succeed");

                            }

                        }
                        else
                            Console.WriteLine("Error.insert again");

                        break;

                    case Options.Choose:

                        Console.WriteLine("please enter Licensing number");
                        string number = Console.ReadLine();//num of registration
                        Program.Checkforchoose(L1, number);

                        break;

                    case Options.FuelOrCare:

                        Console.WriteLine("please enter Licensing number");
                        string mis = Console.ReadLine();//num of registration
                        Console.WriteLine("Press 1 if you want to refuel or 0 if you want to take care of the bus");
                        string option= Console.ReadLine();//press 0 or 1
                        int n;
                        bool d = int.TryParse(option, out n);
                        
                        if (d)
                        {  
                            
                            if (n!=0 && n!=1)
                            {
                                Console.WriteLine("ERROR");
                               
                                
                            }
                            else
                            {

                                Program.CheckforFuelOrCare(L1, mis, n);
                            }
                        }
                        
                        break;

                    case Options.Show:
                        Program.checkForShow(L1);
                        
                        break;
                    case Options.Bye:
                        Console.WriteLine("bye bye");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("insert your choise please");
                o = (Options)int.Parse(Console.ReadLine());
            }
            while (o != Options.Bye);
            Console.ReadKey();

        }
       
    }
    
}
