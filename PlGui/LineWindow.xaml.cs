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
    /// Interaction logic for LineWindow.xaml
    /// </summary>
    public partial class LineWindow : Window

    {
        IBL bl;
        public BO.Station bs = new BO.Station();
        BO.Line line;
        public LineWindow(IBL bb)
        {
            InitializeComponent();

            bl = bb;
            DatatGridLines.IsReadOnly = true;
            lst.DataContext = bl.GetAllLines();
            /*////////////////////*/
            if (lst.SelectedItem != null)
            {
                BO.Line l = bl.GetLine((lst.SelectedItem as BO.Line).Code, (lst.SelectedItem as BO.Line).area);
                DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l.Code);
                line = l;
            }
        }

        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (lst.SelectedItem != null)
            {
                BO.Line l = bl.GetLine((lst.SelectedItem as BO.Line).Code, (lst.SelectedItem as BO.Line).area);
                DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l.Code);
                //DatatGridLines.DataContext = l.ListOfStationsPass.ToList();
                //DataContext = l.ListOfStationsPass.ToList();
            }
            else
            {
                lst.SelectedItem = default;
                //BO.LINE l=bl.GetLINE()
            }
            // DatatGridLines.ItemsSource= l.StationListOfLine;


        }

        private void btnAddLine_Click(object sender, RoutedEventArgs e)//add line
        {
           
            AddNewLine a = new AddNewLine(bl);
            a.ShowDialog();
            lst.ItemsSource = bl.GetAllLines();
        }

        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)//
        {
            //UpdateLine update = new UpdateLine(bl, (lst.SelectedItem) as BO.Line);
            //update.ShowDialog();
            //DatatGridLines.ItemsSource = (lst.SelectedItem as BO.Line).ListOfStationsPass.ToList();

            //------------------------------------------------------------//
            if (lst.SelectedItem == null) { MessageBox.Show("הקש את הקו המבוקש ואז לחץ על עדכון"); return; }

            BO.Line l2 = (lst.SelectedItem) as BO.Line;
            UpdateLine update = new UpdateLine(bl, (lst.SelectedItem) as BO.Line);
            update.ShowDialog();
            DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l2.Code);
            lst.DataContext = bl.GetAllLines();
            // BO.LINE l=bl.GetLINE(lst.SelectedItema BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
            //if (lst.SelectedIndex == -1) lst.SelectedItem = default;
            //BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
            //DatatGridLines.ItemsSource = default;
            //  DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l2.Code);
        }

        private void btnUpdateStationLine_Click(object sender, RoutedEventArgs e)//update line station
        {
            if (lst.SelectedItem == null) { MessageBox.Show("בחר את הקו אשר ברצונך לעדכן את התחנה עבורו"); return; }
           
            // UpdateStationLine a = new UpdateStationLine(bl);
           else
            { BO.LineStation z = (BO.LineStation)DatatGridLines.SelectedItem;
            UpdateStationLine a = new UpdateStationLine(bl, z, 1);
            a.ShowDialog();
            
            //DatatGridLines.ItemsSource = (lst.SelectedItem as BO.Line).ListOfStationsPass.ToList();
            DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode((lst.SelectedItem as BO.Line).Code);


            //BO.Line line1 = bl.GetLine((lst.SelectedItem as BO.Line).Code, (lst.SelectedItem as BO.Line).area);
            //DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(line1.Code);
            }


        }

        private void btnDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            if (lst.SelectedItem == null) { MessageBox.Show("הקש את הקו המבוקש ואז לחץ על מחיקה"); return; }
            BO.Line dl1 = (lst.SelectedItem) as BO.Line;
            if (MessageBox.Show("?אתה בטוח שהינך רוצה למחוק קו זה", " מחיקת קו", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                try { bl.DeleteLine(dl1.Code, dl1.area);  }
                catch { MessageBox.Show("שגיאה: קו זה לא נמצא במערכת "); }
                lst.ItemsSource = bl.GetAllLines();
                //DatatGridLines.ItemsSource = (lst.SelectedItem as BO.Line).ListOfStationsPass.ToList();

            }
        }
    }
}
