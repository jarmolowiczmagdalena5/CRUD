using CRUD.Models;

namespace CRUD.Interfaces
{
    public interface IRepositoryService
    {
        Task <List<Student>> GetStudents();
        Task <Student?> GetStudent(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
