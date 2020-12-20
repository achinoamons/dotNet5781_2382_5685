using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace dotNet5781_03B_2382_5685
{
    /// <summary>
    /// Interaction logic for AddBus.xaml
    /// add a bus to the list of buses
    /// </summary>
    public partial class AddBus : Window
    {
        public Bus b;
        public AddBus( )
        {
            InitializeComponent();
           // AddTheBus();
             

        }
        public  bool CheckInput(TextBox t,DatePicker d)
        {
            if (t.Text.Length == 7 && d.DisplayDate.Year < 2018 || t.Text.Length == 8 && d.DisplayDate.Year >= 2018)
            {
                return true;
            }
            else
                return false;
            }



        private void Window_Closed(object sender, EventArgs e)
        {
            Random r = new Random();
            b = new Bus()
            {
                ProNumBus = tbnumber.Text,
                ProStartDate = date.DisplayDate,
                ProLastDate = date.DisplayDate,
                ProFuel = r.Next(0, 1201),//// we decided that full tank of fual is 1200
                ProKilometrath = r.Next(0, 100000),//the max kilometrath that a bus can have
                ProKilometrathAfterTipul = r.Next(0, 20000),//the max kmaftertipul that a bus can have
            };
            if (CheckInput(tbnumber, date))
            {
                foreach (Bus bus in HelpBusList.L1)
                {
                    if (bus.ProNumBus == tbnumber.Text)
                    {
                        MessageBox.Show("Error!this bus already exist");
                        break;
                    }

                }
                if (b.canTravel() == true)//update status
                {
                    b.ProStat = Status.readyForTravel;//the bus can take the travel
                }
                HelpBusList.L1.Add(b);
                MessageBox.Show("The bus "+b.PNumBus+" was successfully added");
            }
            else
                MessageBox.Show("Error!one or more details were not inserted correctly");
        }
    }
}
