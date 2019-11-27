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

namespace WFP_Aplikacja.Windows.School_classes
{
    /// <summary>
    /// Logika interakcji dla klasy Add_class_frame.xaml
    /// </summary>
    public partial class Add_class_frame : Page ,I_DataForm
    {
        public Add_class_frame()
        {
            InitializeComponent();
            Load_teachers();
            Load_classNames();
            Load_students_list();
            Load_subject_list();

            U_subjects.Visibility = Visibility.Hidden;
            U_students.Visibility = Visibility.Hidden;
        }
      



        #region Fill_combobox
        public void Load_teachers()
        {
            var teachers = DB_controler.Get_users_task().Where(u => u.User_data.Premission == E_Person_type.teacher).ToList();

            U_teachers.ItemsSource = teachers;
            U_teachers.DisplayMemberPath = "User_data.Name";
            U_teachers.SelectedValuePath = "ID";
        }
        public void Load_classNames()
        {
            var names = new List<String> { "1A", "1B", "2A", "2B", "3A", "3B" };

            U_names.ItemsSource = names;
        }
        #endregion

        #region Subjects list

        public List<Subject> All_subjects = new List<Subject>();
        public List<Subject> Added_subjects = new List<Subject>();

        public void Open_Subjects_list(object sender, RoutedEventArgs e)
        {
            U_students.Visibility = Visibility.Hidden;
            U_subjects.Visibility = Visibility.Visible;

            Refresh_subject_lists();
        }

        public void Load_subject_list()
        {
            All_subjects = new DB_Subject_Controler().Get();
            Refresh_subject_lists();

        }
        public void Refresh_subject_lists()
        {
            U_all_subjects.ItemsSource = null;
            U_added_subcjets.ItemsSource = null;
            
            U_all_subjects.ItemsSource = All_subjects;
            U_added_subcjets.ItemsSource = Added_subjects;
        }

        public void Add_subject_to_class(object sender, RoutedEventArgs e)
        {
           Subject subject = U_all_subjects.SelectedItem as Subject;

            Added_subjects.Add(subject);
            All_subjects.Remove(subject);

            Refresh_subject_lists();
        }
        public void Remove_subject_from_class(object sender, RoutedEventArgs e)
        {
            Subject subject = U_added_subcjets.SelectedItem as Subject;

            All_subjects.Add(subject);
            Added_subjects.Remove(subject);
            Refresh_subject_lists();
        }
        #endregion

        #region Students list

        public void Open_students_list(object sender, RoutedEventArgs e)
        {
            U_students.Visibility = Visibility.Visible;
            U_subjects.Visibility = Visibility.Hidden;

            Refresh_lists();
        }

        public List<User> All_studnets = new List<User>();
        public List<User> Added_students = new List<User>();

        public void Load_students_list()
        {
            All_studnets = DB_controler.Get_users_task().Where(u => u.User_data.Premission == E_Person_type.student).ToList();
            Refresh_lists();

        }
        public void Refresh_lists()
        {
            U_all_students.ItemsSource = null;
            U_added_students.ItemsSource = null;

            U_all_students.ItemsSource = All_studnets;
            U_added_students.ItemsSource = Added_students;
        }

        public void Add_to_class(object sender, RoutedEventArgs e)
        {
            User user = U_all_students.SelectedItem as User;
          
             Added_students.Add(user);
             All_studnets.Remove(user);
         
            Refresh_lists();
        }
        public void Remove_from_class(object sender, RoutedEventArgs e)
        {
            User user = U_added_students.SelectedItem as User;
          
           All_studnets.Add(user);
           Added_students.Remove(user);
            Refresh_lists();
        }
        #endregion

        #region Send Form
        public bool CheckValidation()
        {
          if(U_teachers.SelectedItem == null || U_names.SelectedItem == null || Added_students.Count ==0 || Added_subjects.Count==0)
            {
                return false;
            }
            return true;
        }

        public void Add_record(object sender, RoutedEventArgs e)
        {
            if(CheckValidation())
            {
                var house_master_id = (int)U_teachers.SelectedValue;
                var name = (string)U_names.SelectedValue;
                var new_class = new SchoolClass() { Name=name, HouseMasterId = house_master_id, Students = Added_students, Subjects = Added_subjects };
                new DB_SchoolClass_controler().Insert(new_class);
            }
          
        }
        #endregion


    }

}

