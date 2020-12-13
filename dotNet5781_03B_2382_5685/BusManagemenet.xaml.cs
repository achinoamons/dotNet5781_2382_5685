using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for BusManagemenet.xaml
    /// </summary>
    public partial class BusManagemenet : Window
    {
        BackgroundWorker editBus;
       public Bus current;


        public BusManagemenet(Bus b)
        {
            current = b;
            InitializeComponent();
            oneBus.DataContext = current;
            editBus = new BackgroundWorker();
            editBus.DoWork += EditBus_DoWork;
            editBus.RunWorkerCompleted += EditBus_RunWorkerCompleted;
            editBus.ProgressChanged += EditBus_ProgressChanged;
            editBus.WorkerReportsProgress = true;
        }

        private void EditBus_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = e.ProgressPercentage;
            current.MyPropertyTime = i;
        }

        private void EditBus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           current.ProStat = Status.readyForTravel;
            MessageBox.Show("the bus" + current.PNumBus + " finish treatment");
            current.MyPropertyTime = 0;
        }

        private void EditBus_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            for (int i = 0; i < 144; i++)
            {
                Thread.Sleep(100);//תישן מאית שניה
                int f = (int)(i * 100 / (144));//percent
                editBus.ReportProgress(f, e.Argument);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//refuel
        {
            this.Close();
            current.Refull();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//treatment
        {
           if(current.ProFuel==1200)//in case that it need only treatment
            {
                //check if its need treatment
                if (((current.ProKilometrathAfterTipul) >= 20000 || (DateTime.Now - current.ProLastDate).TotalDays >= 365))
                {
                    current.ProKilometrathAfterTipul = 0;
                    current.ProLastDate = DateTime.Now;//update the last date of treatment for today
                    current.ProStat = Status.InTreatment;
                    this.Close();
                    //פה מתחיל התהליכון
                    editBus.RunWorkerAsync(current);
                }
                else
                    MessageBox.Show("The bus" + current.PNumBus+" does not need treatment or refueling");
            }
           else//if its need treatment and refuel
            {//check if its need treatment
                if (((current.ProKilometrathAfterTipul) >= 20000 || (DateTime.Now - current.ProLastDate).TotalDays >= 365))
                {
                    current.ProKilometrathAfterTipul = 0;
                    current.ProLastDate = DateTime.Now;//update the last date of treatment for today
                    current.ProStat = Status.InTreatment;
                    this.Close();
                    editBus.RunWorkerAsync(current);
                    current.Refull();
                }
                else
                {
                    MessageBox.Show("The bus" + current.PNumBus + " does not need treatment only refueling");
                    this.Close();
                    current.Refull();
                }
                
                   
                
               
                
               
            }

        }
    }
}
