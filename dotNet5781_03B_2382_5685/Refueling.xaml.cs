using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Refueling.xaml
    /// </summary>
    public partial class Refueling : Window

    {
        private Bus helpbus;
        public Bus ProHelpBus
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
        BackgroundWorker inrefull;
        public Refueling(Bus current)
        {
            ProHelpBus = current;
            InitializeComponent();
            inrefull.DoWork += Inrefull_DoWork;
            inrefull.RunWorkerCompleted += Inrefull_RunWorkerCompleted;
            inrefull.ProgressChanged += Inrefull_ProgressChanged;
            inrefull.WorkerReportsProgress = true;
            ProHelpBus.ProFuel += 1200;
            ProHelpBus.ProStat = Status.InFual;
            inrefull.RunWorkerAsync();//start thread
        }

        private void Inrefull_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Inrefull_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Inrefull_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
