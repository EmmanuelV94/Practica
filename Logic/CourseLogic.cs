using DAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.Report;
using System.Runtime.Remoting.Contexts;

namespace Logic
{
    public class CourseLogic
    {
        private readonly CourseDAL courseDAL;
        private readonly TeacherDAL teacherDAL;
        private Response response;

        public CourseLogic()
        {
            courseDAL = new CourseDAL();
            teacherDAL = new TeacherDAL();
            response = new Response();
        }

        public List<Course> GetAll() => courseDAL.GetAll();

        public List<CourseBrief> GetBrief() => courseDAL.GetBrief();
        public List<CourseBrief> GetDetail() => courseDAL.GetDetail();

        public Course Get(string code) => courseDAL.Get(code);

        private void IsValid(string code, string name, string description, string teacherId, bool isNew = true)
        {
            response.Success = true;
            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    response.Success = false;
                    response.Message += "El código es requerido <br>";
                }
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                response.Success = false;
                response.Message += "El nombre es requerido <br>";
            }
            else
            {
                if (name.Length > 50)
                {
                    response.Success = false;
                    response.Message += "El nombre debe ser menor a 50 caracteres <br>";
                }
            }

            if (!string.IsNullOrWhiteSpace(description) && description.Length > 100)
            {
                response.Success = false;
                response.Message += "La descripción debe ser menor a 100 caracteres <br>";
            }

            if (!string.IsNullOrWhiteSpace(teacherId) && teacherId != "0" && teacherDAL.Get(Convert.ToInt32(teacherId)) == null)
            {
                response.Success = false;
                response.Message += "Ya no es posible asociar al maestro debido a que ya no existe <br>";
            }
        }

        public string Save(string code, string name, string description, string teacherId)
        {
            response.Reset();
            IsValid(code, name, description, teacherId);
            if (response.Success)
            {
                var course = new DAL.Model.Course()
                {
                    Code = code,
                    Name = name,
                    Description = description
                };
                if (teacherId == "0")
                    course.TeacherId = null;
                else
                    course.TeacherId = Convert.ToInt32(teacherId);
                response = courseDAL.New(course);
            }
            return response.Message;
        }

        public string Update(string code, string name, string description, string teacherId)
        {
            response.Reset();
            IsValid(code, name, description, teacherId, false);
            if (response.Success)
            {
                var course = new DAL.Model.Course()
                {
                    Code = code,
                    Name = name,
                    Description = description
                };
                if (teacherId == "0")
                    course.TeacherId = null;
                else
                    course.TeacherId = Convert.ToInt32(teacherId);
                response = courseDAL.Update(course);
            }
            return response.Message;
        }

        public string Delete(string code)
        {
            response.Reset();
            response = courseDAL.Delete(code);
            return response.Message;

        }
    }
}
