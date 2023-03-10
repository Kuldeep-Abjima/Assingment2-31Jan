using Assingment2.Response;
using Microsoft.AspNetCore.Mvc;
using Student.Model;
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
        [HttpPost]
        [Route("[Controller]Add")]
        public async Task<ResponseWrapper<bool>> Add(StudentModel studentModel)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                var result = await _studentHandler.HandleStudentAddAsync(studentModel);
                response.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Student/CreateStudent");
                response.Set(ex);
            }
            return response;

        }

        [HttpGet]
        [Route("[Controller]GetAll")]
        public async Task<ResponseWrapper<List<StudentModel>>> GetAll()
        {
            var respo = new ResponseWrapper<List<StudentModel>>();
            try
            {
                var result = await _studentHandler.HandleStudentGetAll();
                respo.Set(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Student/GetAll");
                respo.Set(ex);
            }
            return respo;
            
        }

        [HttpGet]
        [Route("[Controller]GetById/{id}")]
        public async Task<ResponseWrapper<StudentModel>> GetByID(int id)
        {
            var response = new ResponseWrapper<StudentModel>();
            try
            {
                var result = await _studentHandler.HandleStudentGetById(id);
                response.Set(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Student/GetById:data .{id}");
                response.Set(ex);
            }
            return response;


        }

        [HttpPut]
        [Route("[Controller]Update/{id}")]
        public async Task<ResponseWrapper<bool>> Update(int id, StudentModel studentModel)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                var result = await _studentHandler.HandleStudentUpdateAsync(id, studentModel);
                response.Set(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Student/updateStudent");
                response.Set(ex);
            }
          
            return response;
        }
        [HttpDelete]
        [Route("[Controller]Delete")]
        public async Task<ResponseWrapper<bool>> Delete(int id)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                var result = await _studentHandler.HandleStudentDeleteAsync(id);
                response.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "student/deleteStudent");
                response.Set(ex);
            }
            return response;
        }

    }
}
