using CRUD.Infrastructure;
using CRUD.Interfaces;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Core.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IStudentRepository _studentRepository;

        public RepositoryService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }
        public Student? GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }
        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }
        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }
        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
