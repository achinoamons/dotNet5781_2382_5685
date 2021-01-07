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
            
            
                stationDataGrid.DataContext = bl.GetAllStations(); // = listOfStations;
            
        }
       

        private void stationDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            bs = (stationDataGrid.SelectedItem as BO.Station);
            bs = bl.GetStation(bs.CodeStation);
            adjacentStationsDataGrid.ItemsSource = bs.ListOfAdjStations;
            lineDataGrid.ItemsSource = bs.ListOfLinesPass;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // stationViewSource.Source = [generic data source]
        }
    }
}
