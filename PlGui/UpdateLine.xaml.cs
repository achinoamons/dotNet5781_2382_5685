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
    /// Interaction logic for UpdateLine.xaml
    /// </summary>
    public partial class UpdateLine : Window
    {
        IBL bl;
        BO.Line ll;
        BO.LineStation stationlinechoosen;
        IEnumerable<BO.LineStation> FinalListStation;
        public UpdateLine(IBL bl1, BO.Line l)
        {
            InitializeComponent();
            bl = bl1;
            ll = l;
            txtLineCode.Text = Convert.ToString(ll.Code);
            txtLineCode.IsEnabled = false;

            cmbArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            cmbArea.Text = Convert.ToString(ll.area);
            ll.area = (BO.Areas)cmbArea.SelectedItem;
            DataContext = ll.ListOfStationsPass;
            FinalListStation = ll.ListOfStationsPass;

            if (l.ListOfStationsPass.ToList().Count == 0)
            {
                btnAddFirstStationLine.Visibility = Visibility.Visible;
                //btnAddFirstStationLine.IsEnabled = true;
            }
        }

        private void btnAddStationLine_Click(object sender, RoutedEventArgs e)
        {
            //AddStationLine a = new AddStationLine(bl, ll, stationlinechoosen, true);
            //a.ShowDialog();
           
            //DataContext = ll.ListOfStationsPass;
            //-------------------------------------------------------
            BO.LineStation x = (BO.LineStation)dataGridStationLINE.SelectedItem;
            stationlinechoosen = x;
            try
            {
                AddStationLine a = new AddStationLine(bl, ll, stationlinechoosen, false);
                a.ShowDialog();
            }
            catch { MessageBox.Show("לא ניתן להוסיף את התחנה מכיון שהיא כבר קיימת"); }
            dataGridStationLINE.ItemsSource = bl.GetAllLineStationsByLineCode(ll.Code);
           // dataGridStationLINE.ItemsSource = bl.GetAllLineStationsByLineCodeByOrder(ll.Code);

        }

        private void btnUpdataLine_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation x = (BO.LineStation)dataGridStationLINE.SelectedItem;
            stationlinechoosen = x;
            BO.Line upli = new BO.Line();
            upli.area = (BO.Areas)cmbArea.SelectedItem;
            upli.Code = Convert.ToInt32(txtLineCode.Text);

            ////if( isListOfLineStationIsChanged==false)
            //// upli.StationListOfLine = FinalListStation;
            upli.ListOfStationsPass = ll.ListOfStationsPass;
            bl.UpdateLine(upli);

            this.Close();
        }

        private void btnUpdateStationLine_Click(object sender, RoutedEventArgs e)
        {
            UpdateStationLine a = new UpdateStationLine(bl, (BO.LineStation)dataGridStationLINE.SelectedItem, 2);
            a.ShowDialog();
            DataContext = ll.ListOfStationsPass;
            dataGridStationLINE.ItemsSource = bl.GetAllLineStationsByLineCode(ll.Code);
            //DataContext = ln.StationListOfLine;
            //dataGridStationLINE.ItemsSource = bl.GetAllLineStationsByLineCode(ln.Code);
        }

        private void btnDeleteStationLine_Click(object sender, RoutedEventArgs e)
        {
           
            
            BO.LineStation sld = (BO.LineStation)dataGridStationLINE.SelectedItem;
            //if (dataGridStationLINE.SelectedItem == null) { MessageBox.Show("הקש את התחנה המבוקשת ואז לחץ על מחיקה"); return; }
            if (MessageBox.Show("?אתה בטוח שהינך רוצה למחוק תחנה זה", " מחיקת תחנת קו", MessageBoxButton.YesNo, MessageBoxImage.Question)
               == MessageBoxResult.Yes)
            {
                try { bl.DeleteLineStation(sld); }
                catch { MessageBox.Show("לא ניתן למחוק את התחנה, מכיון שהיא לא קיימת"); }
            }

         


           // dataGridStationLINE.ItemsSource = ll.ListOfStationsPass.ToList();
            dataGridStationLINE.ItemsSource = bl.GetAllLineStationsByLineCode(ll.Code);///הקופי פרופרטיזז מחזיר את הרשימה ריקה!!!
           


        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    BO.LineStation x = (BO.LineStation)dataGridStationLINE.SelectedItem;
        //    stationlinechoosen = x;
        //    try
        //    {
        //        AddStationLine a = new AddStationLine(bl, ll, stationlinechoosen, false);
        //        a.ShowDialog();
        //    }
        //    catch { MessageBox.Show("לא ניתן להוסיף את התחנה מכיון שהיא כבר קיימת"); }
        //    dataGridStationLINE.ItemsSource = bl.GetAllLineStationsByLineCode(ll.Code);
        //}
    }
}
