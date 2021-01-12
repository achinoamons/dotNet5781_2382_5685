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
    /// Interaction logic for UpdateStationLine.xaml
    /// </summary>
    public partial class UpdateStationLine : Window
    {
        IBL bl;
        BO.LineStation stl;
        int wind;
        public UpdateStationLine(IBL bl1, BO.LineStation S, int i)
        {
            InitializeComponent();
            bl = bl1;
            stl = S;
            wind = i;
            txtStationName.Text = S.stationName;


        }

        private void btnUpdateLineStation_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation sl = new BO.LineStation();
            sl.stationName = txtStationName.Text;
            sl.Time = new TimeSpan(Convert.ToInt32(txtTimeHour.Text), Convert.ToInt32(txtTimeMiniute.Text), Convert.ToInt32(txtTimeSecond.Text));
            sl.Distance = Convert.ToDouble(txtDistance.Text);
            sl.Station1Code = stl.Station1Code;
            sl.Station2Code = stl.Station2Code;
            sl.CodeLine = stl.CodeLine;
            sl.CodeLine = stl.CodeLine;
            try { bl.UpdateLineStation(sl); }
            
             catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }
        
           /* if (wind == 1)
            {
                SHOWALL a = new SHOWALL(bl);
                a.Show();
            }
            if (wind == 2)
            {
                this.Close();
                //UpdateLine c=new UpdateLine(bl,bl.GetLINE())
            }*/
        }
    }
}
