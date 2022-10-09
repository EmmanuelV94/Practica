using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Course
    {
        [Required, StringLength(30), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        public int? TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        public List<CourseAssignment> Assignments { get; set; }
    }
}
