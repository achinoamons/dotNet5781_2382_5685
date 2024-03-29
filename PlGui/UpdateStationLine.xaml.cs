﻿using BLAPI;
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
            txtDistance.Text = Convert.ToString(S.Distance);
            txtTimeHour.Text = Convert.ToString(S.Time.Hours);
            txtTimeMiniute.Text = Convert.ToString(S.Time.Minutes);
            txtTimeSecond.Text = Convert.ToString(S.Time.Seconds);


        }

        private void btnUpdateLineStation_Click(object sender, RoutedEventArgs e)
        {


           // BO.LineStation sl = new BO.LineStation();
           
            stl.stationName = txtStationName.Text;
            stl.Time = new TimeSpan(Convert.ToInt32(txtTimeHour.Text), Convert.ToInt32(txtTimeMiniute.Text), Convert.ToInt32(txtTimeSecond.Text));
            stl.Distance = Convert.ToDouble(txtDistance.Text);
            //sl.Station1Code = stl.Station1Code;
            //sl.Station2Code = stl.Station2Code;
            //stl.CodeLine = stl.CodeLine;
      
            try { bl.UpdateLineStation(stl); MessageBox.Show("התחנה עודכנה בהצלחה"); }
            
             catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }
        
            if (wind == 1)
            {
                this.Close();
            }
            if (wind == 2)
            {
                this.Close();
               
            }
        }
    }
}
