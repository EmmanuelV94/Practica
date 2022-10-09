using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class StudentLogic
    {
        private readonly StudentDAL studenDAL;
        private Response response;

        public StudentLogic()
        {
            studenDAL = new StudentDAL();
            response = new Response();
        }

        public List<Student> GetAll() => studenDAL.GetAll();

        public Student Get(int carnet) => studenDAL.Get(carnet);

        public List<Student> GetWithNoCourse() => studenDAL.GetWithNoCourse();

        public List<Student> GetWithAtLeastOneCourse() => studenDAL.GetWithAtLeastOneCourse();

        private void IsValid(string carnet, string firstName, string secondName, string lastName, string secondLastName, string dateBirth, bool isNew = true)
        {
            response.Success = true;
            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(carnet))
                {
                    response.Success = false;
                    response.Message += "El carnet es requerido <br>";
                }
                else
                {
                    if (!int.TryParse(carnet, out _))
                    {
                        response.Success = false;
                        response.Message += "El carnet debe tener formato númerico <br>";
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                response.Success = false;
                response.Message += "El primer nombre es requerido <br>";
            }
            else
            {
                if (firstName.Length > 100)
                {
                    response.Success = false;
                    response.Message += "El pimer nombre debe ser menor a 100 caracteres <br>";
                }
            }

            if (!string.IsNullOrWhiteSpace(secondName) && secondName.Length > 100)
            {
                response.Success = false;
                response.Message += "El segundo nombre debe ser menor a 100 caracteres <br>";
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                response.Success = false;
                response.Message += "El primer apellido es requerido <br>";
            }
            else
            {
                if (firstName.Length > 100)
                {
                    response.Success = false;
                    response.Message += "El pimer apellido debe ser menor a 100 caracteres <br>";
                }
            }

            if (string.IsNullOrWhiteSpace(secondLastName))
            {
                response.Success = false;
                response.Message += "El segundo apellido es requerido <br>";
            }
            else
            {
                if (firstName.Length > 100)
                {
                    response.Success = false;
                    response.Message += "El segundo apellido debe ser menor a 100 caracteres <br>";
                }
            }

            if (string.IsNullOrWhiteSpace(dateBirth))
            {
                response.Success = false;
                response.Message += "La fecha de nacimiento es requerido <br>";
            }
            else
            {
                if (!DateTime.TryParse(dateBirth, out _))
                {
                    response.Success = false;
                    response.Message += "La fecha de nacimiento no tiene el formato correcto";
                }
            }
        }

        public string Save(string carnet, string firstName, string secondName, string lastName, string secondLastName, string dateBirth)
        {
            response.Reset();
            IsValid(carnet, firstName, secondName, lastName, secondLastName, dateBirth);
            if (response.Success)
            {
                response = studenDAL.New(new DAL.Model.Student()
                {
                    Carnet = Convert.ToInt32(carnet),
                    FirstName = firstName.Trim(),
                    SecondName = secondName,
                    LastName = lastName,
                    SecondLastName = secondLastName,
                    DateBirth = Convert.ToDateTime(dateBirth)
                });
            }
            return response.Message;
        }

        public string Update(string carnet, string firstName, string secondName, string lastName, string secondLastName, string dateBirth)
        {
            response.Reset();
            IsValid(carnet, firstName, secondName, lastName, secondLastName, dateBirth, false);
            if (response.Success)
            {
                response = studenDAL.Update(new DAL.Model.Student()
                {
                    Carnet = Convert.ToInt32(carnet),
                    FirstName = firstName.Trim(),
                    SecondName = secondName,
                    LastName = lastName,
                    SecondLastName = secondLastName,
                    DateBirth = Convert.ToDateTime(dateBirth)
                });
            }
            return response.Message;
        }

        public string Delete(string carnet)
        {
            response.Reset();
            response = studenDAL.Delete(Convert.ToInt32(carnet));
            return response.Message;

        }
    }
}
