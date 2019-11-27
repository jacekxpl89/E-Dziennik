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

namespace WFP_Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy subject_page.xaml
    /// </summary>
    public partial class subject_page : Page, I_DataTable ,I_DataForm
    {
        public subject_page()
        {
            InitializeComponent();

            Load_teachers();
            Load_Subjects();
            Refresh_List();
        }

        #region Fill_combobox
        public void Load_teachers()
        {
           var teachers = DB_controler.Get_users_task().Where(u => u.User_data.Premission == E_Person_type.teacher).ToList();

            U_teachers.ItemsSource = teachers;
            U_teachers.DisplayMemberPath = "User_data.Name"; 
            U_teachers.SelectedValuePath = "ID";
         }
        
        public void Load_Subjects()
        {
            var subjects = new List<String>();
            subjects.Add("Math");
            subjects.Add("English");
            subjects.Add("Physic");
            subjects.Add("Biology");

             
            subjects.ForEach(u => U_subjects.Items.Add(u));
        }
        #endregion

        #region TableFunctions
        public void Open_record(object sender, RoutedEventArgs e)
        {
            Subject subject = datagrid.SelectedItem as Subject;
         
        }
        public void Delete_record(object sender, RoutedEventArgs e)
        {
            Subject subject = datagrid.SelectedItem as Subject;
            new DB_Subject_Controler().Remove(subject.ID);
            Refresh_List();
        }
        public void Edit_record(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        public void Refresh_List()
        {
            datagrid.DataContext = new DB_Subject_Controler().Get();
        }
        #endregion

        #region FormFunctions
        public bool CheckValidation()
        {
            if(U_subjects.SelectedItem == null || U_teachers.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        public void Add_record(object sender, RoutedEventArgs e)
        {

            if(CheckValidation())
            {
                int teacher_id = (int)U_teachers.SelectedValue;

                Subject new_subject = new Subject() { Name = U_subjects.Text, TeacherId = teacher_id };

                new DB_Subject_Controler().Insert(new_subject);

                Refresh_List();

            }
           else
            {
                MessageBox.Show("Error");
            }
              
           

           
        }
        #endregion
    }
}
