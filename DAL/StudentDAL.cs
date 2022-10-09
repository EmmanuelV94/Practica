using DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class StudentDAL : DatabaseManager
    {
        public StudentDAL() : base()
        {
        }

        public List<Student> GetAll()
        {
            return dbContext.Students.ToList();
        }

        public List<Student> GetWithNoCourse()
        {
            return dbContext.Students.Where(x=> x.Assignments.Count == 0).ToList();
        }

        public List<Student> GetWithAtLeastOneCourse()
        {
            return dbContext.Students.Where(x => x.Assignments.Count > 0).ToList();
        }

        public Student Get(int carnet)
        {
            return dbContext.Students.Find(carnet);
        }

        public bool IsRepeated(Response response, Student model)
        {
            if (dbContext.Students.Where(x => x.Carnet == model.Carnet).ToList().Count > 0)
            {
                response.Success = false;
                response.Message = "Ya existe un estudiante con ese carnet";
            }
            return !response.Success;

        }

        public Response Delete(object carnet)
        {
            Response response = new Response();
            try
            {
                var studentToRemove = dbContext.Students.Find(carnet);
                if (studentToRemove == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error el estudiante que se desea eliminar ya no existe";
                }

                if (response.Success)
                {
                    dbContext.Students.Remove(studentToRemove);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Estudiante eliminado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response New(Student model)
        {
            Response response = new Response();
            try
            {
                if (!IsRepeated(response, model))
                {
                    dbContext.Students.Add(model);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Estudiante creado con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response Update(Student model)
        {
            var response = new Response();
            try
            {
                var studenToUpdate = dbContext.Students.Find(model.Carnet);
                if (studenToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error el estudiante que se desea actualizar ya no existe";
                }

                if (response.Success)
                {
                    studenToUpdate.FirstName = model.FirstName;
                    studenToUpdate.SecondName = model.SecondName;
                    studenToUpdate.LastName = model.LastName;
                    studenToUpdate.SecondLastName = model.SecondLastName;
                    studenToUpdate.DateBirth = model.DateBirth;
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "El estudiante ha sido modificado con éxito";
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