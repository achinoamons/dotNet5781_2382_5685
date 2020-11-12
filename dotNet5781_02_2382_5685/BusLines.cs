﻿using System;
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
    //We decided that a single-valued identifier for a line is a number + departure station + destination station 
    class BusLines : IEnumerable
    {
        List<BusLine> list = new List<BusLine>();//list of all the buslines
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
        public void AddLine(BusLine l)//add a line to the bus lines list
        {

            foreach (BusLine busline in list)
            {
                //if the num of line and the path is  equel--it a sign that there is already a line like this
                if (busline.ProNumLine == l.ProNumLine && busline.ProFirstStation == l.ProFirstStation && busline.ProLastStation == l.ProLastStation)
                {
                    throw new BusException("Error!this line is already exist-you cannot add it again!");
                }
            }

            list.Add(l); //add the line to the end of the list

        }
        public void DeleteLine(BusLine l)//delete a line from the bus lines list
        {
            bool flag = false;
            foreach (BusLine busline in list)
            {
                // //if the num of line and the path is  equel--it a sign that the is exist and you can delete it
                if (busline.ProNumLine == l.ProNumLine && busline.ProFirstStation == l.ProFirstStation && busline.ProLastStation == l.ProLastStation)
                {
                    list.Remove(l);
                    flag = true;
                    break;

                }
            }
            //if the line is not exist
            if (flag == false)
            { throw new BusException("Error!the line that you wanted to delete  is not exist!"); }

        }
       public BusLine this[int index]//this is the indexer of this class
        {
            get
            {
                foreach (BusLine busline in list)
                {
                    if (busline.ProNumLine == index)
                    { return busline;

                    }
                }
                throw new BusException("Error!this line is not exist!");
            }
            set { list[index] = value; }
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
            list.Sort();
            return list;
        }
       public bool searchLine(BusLine l)
        {
            foreach (BusLine busline in list)
            {
                //if the num of line and the path is  equel--it a sign that there is already a line like this
                if (busline.ProNumLine == l.ProNumLine && busline.ProFirstStation == l.ProFirstStation && busline.ProLastStation == l.ProLastStation)
                {

                    return true;
                }
            }
            return false;
        }

    }
}
