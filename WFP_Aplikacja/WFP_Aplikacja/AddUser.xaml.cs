using Microsoft.Win32;
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
using System.Drawing;
using System.Windows.Shapes;
using WFP_Aplikacja.Controler;
using WFP_Aplikacja.Models;
using System.Windows.Media.Imaging;
using WFP_Aplikacja.Helpers;

namespace WFP_Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();
        }





        public async void Add_new_User(object sender, RoutedEventArgs e)
        {

            if (Check_validation() is false) return;
           
             
              if(await  DB_controler.Add_user_task(Prepear_user_data()))
                {
                    MessageBox.Show("Dodano nowego uzytownika");
                }
              else
                {
                    MessageBox.Show("Nie udało dodać się użytkownika");
                }

          
          
        }
         
        public User Prepear_user_data()
        {
           

            User new_user = new User() { Login = this.box_login.Text, Password = this.box_password.Password, User_data = new User_data() };
            User_data data = new_user.User_data;

            data.Name = U_name.Text;
            data.LastName = U_lastname.Text;
            data.Street = U_street.Text;
            data.Emile = U_emile.Text;
            data.Pesel = U_pesel.Text;
            data.Phone = U_Phone.Text;
            data.Birthday =(DateTime)U_birthday.SelectedDate;
            data.Premission = (E_Person_type)U_premisson.SelectedIndex;
            data.Photo = ImageHelper.ImageToByte(U_image.Source as BitmapImage);
            return new_user;

        }
     public void Open_file(object sender, RoutedEventArgs e)
        {
            U_image.Source = ImageHelper.Open_Image();
        }

        public bool Check_validation()
        {
            if(this.box_login.Text != String.Empty && this.box_password.Password != String.Empty)
            {
                return true;
            }
            return false;
        }

    }
}
