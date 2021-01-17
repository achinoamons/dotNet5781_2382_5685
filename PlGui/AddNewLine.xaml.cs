using BLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewLine : Window
    {
        IBL bl;
        public BO.Line l = new BO.Line();
        public AddNewLine(IBL bbl)
        {
            InitializeComponent();
            bl = bbl;
            cbLineArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            cbfirststation.ItemsSource = bl.GetAllStations();
            cblaststation.ItemsSource = bl.GetAllStations();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //input is only numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSaveNewLine_Click(object sender, RoutedEventArgs e)
        {
            if ((txtLineCode.Text.Length) > 4 || txtLineCode.Text.Length < 1)
            { MessageBox.Show("הקש מספר קו בין 1 ל-4 ספרות בלבד"); }

            else
            {
                l.Code = int.Parse(txtLineCode.Text);
                //////////////////////////////////////////
                l.area = (BO.Areas)cbLineArea.SelectedItem;
                List<BO.LineStation> ls = new List<BO.LineStation>();

                if ((cblaststation.SelectedItem as BO.Station).Name == (cbfirststation.SelectedItem as BO.Station).Name)
                { MessageBox.Show("יש לבחור תחנה שונה"); return; }
                //first station
                BO.LineStation a = new BO.LineStation();
                BO.Station v = cbfirststation.SelectedItem as BO.Station;
                a.CodeLine = l.Code;
                a.stationName = v.Name;
                a.Station1Code = v.CodeStation;


                //second station
                BO.LineStation nn = new BO.LineStation();
                BO.Station vv = cblaststation.SelectedItem as BO.Station;
                nn.CodeLine = l.Code;
                nn.stationName = vv.Name;
                nn.Station1Code = vv.CodeStation;

                a.Station2Code = nn.Station1Code;
                ls.Add(nn);
                ls.Add(a);
                try { bl.AddLineStation(nn); }
                catch { MessageBox.Show("כבר קיימת לקו כזו תחנה"); }
                try { bl.AddLineStation(a); }
                catch { MessageBox.Show("כבר קיימת לקו כזו תחנה"); }
                l.ListOfStationsPass = ls;


                try
                {
                    bl.AddLine(l);
                    MessageBox.Show("הקו נוסף בהצלחה");
                    this.Close();
                }
                catch (BO.OlreadtExistExceptionBO ex)
                {
                    MessageBox.Show("הקו כבר קיים במערכת");
                }
            }


            // l.area = (BO.Areas)cbLineArea.SelectedItem;
            // List<BO.LineStation> ls = new List<BO.LineStation>();

            // if ((cblaststation.SelectedItem as BO.Station).Name == (cbfirststation.SelectedItem as BO.Station).Name)
            // { MessageBox.Show("יש לבחור תחנה שונה"); return; }
            // //first station
            // BO.LineStation a = new BO.LineStation();
            // BO.Station v = cbfirststation.SelectedItem as BO.Station;
            // a.CodeLine = l.Code;
            // a.stationName = v.Name;
            // a.Station1Code = v.CodeStation;


            // //second station
            // BO.LineStation nn = new BO.LineStation();
            // BO.Station vv = cblaststation.SelectedItem as BO.Station;
            // nn.CodeLine = l.Code;
            // nn.stationName = vv.Name;
            // nn.Station1Code = vv.CodeStation;

            // a.Station2Code = nn.Station1Code;
            // ls.Add(nn);
            // ls.Add(a);
            // try { bl.AddLineStation(nn); } 
            // catch { MessageBox.Show("כבר קיימת לקו כזו תחנה"); } 
            //try { bl.AddLineStation(a);}
            // catch { MessageBox.Show("כבר קיימת לקו כזו תחנה"); } 
            // l.ListOfStationsPass = ls;


            // try
            // {
            //     bl.AddLine(l);
            //     MessageBox.Show("הקו נוסף בהצלחה");
            //     this.Close();
            // }
            // catch (BO.OlreadtExistExceptionBO ex)
            // {
            //     MessageBox.Show("הקו כבר קיים במערכת");
            // }
        }
    }
}
