using DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class TeacherDAL : DatabaseManager
    {
        public TeacherDAL() : base()
        {
        }

        public List<Teacher> GetAll()
        {
            return dbContext.Teachers.ToList();
        }

        public Teacher Get(int carnet)
        {
            return dbContext.Teachers.Find(carnet);
        }

        public bool IsRepeated(Response response, Teacher model)
        {
            if (dbContext.Teachers.Where(x => x.Carnet == model.Carnet).ToList().Count > 0)
            {
                response.Success = false;
                response.Message = "Ya existe un maestro con ese carnet";
            }
            return !response.Success;

        }

        public Response Delete(int carnet)
        {
            Response response = new Response();
            try
            {
                var teacherToRemove = dbContext.Teachers.Find(carnet);
                if (teacherToRemove == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error el maestro que se desea eliminar ya no existe";
                }

                if (response.Success)
                {
                    var courses =  dbContext.Courses.Where(a => a.TeacherId == teacherToRemove.Carnet).ToList();
                    foreach (var course in courses)
                    {
                        course.TeacherId = null;
                    }
                    dbContext.Teachers.Remove(teacherToRemove);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Maestro eliminado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response New(Teacher model)
        {
            Response response = new Response();
            try
            {
                if (!IsRepeated(response, model))
                {
                    dbContext.Teachers.Add(model);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Maestro creado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response Update(Teacher model)
        {
            var response = new Response();
            try
            {
                var teacherToUpdate = dbContext.Teachers.Find(model.Carnet);
                if (teacherToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error el maestro que se desea actualizar ya no existe";
                }

                if (response.Success)
                {
                    teacherToUpdate.FirstName = model.FirstName;
                    teacherToUpdate.SecondName = model.SecondName;
                    teacherToUpdate.LastName = model.LastName;
                    teacherToUpdate.SecondLastName = model.SecondLastName;
                    teacherToUpdate.DateBirth = model.DateBirth;
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "El maestro ha sido modificado con éxito";
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