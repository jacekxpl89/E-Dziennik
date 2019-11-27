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

namespace WFP_Aplikacja.Windows.Popup_windows
{
    /// <summary>
    /// Logika interakcji dla klasy Add_message.xaml
    /// </summary>
    public partial class Add_message : Window , I_DataForm
    {



        User user_from;
        User user_to;

        public Add_message(User user_from ,User user_to)
        {
            InitializeComponent();
            this.user_from = user_from;
            this.user_to = user_to;

            U_text_sent_to.Text = "Send Message To : " + user_to.User_data.Name + " " + user_to.User_data.LastName;
        }

        public void Add_record(object sender, RoutedEventArgs e)
        {

            if(CheckValidation())
            {
                Message message = new Message() { User_from_ID = user_from.ID, User_to_ID = user_to.ID, Title = U_title.Text, Context = U_context.Text };
                new DB_message_controler().Insert(message);
                Close_window(null, null);
            }


           
        }

        public bool CheckValidation()
        {
          if(user_from ==null || user_to==null)
            {
                return false;
            }
          if(U_title.Text.Equals(string.Empty))
            {
                return false;
            }
            return true;
        }

        private void Close_window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
