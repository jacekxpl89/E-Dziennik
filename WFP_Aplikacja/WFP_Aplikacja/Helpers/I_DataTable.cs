using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WFP_Aplikacja.Helpers
{
  public  interface I_DataTable
    {

         void Open_record(object sender, RoutedEventArgs e);

         void Edit_record(object sender, RoutedEventArgs e);

         void Delete_record(object sender, RoutedEventArgs e);

         void Refresh_List();
      

    }
}
