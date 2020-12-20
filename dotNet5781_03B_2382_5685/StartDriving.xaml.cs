using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dotNet5781_03B_2382_5685
{
    /// <summary>
    /// Interaction logic for StartDriving.xaml
    /// </summary>
    public partial class StartDriving : Window
    {
        private Bus helpbus;
        public Bus ProHelpBus//public property for the bus
        {
            get
            {
                return helpbus;
            }
            set
            {
                helpbus = value;
            }
        }
        BackgroundWorker wentTravel;

        public StartDriving(Bus currentBus)
        {
            ProHelpBus = currentBus;
            InitializeComponent();
            wentTravel = new BackgroundWorker();
            wentTravel.DoWork += WentTravel_DoWork;
            wentTravel.ProgressChanged += WentTravel_ProgressChanged;
            wentTravel.RunWorkerCompleted += WentTravel_RunWorkerCompleted;
            wentTravel.WorkerReportsProgress = true;
           
        }

        private void WentTravel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            ProHelpBus.ProStat = Status.readyForTravel;//
            MessageBox.Show("the bus "+ ProHelpBus.PNumBus+ " finish travelling");
            //this.Close();
            ProHelpBus.MyPropertyTime = 0;


        }

        private void WentTravel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = e.ProgressPercentage;
            //
             // progbar.Value = i;
            ProHelpBus.MyPropertyTime = i;
              

             
        }

        private void WentTravel_DoWork(object sender, DoWorkEventArgs e)
        {
            double d = (double)e.Argument;
            Random r = new Random();
            int j = r.Next(20, 51);
            int time = (int)(d / j);
            time *= 60;
            for (int i = 0; i < (time); i++)
            {
                Thread.Sleep(100);//עשירת שניה
                int f = (int)(i*100  / (time));//percent
                wentTravel.ReportProgress(f);//
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //input is only numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

       
        public bool Check(double i)//check if the bus can travel
        {

            // int i = int.Parse(tbdistance.Text);

            if ((ProHelpBus.ProKilometrathAfterTipul) + i >= 20000 || (DateTime.Now - ProHelpBus.ProLastDate).TotalDays >=365 || (ProHelpBus.ProFuel - i < 0))
            {
                return false;
            }
            //if (ProHelpBus.ProStat != Status.readyForTravel)
                //return false;
            else
                return true;
        }



        private void tbdistance_KeyDown(object sender, KeyEventArgs e)//the event that cause the process of travelling is pressing enter
        {


            if (e.Key == Key.Enter)
            {
                //updating the relevat field that the bus is in  a ride
                double d = double.Parse(tbdistance.Text);
                bool b = Check(d);
                if (b)
                {
                    ProHelpBus.ProKilometrath += d;
                    ProHelpBus.ProKilometrathAfterTipul += d;
                    ProHelpBus.ProFuel -= d;
                    ProHelpBus.ProStat = Status.duringTravel;//now the process begin
                    this.Close();
                    wentTravel.RunWorkerAsync(d);


                }
                else
                {
                    MessageBox.Show("The bus cannot take the drive");
                    this.Close();
                }

            }
        }



        /* private void tbdistance_KeyDown(object sender, KeyEventArgs e)
{

    bool b = Check();
    if (b)
    {
        if (e.Key == Key.Enter)
        {
            //updating the relevat field that the bus is in  a ride
            double d = double.Parse(tbdistance.Text);
            ProHelpBus.ProKilometrath += d;
            ProHelpBus.ProKilometrathAfterTipul += d;
            ProHelpBus.ProFuel -= d;
            ProHelpBus.ProStat = Status.duringTravel;
            this.Close();

        }
    }
    else
        MessageBox.Show("The bus cannot take the drive");

}*/


    }
}