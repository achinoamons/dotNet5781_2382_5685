using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_2382_5685
{
    class BusStation
    {
        string busStationKey;
        public string ProbusStationKey
        {
            set
            {

                if (busStationKey.Length <= 6 || (int.Parse(busStationKey) >= 0))//check input validity
                {
                    busStationKey = value;
                }
                else
                    Console.WriteLine("Error!Station code must be positive and have a maximum of 6 digits");
            }
            get
            {
                return busStationKey;
            }
        }

       

        Random r;
        double Latitude;
        public double ProLatitude { get => Latitude; set => Latitude = r.NextDouble() * (31 - 33.3) + 31; }
        double Longitude;
        public double ProLongitude { get => Longitude; set => Longitude = r.NextDouble() * (34.3 - 35.5) + 34.3; }
        string busStationAdress;
        public string ProBusStationAdress { get => busStationAdress; set => busStationAdress = value; }

        public BusStation()//constractor
          {
            //Lottery of real numbers according to the longitude and latitude of the State of Israel
            Latitude = r.NextDouble() * (31 - 33.3) + 31;
            Longitude = r.NextDouble() * (34.3 - 35.5) + 34.3;
            busStationAdress = "";

          }
        public override string ToString()//overriding tostring of object

        {

            string deg = "°";
            
            {
                string s = "Bus Station Code:" + busStationKey + "Latitude: " + Latitude + deg + "N" + "Longitude: " + Latitude + deg + "E";
               
                return s;
            } 
        }



    }
}

