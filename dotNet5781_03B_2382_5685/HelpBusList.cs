using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

/// <summary>
/// we put the list in a different class so the clasess would be able to use it
/// </summary>
namespace dotNet5781_03B_2382_5685
{
   public   class HelpBusList
    {
       public static ObservableCollection<Bus> L1 = new ObservableCollection<Bus>();
    }
}
