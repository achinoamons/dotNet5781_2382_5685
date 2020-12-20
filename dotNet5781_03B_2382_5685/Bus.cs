using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace dotNet5781_03B_2382_5685
{
    /// <summary>
    /// class of bus that describe a bus
    /// </summary>
    /// 

  public  enum Status {readyForTravel,duringTravel,InFual,InTreatment}
   public class Bus: DependencyObject
    {

        //dependency property that we use in order to update the progress bar
        public double MyPropertyTime
        {
            get { return (double)GetValue(MyPropertyTimeProperty); }
            set { SetValue(MyPropertyTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyPropertyTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyTimeProperty =
            DependencyProperty.Register("MyPropertyTime", typeof(double), typeof(Bus), new PropertyMetadata(null));


        //dependecy property that show how much time remain in seconds


        public int MyPropertyForRemainSecond
        {
            get { return (int)GetValue(MyPropertyForRemainSecondProperty); }
            set { SetValue(MyPropertyForRemainSecondProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyPropertyForRemainSecond.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyForRemainSecondProperty =
            DependencyProperty.Register("MyPropertyForRemainSecond", typeof(int), typeof(Bus), new PropertyMetadata(null));




        Status stat;
        string NumBus;
        DateTime StartDate;//Date of commencement of activity  Of the means of transport
        DateTime LastDate;//the last date of taking care of the bus
        double Kilometrath;
        double Fuel;
        double KilometrathAfterTipul;//km after treatment
        BackgroundWorker inrefull;
        public Status ProStat//the prperty of status
        {
            set { stat = value; }
            get { return stat; }
        }
        public string ProNumBus//the property of NumBus
        {
            set
            { NumBus = value; }
            get {
                return NumBus;
            }
        }
        public string PNumBus//return the number of the bus according to the number of digits
        {
            set
            {
                NumBus = value;
            }
            get
            {
                if (ProStartDate.Year < 2018)//print 7 digits
                {

                    return string.Format("{0}-{1}-{2}", NumBus.Substring(0, 2), NumBus.Substring(2, 3), NumBus.Substring(5, 2));
                }
                else//print 8 digits
                {
                    return string.Format("{0}-{1}-{2}", NumBus.Substring(0, 3), NumBus.Substring(3, 2), NumBus.Substring(5, 3));

                }
            }
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
        
        public Bus()
        {
            inrefull = new BackgroundWorker();
            inrefull.DoWork += Inrefull_DoWork;
            inrefull.RunWorkerCompleted += Inrefull_RunWorkerCompleted;
            inrefull.ProgressChanged += Inrefull_ProgressChanged;
            inrefull.WorkerReportsProgress = true;
        }
        static Random r = new Random(DateTime.Now.Millisecond);
        public static bool AddBus(ObservableCollection<Bus> L1, string num, int D, ref DateTime date)//מוסיפה אוטובוס
        {
            //int counter = 0;
            bool isEmpty = !L1.Any();
            if (!isEmpty)
            {
                foreach (Bus bus in L1)
                {
                    if (bus.ProNumBus == num)//check if there is already a bus like this
                    {
                        //Console.WriteLine("the bus is already exist-insert again");
                        return false;

                    }


                }
            }

            if ((date.Year < 2018 && D == 7) || (date.Year >= 2018 && D == 8))//Input integrity checker
            {
                return true;
            }

            else
                //Console.WriteLine("wrong input-try again");
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
                

                         double g = r.Next(1200);/*
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
                         }*/
                        bool b = bus.canTravel();
                        if(b)
                        {
                            //uptade the relevant fields
                            bus.ProKilometrath += g;//
                            bus.ProKilometrathAfterTipul += g;
                            bus.ProFuel -= g;
                           // Console.WriteLine("success-uptading the relevant fields");
                        }
                        
                    }
                    
                       

                }
               // Console.WriteLine("The bus does not exist in the system");//if i didnt fint
                return;

            }

            else//if  list is empty
            {
               // Console.WriteLine("The bus does not exist in the system");
                //return false;
            }

        }
        private void Inrefull_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = e.ProgressPercentage;
            //עכשיו אני מודיעה לגרפיקה מה לעשות
           
            Bus current = e.UserState as Bus;
            current.MyPropertyTime = i;
            current.MyPropertyForRemainSecond = 12 - i;
            
        }

        private void Inrefull_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ProStat = Status.readyForTravel;//
            System.Windows.MessageBox.Show("the bus" + this.PNumBus + " finish refuelling");
          
            this.MyPropertyTime = 0;
            this.MyPropertyForRemainSecond = 0;

        }

        private void Inrefull_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            for (int i =0; i <12; i++)//השהייה לשעתיים
            {
                Thread.Sleep(1000);
               // int f = (int)(i * 100 / (12));
                inrefull.ReportProgress(i, e.Argument);//דיווח על השינוי
            }
        }
        public void Refull()//refuelling a bus
        {

            
            
                if (this.ProStat != Status.InTreatment && this.ProStat != Status.duringTravel && this.ProStat != Status.InFual)//only if he isnt during something
                {
                    if (this.ProFuel == 1200)
                    { System.Windows.MessageBox.Show("The bus does not need refuelling");
                        return; 
                    }
                  else  
                    {
                        double delek = 1200 - this.ProFuel;//checking how much fuel the  bus need
                        this.ProFuel += delek;//updating the fuel tank
                        this.ProStat = Status.InFual;
                        inrefull.RunWorkerAsync(this);//start process
                    }
                }
                else
                    System.Windows.MessageBox.Show("the bus is during anothe process");

            
       
        }

       


     
        public bool canTravel()//a function that check if a bus can travell
        {
            double g = r.Next(1200);
            if ((ProKilometrathAfterTipul) + g >= 20000 || (DateTime.Now - ProLastDate).TotalDays >= 365)
            {
                return false;
            }
            if (ProFuel - g < 0)//if i dont have enoufh fual for the travel
            {
                Console.WriteLine("The bus cannot make the trip");
                return false;
            }
            else//if he can take the travel
            {
                return true;
            }
        }
      
    }
}
