using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WFP_Aplikacja.Helpers
{
  public  interface I_DataForm
    {

        bool CheckValidation();
        void Add_record(object sender, RoutedEventArgs e);

    }
}
