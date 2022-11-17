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

        public async Task <List<Student>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }
        public async Task <Student?> GetStudent(int id)
        {
            return await _studentRepository.GetStudent(id);
        }
        public async Task AddStudent(Student student)
        {
            await _studentRepository.AddStudent(student);
        }
        public async Task UpdateStudent(Student student)
        {
           await _studentRepository.UpdateStudent(student);
        }
        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
        }
    }
}
