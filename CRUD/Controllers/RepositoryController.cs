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
        public async Task<List<Student>> GetStudents()
        {
            return await _repositoryService.GetStudents();
        }

        [HttpGet("GetStudent")]
        public async Task<Student?> GetStudent(int id)
        {
            return await _repositoryService.GetStudent(id);
        }

        [HttpPost("AddStudent")]
        public async Task AddStudent([FromBody] Student student)
        {
            await _repositoryService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public async Task UpdateStudent([FromBody] Student student)
        {
            await _repositoryService.UpdateStudent(student);
        }
        [HttpDelete("DeleteStudent")]
        public async Task DeleteStudent(int id)
        {
            await _repositoryService.DeleteStudent(id);
        }
    }
}
