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
    /// Interaction logic for LineWindow.xaml
    /// </summary>
    public partial class LineWindow : Window

    {
        IBL bl;
        public BO.Station bs = new BO.Station();
        public LineWindow(IBL bb)
        {
            InitializeComponent();

            bl = bb;
            lst.DataContext = bl.GetAllLines();
        }

        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (lst.SelectedItem != null)
            {
                BO.Line l = bl.GetLine((lst.SelectedItem as BO.Line).Code, (lst.SelectedItem as BO.Line).area);
                DatatGridLines.DataContext = l.ListOfStationsPass.ToList();
                DataContext = l.ListOfStationsPass.ToList();
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

        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)//לא עשוי----חלון עדכון קו----לא גמור בכלל
        {
            UpdateLine update = new UpdateLine(bl, (lst.SelectedItem) as BO.Line);
            update.Show();
        }

        private void btnUpdateStationLine_Click(object sender, RoutedEventArgs e)//update line stationכנל----לא גמור
        {
            // UpdateStationLine a = new UpdateStationLine(bl);
            BO.LineStation z = (BO.LineStation)DatatGridLines.SelectedItem;
            UpdateStationLine a = new UpdateStationLine(bl, z, 1);
            a.ShowDialog();
            DatatGridLines.DataContext = (lst.SelectedItem as BO.Line).ListOfStationsPass.ToList();


        }

        private void btnDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            BO.Line dl1 = (lst.SelectedItem) as BO.Line;
            if (MessageBox.Show("?אתה בטוח שהינך רוצה למחוק קו זה", " מחיקת קו", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                try { bl.DeleteLine(dl1.Code, dl1.area); }
                catch { MessageBox.Show("שגיאה: קו זה לא נמצא במערכת "); }
                lst.DataContext = bl.GetAllLines();
            }
        }
    }
}
