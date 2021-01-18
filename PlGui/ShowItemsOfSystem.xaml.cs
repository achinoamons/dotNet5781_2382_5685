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
    /// Interaction logic for ShowItemsOfSystem.xaml
    /// </summary>
    public partial class ShowItemsOfSystem : Window
    {
        IBL bl;
        public ShowItemsOfSystem(IBL bbl)
        {
           
            InitializeComponent();
            bl = bbl;
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            if (rblines.IsChecked == true)
            {
                LineWindow lw = new LineWindow(bl);
                lw.Show();
            }
            //else if (rbstations.IsChecked == true)
            //{
            //}
            else if(rblinestations.IsChecked==true)//linestations
            {
                LineStations ls = new LineStations(bl);
                ls.Show();


            }
        }
    }
}
