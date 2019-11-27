using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WFP_Aplikacja.Windows.Popup_windows;

namespace WFP_Aplikacja.Windows.School_classes
{
    /// <summary>
    /// Logika interakcji dla klasy Show_class.xaml
    /// </summary>
    public partial class Show_class : Page , I_DataForm
    {



        Show_edit_user show_user_instance;
        SchoolClass schoolclass;
        public Show_class(int ID)
        {


          
            InitializeComponent();

            schoolclass = new DB_SchoolClass_controler().Get(ID);
        
                Fill_page();
            Load_Marks();
            Load_Subjects();
        }




        #region Fill_combobox
        public void Load_Marks()
        {
            var marks = new List<int>() { 1, 2, 3, 4, 5, 6 };
            marks.ForEach(u =>U_Marks.Items.Add(u));
        }

        public void Load_Subjects()
        {
            var subjects = schoolclass.Subjects;

            U_subjects.ItemsSource = subjects;
            U_subjects.DisplayMemberPath = "Name";
            U_subjects.SelectedValuePath = "ID";
         
        }
        #endregion



        public void Send_message(object sender, RoutedEventArgs e)
        {
            var message_window = new Add_message(schoolclass.HouseMaster, (User)U_students.SelectedItem);
            message_window.Show();
        }

        public void Fill_page()
        {

            Refresh_List();
            U_name.Content = schoolclass.HouseMaster.User_data.Name;
            U_lastname.Content = schoolclass.HouseMaster.User_data.LastName;
           
        }


        public void Delete_record(object sender, RoutedEventArgs e)
        {
           User user = (User)U_students.SelectedItem;

            user.SchoolClass = null;
            user.SchoolClassId = null;

            schoolclass.Students.Remove(user);
            new DB_user_controler().Update(user);

            Refresh_List();

        }
        public void Open_record(object sender, RoutedEventArgs e)
        {
         //   show_user_instance.Open_new_user((User)U_students.SelectedItem);
        }
        public void Edit_record(object sender, RoutedEventArgs e)
        {

        }
        public void Refresh_List()
        {
            U_students.ItemsSource = null;
            U_students.ItemsSource = schoolclass.Students;
        }




        public bool CheckValidation()
        {
           if(U_Marks.SelectedItem == null || U_subjects.SelectedItem == null )
            {
                return false;
            }
            return true;
        }

        public void Add_record(object sender, RoutedEventArgs e)
        {
           if(CheckValidation())
            {

                int mark_ = (int)U_Marks.SelectedItem;
                string description_ = u_Description.Text;
                DateTime date = DateTime.Today;
                User student = (User)U_students.SelectedItem;
                Mark mark = new Mark() { mark = mark_, Description = description_, Date = date, StudentId = student.ID, SubjectId = 35 };

                new DB_mark_controler().Insert(mark);
            }
        }
    }
}
