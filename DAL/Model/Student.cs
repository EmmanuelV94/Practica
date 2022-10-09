using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Student
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
        [Required]
        public DateTime DateBirth { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - DateBirth.Year;
                if (DateBirth.Date > DateTime.Today.AddYears(-age))
                    age--;
                return age;
            }
        }

        public string FullName
        {
            get
            {
                return string.Concat(FirstName, " ", SecondName, " ", LastName, " ", SecondLastName);
            }

        }

        public List<CourseAssignment> Assignments { get; set; }
    }
}
