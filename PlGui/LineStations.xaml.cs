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
using BLAPI;
namespace PlGui
{
    /// <summary>
    /// Interaction logic for LineStations.xaml
    /// </summary>
    public partial class LineStations : Window
    {
        IBL bl;
        public BO.Station bs = new BO.Station();
        public LineStations(IBL bb)
        {
            InitializeComponent();
            bl = bb;

            //List<BO.Station> listOfStations = bl.GetAllStations().ToList();


            stationDataGrid.ItemsSource = bl.GetAllStations(); // = listOfStations;

        }


        //private void stationDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{

        //    bs = (stationDataGrid.SelectedItem as BO.Station);
        //    bs = bl.GetStation(bs.CodeStation);
        //    lineStationDataGrid.ItemsSource = bs.ListOfAdjStations;
        //    lineDataGrid.ItemsSource = bs.ListOfLinesPass;
        //    tbname.Text = bs.Name;
        //    tbcode.Text = bs.CodeStation.ToString();
        //}


        private void Button_Click(object sender, RoutedEventArgs e)//add station
        {
            AddStation add = new AddStation(bl);
            add.ShowDialog();
           
           // stationDataGrid.ItemsSource = bl.GetAllStations();
            stationDataGrid.ItemsSource = bl.GetSortStations();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//delete station
        {
            if (stationDataGrid.SelectedIndex == -1) { MessageBox.Show("יש לבחור תחנה למחיקה"); }
            else
            {
                BO.Station s = stationDataGrid.SelectedItem as BO.Station;
                IEnumerable<BO.Line> l = bl.GetAllLinesPassByStation(s.CodeStation);
                if (l.Any())
                    MessageBox.Show("לתחנה ישנם קוים שעוברים בה.אינך יכול למחוק אותה");
                else if (MessageBox.Show("האם אתה בטוח שברצונך למחוק תחנה זו?", "מחיקת תחנה", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                {

                    try { bl.DeleteStation(s.CodeStation); }
                    catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }
                    stationDataGrid.ItemsSource = bl.GetAllStations();
                    stationDataGrid.ItemsSource = bl.GetSortStations();

                }
            }
            //BO.Station s = stationDataGrid.SelectedItem as BO.Station;
            //IEnumerable<BO.Line> l = bl.GetAllLinesPassByStation(s.CodeStation);
            //if (l.Any())
            //    MessageBox.Show("לתחנה ישנם קוים שעוברים בה.אינך יכול למחוק אותה");
            //else if (MessageBox.Show("האם אתה בטוח שברצונך למחוק תחנה זו?", "מחיקת תחנה", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            //{

            //    try { bl.DeleteStation(s.CodeStation); }
            //    catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }
            //    stationDataGrid.ItemsSource = bl.GetAllStations();
            //    stationDataGrid.ItemsSource = bl.GetSortStations();

            //}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//update
        {
            if (stationDataGrid.SelectedIndex == -1) { MessageBox.Show("יש לבחור תחנה לעדכון"); }
            else
            {
                BO.Station s = stationDataGrid.SelectedItem as BO.Station;
                int i = (stationDataGrid.SelectedItem as BO.Station).CodeStation;

                s.Name = tbname.Text;

                if (MessageBox.Show("האם אתה בטוח שברצונך לעדכן תחנה זו?", "עדכון תחנה", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                {

                    try { bl.UpdateStation(s, i); }
                    catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }

                    stationDataGrid.ItemsSource = bl.GetAllStations();
                    stationDataGrid.ItemsSource = bl.GetSortStations();



                }
            }
            //BO.Station s = stationDataGrid.SelectedItem as BO.Station;
            //int i = (stationDataGrid.SelectedItem as BO.Station).CodeStation;

            //s.Name = tbname.Text;

            //if (MessageBox.Show("האם אתה בטוח שברצונך לעדכן תחנה זו?", "עדכון תחנה", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            //{

            //    try { bl.UpdateStation(s, i); }
            //    catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }

            //    stationDataGrid.ItemsSource = bl.GetAllStations();
            //    stationDataGrid.ItemsSource = bl.GetSortStations();



            //}
        }

        private void stationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                if (stationDataGrid.SelectedItem != null)
                {
                    bs = (stationDataGrid.SelectedItem as BO.Station);
                    bs = bl.GetStation(bs.CodeStation);
                    lineStationDataGrid.ItemsSource = bs.ListOfAdjStations;
                    lineDataGrid.ItemsSource = bs.ListOfLinesPass;
                    tbname.Text = bs.Name;
                     tbcode.Text = bs.CodeStation.ToString();
                }
                else { stationDataGrid.SelectedItem = default; }
            }
        }












        
        }
    }

