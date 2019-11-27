using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Windows.Popup_windows
{
    /// <summary>
    /// Logika interakcji dla klasy Show_edit_user.xaml
    /// </summary>
    public partial class Show_edit_user :Window
    {

        public Show_edit_user()
        {
            InitializeComponent();
           
        }


    
     

       


        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        public Show_edit_user Show_data(User_data data)
        {

            U_name.Content = data.Name;
            U_lastname.Content = data.LastName;
            U_street.Content = data.Street;
            U_emile.Content = data.Emile;
            U_pesel.Content = data.Pesel;
            U_birthday.Content = data.Birthday?.ToString("dd/MM/yyyy");
            U_phone.Content = data.Phone;


            //   U_photo.Source = ImageHelper.Convert_to_bitmap(data.Photo);
            return this;
           
        }
     
        private void Close_window(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }
    }
}
