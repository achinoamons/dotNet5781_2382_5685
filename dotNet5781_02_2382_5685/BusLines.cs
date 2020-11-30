using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    /// <summary>
    /// a class that describe list of bus lines
    /// </summary>
    /// 
    //We decided that a single-valued identifier for a line is a number + the direction of the line(back or forth)
  public  class BusLines : IEnumerable
    {
        List<BusLine> list = new List<BusLine>();//list of all the buslines
        public List<BusLine> Prolist
        {
            set
            {
                list = value;
            }
            get { return list; }
        }
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
        public void AddLine(BusLine l,int i)//add a line to the bus lines list
        {

            foreach (BusLine busline in list)
            {
                //if the num of line and the Direction is  equel--it a sign that there is already a line like this
                if (busline.ProNumLine == l.ProNumLine && busline.ProbackOrForth==l.ProbackOrForth)
                {
                    throw new BusException("Error!this line is already exist-you cannot add it again!");
                }
            }

            list.Add(l); //add the line to the end of the list

        }
        public void DeleteLine(BusLine l,int i)//delete a line from the bus lines list
        {
            
            foreach (BusLine busline in list)
            {
                // //if the num of line and the path is  equel--it a sign that the is exist and you can delete it
                if (busline.ProNumLine == l.ProNumLine&&busline.ProbackOrForth==l.ProbackOrForth)
                {
                    list.Remove(busline);
                    return;
                }
            }
            //if the line is not exist
           
             throw new BusException("Error!the line that you wanted to delete  is not exist!"); 

        }
        public List<BusLine> this[int index]//this is the indexer of this class
        {
            get//We return a list in case of a two-way line with the same number
            {
                /* foreach (BusLine busline in list)
                 {
                     if (busline.ProNumLine == index)
                     {
                         return busline;

                     }
                 }
                 throw new BusException("Error!this line is not exist!");*/
                List<BusLine> help = new List<BusLine>();
                help=list.FindAll(x => x.ProNumLine == index);
                return help;
            }
            //set { list[index] = value; }
        }
        public List<BusLine> LineList(int kode)//Receives a bus station code number and returns the list The lines that pass through this station
        {
            List<BusLine> newstation = new List<BusLine>();//A new list of all the lines passing through the requested station
            foreach (BusLine busline in list)//Goes through the list of all bus lines
            {
                for (int i = 0; i < busline.ProStations.Count; i++)//Goes through the list of all stations of a particular line
                {
                    if (busline.ProStations[i].ProbusStationKey == kode)//if the station is exist
                    {
                        newstation.Add(busline);//add the busline to the new list
                        break;
                    }
                }
            }
            if (newstation.Count == 0)//if No line was found where the requested station passes
                throw new BusException("Error!No line was found where the requested station passes");
            else
                return newstation;
        }
        public List<BusLine> SortAccordingTime()
        {
            List <BusLine> tmp = list;
            tmp.Sort();
            return tmp;
        }
        public bool searchLine(BusLine l,int i)
        {
            foreach (BusLine busline in list)
            {
                //if the num of line and the direction is  equel--it a sign that there is already a line like this
                if (busline.ProNumLine == l.ProNumLine &&i==l.ProbackOrForth)
                {

                    return true;
                }
            }
            return false;
        }

        
        
        public void PrintLines()//print all the bus lines
        {
            if (list.Count != 0)
            {
                Console.WriteLine("the list of lines is:");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }
            }
            else
                throw new BusException("Error!there is no lines in the list");

        }
    }
}
