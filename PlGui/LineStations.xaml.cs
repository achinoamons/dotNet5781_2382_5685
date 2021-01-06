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
            try
            {
                stationDataGrid.DataContext = bl.GetAllStations(); // = listOfStations;
            }
            catch (Exception e) { }
        }
       

        private void stationDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            bs = (stationDataGrid.SelectedItem as BO.Station);
            bs = bl.GetStation(bs.CodeStation);
            adjacentStationsDataGrid.ItemsSource = bs.ListOfAdjStations;
            lineDataGrid.ItemsSource = bs.ListOfLinesPass;
        }
    }
}
