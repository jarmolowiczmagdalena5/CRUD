using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using CRUD.Interfaces;
using System.Collections;
using System.Linq;

namespace CRUD.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SqlConnection _sqlConnection;
        public StudentRepository()
        {
            _sqlConnection = new SqlConnection(@"Data Source=DESKTOP-CIMN7NI\SQLEXPRESS;Initial Catalog=Students;Trusted_Connection=True");
        }


        public async Task<List<Student>> GetStudents()
        {
            await _sqlConnection.OpenAsync();
            var students = await _sqlConnection.QueryAsync<Student>("SELECT * FROM Students");
            return students.ToList();
        }

        public async Task <Student?> GetStudent(int id)
        {
            _sqlConnection.Open();
            var students = await _sqlConnection.QueryAsync<Student>("SELECT * FROM Students");
            return  students.FirstOrDefault(x => x.StudentID == id);
        }

        public async Task AddStudent(Student student)
        {
            var dictionary = new Dictionary<string, object?>
            {
                 { "@Name", student.Name },
                 { "@Age", student.Age }
            };

            var parameters = new DynamicParameters(dictionary);

            await _sqlConnection.ExecuteAsync($"INSERT INTO Students (Name, Age) VALUES (@Name, @Age);", parameters);
        }
        public async Task UpdateStudent(Student student)
        {
            var dictionary = new Dictionary<string, object?>
            {
                 { "@Name", student.Name },
                 { "@Age", student.Age },
                 { "@StudentID", student.StudentID }
            };

            var parameters = new DynamicParameters(dictionary);

           await _sqlConnection.ExecuteAsync($"UPDATE Students SET Name=@Name, Age=@Age WHERE StudentID=@StudentID;", parameters);
        }
        public async Task DeleteStudent(int id)
        {
            var dictionary = new Dictionary<string, object?>
            {
                 { "@StudentID", id },
            };
            var parameters = new DynamicParameters(dictionary);

            _sqlConnection.Open();
            await _sqlConnection.ExecuteAsync($"DELETE Students WHERE StudentID=@StudentID;", parameters);
        }
    }
}
