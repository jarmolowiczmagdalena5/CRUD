using CRUD.Models;

namespace CRUD.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student? GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
