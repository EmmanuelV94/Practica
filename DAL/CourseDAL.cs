using DAL.Model;
using DAL.Model.Report;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class CourseDAL : DatabaseManager
    {
        public List<Course> GetAll()
        {
            return dbContext.Courses.Include("Teacher").ToList();
        }

        public Course Get(string code)
        {
            return dbContext.Courses.Find(code);
        }

        public List<CourseBrief> GetBrief()
        {
            return dbContext.Courses.Select(x => new CourseBrief
            {
                Code = x.Code,
                CourseName = x.Name,
                TeacherName = x.Teacher.FirstName + x.Teacher.SecondName + " " + x.Teacher.LastName + " " + x.Teacher.SecondLastName,
                AssignedStudents = x.Assignments.Count()
            }).ToList();
        }

        public List<CourseBrief> GetDetail()
        {
            return dbContext.Courses.Select(x => new CourseBrief
            {
                Code = x.Code,
                CourseName = x.Name,
                TeacherName = x.Teacher.FirstName + x.Teacher.SecondName + " " + x.Teacher.LastName + " " + x.Teacher.SecondLastName,
                AssignedStudents = x.Assignments.Count(),
                Students = x.Assignments.Select(y=> new CourseDetail()
                {
                    Carnet = y.Student.Carnet,
                    FullName = y.Student.FirstName + y.Student.SecondName + " " + y.Student.LastName + " " + y.Student.SecondLastName,
                }).ToList()
            }).ToList();
        }

        public bool IsRepeated(Response response, Course model)
        {
            if (dbContext.Courses.Where(x => x.Code == model.Code).ToList().Count > 0)
            {
                response.Success = false;
                response.Message = "Ya existe un curso con ese código";
            }
            return !response.Success;

        }

        public Response Delete(object carnet)
        {
            Response response = new Response();
            try
            {
                var courseToRemove = dbContext.Courses.Find(carnet);
                if (courseToRemove == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error el curso que se desea eliminar ya no existe";
                }

                if (response.Success)
                {
                    dbContext.Courses.Remove(courseToRemove);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Curso eliminado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response New(Course model)
        {
            Response response = new Response();
            try
            {
                if (!IsRepeated(response, model))
                {
                    dbContext.Courses.Add(model);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Curso creado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response Update(Course model)
        {
            var response = new Response();
            try
            {
                var courseToUpdate = dbContext.Courses.Find(model.Code);
                if (courseToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error el curso que se desea actualizar ya no existe";
                }

                if (response.Success)
                {
                    courseToUpdate.Name = model.Name;
                    courseToUpdate.Description = model.Description;
                    courseToUpdate.TeacherId = model.TeacherId;
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "El curso ha sido modificado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
