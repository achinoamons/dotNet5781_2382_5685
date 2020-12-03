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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_02_2382_5685;

namespace dotNet5781_03A_2382_5685
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // static Random r = new Random(DateTime.Now.Millisecond);
        BusLines busLines = new BusLines();
        private BusLine currentDisplayBusLine;

       
        public MainWindow()


        {
            List<BusLineStation> physical = new List<BusLineStation>();
            
            for (int i = 0; i < 40; i++)
            {

                BusLineStation bb = new BusLineStation();
                physical.Add(bb);//initialiation of 40 physical busstations
            }  
            Random r = new Random();
            for (int i = 1; i < 11; i++)//initialitation of 10 lines
                {
                    
                    
                    int n = r.Next(1, 1000);
                    BusLine bb = new BusLine(n, 0);//randomaly give number for the line
                    busLines.AddLine(bb, 0);//we decided to initiate the lines only for one way-in the program we will add 2 ways line

                    for (int j = 0; j < i * 4; j++)
                    {

                        //We approached through the property and added stations to each line
                        busLines[n][0].ProStations.Add(physical[j]);
                    }
                }
            
         
            InitializeComponent();
            cbBusLines.ItemsSource = busLines;
            cbBusLines.DisplayMemberPath = "ProNumLine";
            cbBusLines.SelectedIndex = 0;
            
        }
        private void ShowBusLine(int index)
        {
            currentDisplayBusLine = busLines[index].First();
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.ProStations;
           
            tbArea.Text = currentDisplayBusLine.ProArea;

        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).ProNumLine);
        }
    }
}
