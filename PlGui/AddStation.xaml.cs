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
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStation : Window
    {
        IBL bl;
        public BO.Station bs = new BO.Station();
        public AddStation(IBL bb)
        {
            InitializeComponent();
            bl = bb;
            cbarea.ItemsSource =Enum.GetValues(typeof (BO.Areas));
        

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //input is only numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void add_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((tbcode.Text.Length) > 5|| tbcode.Text.Length<5)
            { MessageBox.Show("הקש קוד בן 5 ספרות בלבד"); }

            else
            {
                bs.CodeStation = int.Parse(tbcode.Text);
            }
            bs.Name = tbname.Text;

            bs.area = (BO.Areas)cbarea.SelectedItem;


            try
            {
                bl.AddStation(bs);
                MessageBox.Show("התחנה נוספה בהצלחה");
                this.Close();
            }
            catch (BO.OlreadtExistExceptionBO ex)
            {
                MessageBox.Show("התחנה כבר קיימת במערכת");
            }
        }
    }
}
