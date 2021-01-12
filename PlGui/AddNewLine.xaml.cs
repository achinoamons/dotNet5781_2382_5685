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
            }
            

            l.area = (BO.Areas)cbLineArea.SelectedItem;


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
    }
}
