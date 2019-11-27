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
using WFP_Aplikacja.Models;

namespace WFP_Aplikacja.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Users_table.xaml
    /// </summary>
    public partial class Users_table : Page
    {
        
        public Users_table()
        {
            InitializeComponent();
          
            var users = DB_controler.Get_users_task();
            u_datagrid.DataContext = users;
            
        }

    public void Add_Edit_user(object sender, RoutedEventArgs e)
    {
         Main.instance.Frame_1.Content= new AddUser();
    }
    public void Open_record(object sender, RoutedEventArgs e)
    {
        User user = u_datagrid.SelectedItem as User;
        Main.show_edit_instance.Show_data(user.User_data).Show();
        //  show_Edit_User_instance.Open_new_user(user);

    }
    public void Delete_record(object sender, RoutedEventArgs e)
    {
        User user = u_datagrid.SelectedItem as User;
        DB_controler.Remove_user(user.ID);
        Refresh_list(null, null);
    }


    public void Refresh_list(object sender, RoutedEventArgs e)
    {
        var users = DB_controler.Get_users_task();
        var result = new List<User>();

        foreach (var u in users)
        {
            if ((bool)U_student.IsChecked && u.User_data.Premission == E_Person_type.student)
            {
                result.Add(u);
            }
            if ((bool)U_Teacher.IsChecked && u.User_data.Premission == E_Person_type.teacher)
            {
                result.Add(u);
            }
            if ((bool)U_Secretary.IsChecked && u.User_data.Premission == E_Person_type.secretary)
            {
                result.Add(u);
            }
            if ((bool)U_Headmaster.IsChecked && u.User_data.Premission == E_Person_type.headmaster)
            {
                result.Add(u);
            }
            if ((bool)U_Admin.IsChecked && u.User_data.Premission == E_Person_type.admin)
            {
                result.Add(u);
            }
        }
        u_datagrid.DataContext = result;
    }



        public void Delete_records(object sender, RoutedEventArgs e)
        {
            new DB_user_controler().Remove();
            DB_controler.Remove_ALL();
            var users = DB_controler.Get_users_task();
            u_datagrid.DataContext = users;
        }
        public void Insert_random_records(object sender, RoutedEventArgs e)
        {
      
            new DB_user_controler().Insert(User.Generate_Random_data(10));
            var users = DB_controler.Get_users_task();
            u_datagrid.DataContext = users;
        }

    }



}