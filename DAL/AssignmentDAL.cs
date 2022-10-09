using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AssignmentDAL: DatabaseManager
    {
        public List<CourseAssignment> GetAll()
        {
            return dbContext.Assignments.Include("Course").Include("Student").ToList();
        }

        public CourseAssignment Get(int studentId, string courseId)
        {
            return dbContext.Assignments.Find(studentId, courseId);
        }

        public bool IsRepeated(Response response, CourseAssignment model)
        {
            if (dbContext.Assignments.Where(x => x.CourseId == model.CourseId && x.StudentId == model.StudentId).ToList().Count > 0)
            {
                response.Success = false;
                response.Message = "Ya existe dicha asignación";
            }
            return !response.Success;
        }

        public Response Delete(int studentId,string courseId)
        {
            Response response = new Response();
            try
            {
                var assignmentToRemove = dbContext.Assignments.Find(studentId, courseId);
                if (assignmentToRemove == null)
                {
                    response.Success = false;
                    response.Message = "Ha ocurrido un error la asignación que se desea eliminar ya no existe";
                }

                if (response.Success)
                {
                    dbContext.Assignments.Remove(assignmentToRemove);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Asignación eliminada con éxito";
                }
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response New(CourseAssignment model)
        {
            Response response = new Response();
            try
            {
                if (!IsRepeated(response, model))
                {
                    dbContext.Assignments.Add(model);
                    dbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Asignación creada con éxito";
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
