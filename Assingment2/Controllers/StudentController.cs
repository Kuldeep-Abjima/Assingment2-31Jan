using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Model;
using StudentServices.Infrastructure.Handlers;
using StudentServices.Infrastructure.Handlers.Interface;

namespace Assingment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentHandler _studentHandler;

        public StudentController(ILogger<StudentController> logger, IStudentHandler studentHandler)
        {
            _logger = logger;
            _studentHandler = studentHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentHandler.HandleStudentGetAll();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute]int id)
        {
            var result = await _studentHandler.HandleStudentGetById(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentModel studentModel)
        {
            var result = await _studentHandler.HandleStudentAddAsync(studentModel);

            return Ok(result);
            
            //if(result == true) 
            //{
            //    return Ok("Added Successfullt");
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentHandler.HandleStudentDeleteAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute]int id, [FromBody] StudentModel studentModel)
        {
            var result = await _studentHandler.HandleStudentUpdateAsync(id, studentModel);
            //if(result == null || )
            //{
            //    await _studentHandler.HandleStudentAddAsync(studentModel);
            //    return Ok(result);
            //}
            return Ok(result);
        }

    }
}
