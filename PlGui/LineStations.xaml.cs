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
        public LineStations(IBL bb)
        {
            InitializeComponent();
            bl = bb;
           
            List<BO.Station> listOfStations = bl.GetAllStations().ToList();
            stationDataGrid.DataContext = listOfStations;


        }

       
    }
}
