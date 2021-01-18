using BLAPI;
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

namespace PlGui
{
    /// <summary>
    /// Interaction logic for AddStationLine.xaml
    /// </summary>
    public partial class AddStationLine : Window
    {
        IBL bl;
        
        BO.Line ln;
        BO.LineStation stationline;
        bool isFirst = false;
        public AddStationLine(IBL bl1, BO.Line l, BO.LineStation stationline1, bool isf)

        {
            isFirst = isf;
            stationline = stationline1;
            bl = bl1;
            ln = l;
            InitializeComponent();
            IEnumerable<BO.Station> stationl = bl.GetAllStations();
            cmbStation.ItemsSource = stationl;
            if (isFirst == true)
            {
                txtDistance.Text = Convert.ToString(0);
                txtFinishAtHour.Text = "0";
                txtFinishAtMiniute.Text = "0";
                txtFinishAtSecond.Text = "0";

            }
        }

        private void cmbStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btnAddStationLine_Click(object sender, RoutedEventArgs e)
        {
            
            BO.LineStation sl = new BO.LineStation();
                BO.Station a = (BO.Station)cmbStation.SelectedItem;
                sl.Station1Code = a.CodeStation;
                sl.stationName = a.Name;
                if (stationline != null)
                    sl.Station2Code = stationline.Station1Code;//  כי מוסיפה לפני 
                sl.CodeLine = ln.Code;
                sl.Distance = Convert.ToDouble(txtDistance.Text);
                sl.Time = new TimeSpan(Convert.ToInt32(txtFinishAtHour.Text), Convert.ToInt32(txtFinishAtMiniute.Text), Convert.ToInt32(txtFinishAtSecond.Text));
               // bl.AddLineStation(sl);
               
                
                try
                {


                
                bl.AddLineStation(sl);
                MessageBox.Show("התחנה נוספה בהצלחה");
                /////////////////////////////////////////////////////הערה:לדבר על זה עם אפרת
                //BO.LineStation help = ln.ListOfStationsPass.FirstOrDefault(x => x.Station2Code == stationline.Station1Code && x.Station1Code != sl.Station1Code);
                //help.Station2Code = sl.Station1Code;
                //ln.ListOfStationsPass.ToList().Add(help);

                //////////////////////////////////////////


                this.Close();
                }
                catch (BO.OlreadtExistExceptionBO ex)
                {
                    MessageBox.Show("התחנה כבר קיימת בקו");
                }
            this.Close();


           
        }
    }
}
