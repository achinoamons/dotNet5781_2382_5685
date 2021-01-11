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

        private void btnAddLine_Click(object sender, RoutedEventArgs e)
        {
            AddNewLine a = new AddNewLine(bl);
            a.Show();
        }
    }
}
