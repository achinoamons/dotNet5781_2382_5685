using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    
    class Program

    {
        enum Options
        { Insert, Deletion, Search, Printing, Exit };
        static int d = 0;
        static void Main(string[] args)
        {
            //1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16.....40
            List<BusLineStation> physical = new List<BusLineStation>();
            //physical.Capacity = 44;
            for (int i = 0; i < 40; i++)
            {

                BusLineStation bb = new BusLineStation();
                physical.Add(bb);//initialiation of 40 physical busstations
            }

            BusLines list = new BusLines();//object of class BusLines
            
            for (int i = 1; i < 11; i++)//initialitation of 10 lines
            {
                
            //BusLineStation b = new BusLineStation();
            //BusLineStation c = new BusLineStation();
              //list[i] = new BusLine(++d, b, c);//שמתי בהערה ושיניתי אינדקסר להחזיר רשימה בלי סט כלומר הולכים לפי 2 השורות החדשות פה
              BusLine bb= new BusLine(++d, 0);
                list.AddLine(bb,0);//we decided to initiate the lines only for one way-in the program we will add 2 ways line
               // List<BusLineStation> help = new List<BusLineStation>();
                for (int j=0;j<i*4;j++)
                {

                    //list[i][0].AddStation(physical[j]);//We approached through the property and added stations to each line
                    list[i][0].ProStations.Add(physical[j]);
                }
               
       
            }

            Console.WriteLine("Please enter one of the following options:");
            Console.WriteLine("0-Insert options");
            Console.WriteLine("1-Deletion options");
            Console.WriteLine("2-Search options");
            Console.WriteLine("3-Printing options ");
            Console.WriteLine("4-Exit");
            Console.WriteLine("insert your choise please");//
            Options o;
            o = (Options)int.Parse(Console.ReadLine());
            do
            {
                switch (o)
                {
                    case Options.Insert:
                        Console.WriteLine("Press 0 for adding a new bus line and 1 for adding a station to a bus line");//0 להוספת קו חדש ו 1 להוספת תחנה לקו אוטובוס
                        string option = Console.ReadLine();//press 0 or 1
                        int n = int.Parse(option);
                       // int d = int.TryParse(option, out n);
                        if (n==0)//if he deside to adding a new bus line
                        {
                            
                            /*Console.WriteLine("Please enter the first station number of the line ");//enter the first  station
                            string numfirststation = Console.ReadLine();
                            Console.WriteLine("Please enter the last station number of the line ");//enter the last  station
                            string numlaststation = Console.ReadLine();
                            BusLineStation firststation = new BusLineStation();
                            firststation.ProbusStationKey = int.Parse(numfirststation);
                            BusLineStation laststation = new BusLineStation();
                            laststation.ProbusStationKey = int.Parse(numlaststation);*/
                            try {
                                Console.WriteLine("Please enter the number of the line that less than 4 digits");
                                int num = int.Parse(Console.ReadLine());//number of line
                                Console.WriteLine("press 0 for 1 way line or 1 for back line");
                            int ans = int.Parse(Console.ReadLine());//the direction(back or forth)
                                BusLine busline = new BusLine(num,ans);
                                list.AddLine(busline,ans);
                            }
                            catch (BusException k) { Console.WriteLine(k.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomalies
                        }
                        if (n==1)
                        {
                           /* Console.WriteLine("Enter the line number for which you want to add a station");//enter the num line
                            string numline = Console.ReadLine();
                            int num = int.Parse(numline);
                            Console.WriteLine("Please enter the first station number of the line ");//enter the first  station
                            string numfirststation = Console.ReadLine();
                            Console.WriteLine("Please enter the last station number of the line ");//enter the last  station
                            string numlaststation = Console.ReadLine();
                            BusLineStation firststation = new BusLineStation();
                          
                                firststation.ProbusStationKey = int.Parse(numfirststation);
                                BusLineStation laststation = new BusLineStation();*/
                            try {
                                Console.WriteLine("Please enter the number of the line that less than 4 digits");
                                int num = int.Parse(Console.ReadLine());//number of line
                                Console.WriteLine("press 0 for 1 way line or 1 for back line");
                                int ans = int.Parse(Console.ReadLine());//the direction(back or forth)
                                BusLine busline = new BusLine(num, ans);
                               
                                if (list.searchLine(busline,ans)) //if the line is exist
                                {
                                    Console.WriteLine("Enter the station number you want to add");//enter the num station
                                    string numstation = Console.ReadLine();
                                    BusLineStation station = new BusLineStation();
                                    station.ProbusStationKey = int.Parse(numstation);
                                    //in case of Two-way line (same bus line)-we devide
                                    //forth
                                    //Console.WriteLine("press 0 if you want to add for 1 way line or 1 for back line");
                                    //int choose = int.Parse(Console.ReadLine());
                                    if (ans==0)//if i want to add to the first line
                                    {
                                        list[num][0].AddStation(station);
                                    }
                                    //back
                                    else if(ans==1)//if i want to add to the second line
                                    {
                                        list[num][1].AddStation(station);
                                    }
                                    else
                                        throw new BusException("Error!you can only press 0 or 1");
                                }
                                else//if the line is not exist
                                {
                                    Console.WriteLine("The bus line does not exist in the system");
                                }
                            }
                            catch (BusException k) { Console.WriteLine(k.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomalies
                        }
                        break;


                    case Options.Deletion:
                        Console.WriteLine("Press 0 for deleting a  bus line and 1 for deleting a station from a bus line");
                        string op = Console.ReadLine();//press 0 or 1
                        int g= int.Parse(op);
                       
                        try
                        {
                            if (g==0)//if you press 0-delete a bus line
                            {
                               /* Console.WriteLine("Please enter the number of the line that less than 4 digits");
                                string numline = Console.ReadLine();
                                int num = int.Parse(numline);
                                Console.WriteLine("Please enter the first station number of the line ");//enter the first  station
                                string numfirststation = Console.ReadLine();
                                Console.WriteLine("Please enter the last station number of the line ");//enter the last  station
                                string numlaststation = Console.ReadLine();
                                BusLineStation firststation = new BusLineStation();
                                firststation.ProbusStationKey = int.Parse(numfirststation);
                                BusLineStation laststation = new BusLineStation();
                                laststation.ProbusStationKey = int.Parse(numlaststation);*/
                                try
                                {
                                    Console.WriteLine("Please enter the number of the line that less than 4 digits");
                                    int num = int.Parse(Console.ReadLine());//number of line
                                    Console.WriteLine("press 0 for 1 way line or 1 for back line");
                                    int ans = int.Parse(Console.ReadLine());//the direction(back or forth)
                                    BusLine busline = new BusLine(num, ans);
                                    list.DeleteLine(busline,ans);
                                }
                                catch (BusException k) { Console.WriteLine(k.Message); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomalies
                            }
                            else//Deleting a station from a bus line route
                            {
                                /*Console.WriteLine("Please enter the number of the line that less than 4 digits");
                                string numline = Console.ReadLine();
                                int num = int.Parse(numline);
                                Console.WriteLine("Please enter the first station number of the line ");//enter the first  station
                                string numfirststation = Console.ReadLine();
                                Console.WriteLine("Please enter the last station number of the line ");//enter the last  station
                                string numlaststation = Console.ReadLine();
                                BusLineStation firststation = new BusLineStation();
                                firststation.ProbusStationKey = int.Parse(numfirststation);
                                BusLineStation laststation = new BusLineStation();
                                laststation.ProbusStationKey = int.Parse(numlaststation);
                                BusLine busline = new BusLine(num, firststation, laststation);*/
                                Console.WriteLine("Please enter the number of the line that less than 4 digits");
                                int num = int.Parse(Console.ReadLine());//number of line
                                Console.WriteLine("press 0 for 1 way line or 1 for back line");
                                int ans = int.Parse(Console.ReadLine());//the direction(back or forth)
                                BusLine busline = new BusLine(num, ans);
                                bool y = list.searchLine(busline,ans);
                                if (y)//if the line exist-delete the station
                                {
                                    Console.WriteLine("enter the number of the station that you want to delete");
                                    int st = int.Parse(Console.ReadLine());
                                    BusLineStation bu = new BusLineStation();
                                    bu.ProbusStationKey = st;//apdating the field of stationkey according to input                         
                                    if (ans==0)//if its the first
                                    {
                                        list[num][0].DeletStation(bu);
                                    }
                                    //back
                                    else if (ans==1)//if its the second
                                    {
                                        list[num][1].DeletStation(bu);
                                    }
                                    else throw new BusException("Error!you can only press 0 or 1");
                                }
                                else
                                    Console.WriteLine("there is no line like this so its impossible to delete the station");
                            }
                        }
                        catch (BusException k) { Console.WriteLine(k.Message); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomalies
                        break;
                    case Options.Search: 
                        Console.WriteLine("Press 1 for Lines passing through the station according to station or 0 for printing the options for travel between 2 stations");
                        string opt= Console.ReadLine();//press 0 or 1
                        int s;
                        bool f = int.TryParse(opt, out s);
                        if(f)//Lines passing through the station according to station number
                        {
                            
                                try 
                                {
                                    Console.WriteLine("enter the bus station number");
                                    int go = int.Parse(Console.ReadLine());//input of the station number
                                    BusLineStation ss = physical.Find(x => x.ProbusStationKey == go);
                                    if (ss.ProbusStationKey == go)//if there is a station like this
                                    {
                                        List<BusLine> l = new List<BusLine>();
                                        l = list.LineList(go);
                                        Console.WriteLine("The lines that pass through the station: " + go);
                                        for (int i = 0; i < l.Count; i++)//printing the lines 
                                        {
                                            Console.WriteLine(l[i].ProNumLine);
                                        }
                                    }
                                else
                                  throw new BusException("there is no station like this");

                            }
                                catch (BusException k) { Console.WriteLine(k.Message); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomalies
                            

                            

                        }
                        else//the second option
                        {
                            //input of begin and destination stations
                            Console.WriteLine("enter the Starting point");
                            int start = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter the destination station");
                            int dest= int.Parse(Console.ReadLine());


                        }
                       
                        break;

                    case Options.Printing://לטפל במקרה השני של הדפסה שלא עובד טוב
                        //0-Press 0 to print all the bus lines in the system
                        //1-print a list of all the stations and line numbers that pass through them
                        Console.WriteLine("Press 0 to print all the bus lines in the system and 1 to print a list of all the stations and line numbers that pass through them");
                        
                        int choice = int.Parse(Console.ReadLine());
                        if (choice==0)//print all bus lines
                        {
                            try
                            {
                                list.PrintLines();
                            }
                            catch (BusException k) { Console.WriteLine(k.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomalies
                        }
                        if (choice==1)//print a list of all the stations and line numbers that pass through them
                        {
                            try
                            {
                                
                                List<BusLine> ls = new List<BusLine>();
                                for (int i = 0; i < physical.Count; i++)
                                {
                                    Console.WriteLine( physical[i]/*.ProbusStationKey +":"*/);//calling tostring
                                    Console.WriteLine("The list of lines that pass through the station:");
                                    ls = list.LineList(physical[i].ProbusStationKey);
                                    
                                    for (int j = 0; j < ls.Count; j++)
                                    {
                                        Console.Write(ls[j].ProNumLine+ " ");

                                    }
                                    Console.WriteLine('\n');
                                }
                            }
                            catch (BusException k) { Console.WriteLine(k.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }//If there are any unexpected anomali
                        }
                        break;
                    case Options.Exit:
                        Console.WriteLine("good-bye!");
                        break;

                    default:
                        break;
                }
                Console.WriteLine("insert your choise please");
                o = (Options)int.Parse(Console.ReadLine());
            }
            while (o != Options.Exit);
            Console.ReadKey();
        }
    }
}
        

     
 
    

