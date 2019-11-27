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
using WFP_Aplikacja.Controler;
using WFP_Aplikacja.Helpers;
using WFP_Aplikacja.Models;
using WFP_Aplikacja.Windows.School_classes;

namespace WFP_Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy school_class_window.xaml
    /// </summary>
    public partial class school_class_window : Page ,I_DataTable
    {
        public school_class_window()
        {
            InitializeComponent();
            CB_Load_classes();

            U_classes.SelectionChanged += new SelectionChangedEventHandler(Show_class);
        }

        public void CB_Load_classes()
        {
                U_classes.ItemsSource = new DB_SchoolClass_controler().Get();
                U_classes.DisplayMemberPath = "Name";
                U_classes.SelectedValuePath = "ID";
        }


        public void Delete_record(object sender, RoutedEventArgs e)
        {
            
        }

        public void Edit_record(object sender, RoutedEventArgs e)
        {
           
        }

        public void Open_record(object sender, RoutedEventArgs e)
        {
           
        }

        public void Refresh_List()
        {
           
        }


        public void Add_class(object sender, RoutedEventArgs e)
        {
            U_frame.Content = new Add_class_frame();
        }
        public void Show_class(object sender, SelectionChangedEventArgs e)
        {
            U_frame.Content = new Show_class((int)U_classes.SelectedValue);
        }
    }
}
