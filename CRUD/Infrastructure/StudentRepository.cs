using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using CRUD.Interfaces;

namespace CRUD.Infrastructure
{


    public class StudentRepository : IStudentRepository
    {
        private readonly SqlConnection _sqlConnection;
        public StudentRepository()
        {
            _sqlConnection = new SqlConnection(@"Data Source=DESKTOP-CIMN7NI\SQLEXPRESS;Initial Catalog=Students;Trusted_Connection=True");
        }


        public List<Student> GetStudents()
        {
            _sqlConnection.Open();
            return _sqlConnection.Query<Student>("SELECT * FROM Students").ToList();
        }

        public Student? GetStudent(int id)
        {
            var students = new List<Student>();
            _sqlConnection.Open();
            students = _sqlConnection.Query<Student>("SELECT * FROM Students").ToList();
            return students.FirstOrDefault(x => x.StudentID == id);
        }

        public void AddStudent(Student student)
        {
            var dictionary = new Dictionary<string, object?>
            {
                 { "@Name", student.Name },
                 { "@Age", student.Age }
            };

            var parameters = new DynamicParameters(dictionary);

            _sqlConnection.Execute($"INSERT INTO Students (Name, Age) VALUES (@Name, @Age);", parameters);
        }
        public void UpdateStudent(Student student)
        {
            var dictionary = new Dictionary<string, object?>
            {
                 { "@Name", student.Name },
                 { "@Age", student.Age },
                 { "@StudentID", student.StudentID }
            };

            var parameters = new DynamicParameters(dictionary);

            _sqlConnection.Execute($"UPDATE Students SET Name=@Name, Age=@Age WHERE StudentID=@StudentID;", parameters);
        }
        public void DeleteStudent(int id)
        {
            var dictionary = new Dictionary<string, object?>
            {
                 { "@StudentID", id },
            };
            var parameters = new DynamicParameters(dictionary);

            _sqlConnection.Open();
            _sqlConnection.Execute($"DELETE Students WHERE StudentID=@StudentID;", parameters);
        }
    }
}
