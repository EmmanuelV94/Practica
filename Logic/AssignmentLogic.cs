using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AssignmentLogic
    {
        private readonly AssignmentDAL assigmentDAL;
        private Response response;

        public AssignmentLogic()
        {
            assigmentDAL = new AssignmentDAL();
            response = new Response();
        }

        public List<CourseAssignment> GetAll() => assigmentDAL.GetAll();

        public CourseAssignment Get(int studentId, string courseId) => assigmentDAL.Get(studentId, courseId);

        public string Save(int studentId, string courseId)
        {
            response.Reset();
            if (response.Success)
            {
                response = assigmentDAL.New(new CourseAssignment()
                {
                    StudentId = studentId,
                    CourseId = courseId
                });
            }
            return response.Message;
        }

        public string Delete(int studentId, string courseId)
        {
            response.Reset();
            response = assigmentDAL.Delete(studentId, courseId);
            return response.Message;

        }
    }
}
