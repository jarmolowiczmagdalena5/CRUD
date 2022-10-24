using CRUD.Core.Services;
using CRUD.Infrastructure;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoryController : ControllerBase
    {
        private readonly RepositoryService _repositoryService;

        public RepositoryController()
        {
            _repositoryService = new RepositoryService();
        }

        [HttpGet("GetStudent")]
        public List<Student> GetStudent()
        {
            return _repositoryService.GetStudents();
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
