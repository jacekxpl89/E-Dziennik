using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using WFP_Aplikacja.Controler;
using WFP_Aplikacja.Models;
using WFP_Aplikacja.Windows;
using WFP_Aplikacja.Windows.Popup_windows;

namespace WFP_Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy Main.xaml
    /// </summary>
    public partial class Main : Window
    {


        public static Main instance;


        private static Show_edit_user showinstance = null;
        public static Show_edit_user show_edit_instance
        {
            get
            {
                if (showinstance == null)
                {
                    return new Show_edit_user();
                }
                else
                {
                    return showinstance;
                }

            }
            set { }
        }


        public Main()
        {
            InitializeComponent();

            if(instance == null)
            {
                instance = this;
            }

            show_edit_instance = new Show_edit_user();



        }

        public void Window_MouseDown(object sender ,MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":

                    this.Frame_1.Content = new Users_table();
                    break;
                case "ItemCreate":

                    this.Frame_1.Content = new AddUser();
                    break;
                case "SubjectCreate":
                    this.Frame_1.Content = new subject_page();
                    break;
                case "Classes":
                    this.Frame_1.Content = new school_class_window();
                    break;
                case "test":
                    //this.Frame_1.Content = new test();
                    break;
                default:
                    break;
            }
        }



    }
}
