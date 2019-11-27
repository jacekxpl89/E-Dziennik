using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Models
{
    class SubjectWeek
    {
        [Key]
        public int ID;

        public  Subject subject;
        public  List<DateTime> days_in_week = new List<DateTime>();


     
    }
}
