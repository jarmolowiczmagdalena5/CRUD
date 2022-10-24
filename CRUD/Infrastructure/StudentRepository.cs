using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CRUD.Infrastructure
{


    public class StudentRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly List<Student> _students;
        public StudentRepository()
        {
            _sqlConnection = new SqlConnection(@"Data Source=DESKTOP-CIMN7NI\SQLEXPRESS;Initial Catalog=Students;Trusted_Connection=True");
            _students = new List<Student>();
        }


        public List<Student> GetStudents()
        {
            string sql = "SELECT * FROM Students";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

            _sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                _students.Add(new Student()
                {
                    Id = (int)dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString(),
                    Age = (int)dataReader.GetValue(2)
                });
            }
            _sqlConnection.Close();
            return _students;
        }
        public void AddStudent(Student student)
        {
            string sql = $"INSERT INTO Students (Name, Age) VALUES ('@Name', @Age);";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Age", student.Age);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        public void UpdateStudent(Student student)
        {
            string sql = $"UPDATE Students SET Name=@Name, Age=@Age WHERE StudentID=@Id;";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Age", student.Age);
            sqlCommand.Parameters.AddWithValue("@Id", student.Id);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        public void DeleteStudent(int id)
        {
            string sql = $"DELETE Students WHERE StudentID=@Id;";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
