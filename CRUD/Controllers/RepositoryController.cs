using CRUD.Core.Services;
using CRUD.Infrastructure;
using CRUD.Interfaces;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public RepositoryController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpGet("GetStudents")]
        public List<Student> GetStudent()
        {
            return _repositoryService.GetStudents();
        }

        [HttpGet("GetStudent")]
        public Student? GetStudent(int id)
        {
            return _repositoryService.GetStudent(id);
        }

        [HttpPost("AddStudent")]
        public void AddStudent([FromBody]Student student)
        {
            _repositoryService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public void UpdateStudent([FromBody] Student student)
        {
            _repositoryService.UpdateStudent(student);
        }
        [HttpDelete("DeleteStudent")]
        public void DeleteStudent(int id)
        {
            _repositoryService.DeleteStudent(id);
        }
    }
}
