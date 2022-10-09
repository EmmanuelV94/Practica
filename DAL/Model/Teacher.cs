using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Teacher
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Carnet { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string SecondName { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        public string SecondLastName { get; set; }
        public DateTime DateBirth { get; set; }

        public string FullName {
            get
            {
                return string.Concat(FirstName, " ", SecondName, " ", LastName, " ", SecondLastName);
            }
            
        }

        public List<Course> Courses { get; set; }

    }
}
