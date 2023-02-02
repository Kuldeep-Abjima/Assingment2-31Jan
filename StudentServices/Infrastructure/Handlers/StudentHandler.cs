using Microsoft.Extensions.Logging;
using Student.DataInterface;
using Student.Model;
using StudentServices.Infrastructure.Builder.Interface;
using StudentServices.Infrastructure.Handlers.Interface;

namespace StudentServices.Infrastructure.Handlers
{
    public class StudentHandler : IStudentHandler
    {
        private readonly IStudentBuilder _studentBuilder;
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentHandler> _logger;

        public StudentHandler(IStudentBuilder studentBuilder, IStudentRepository studentRepository,ILogger<StudentHandler> logger) 
        
        {
            _studentBuilder = studentBuilder;
            _studentRepository = studentRepository;
            _logger = logger;
        }
        public async Task<bool> HandleStudentAddAsync(StudentModel studentModel)
        {
            var dto = _studentBuilder.Build(studentModel);
            return await _studentRepository.AddStudentAsync(dto);

        }

        public Task<bool> HandleStudentDeleteAsync(int id)
        {
            var result = _studentRepository.DeleteStudent(id);
            return result;
        }

        public async Task<List<StudentModel>> HandleStudentGetAll()
        {
            var result = await _studentRepository.GetAll();
            
            return result.Select(x => _studentBuilder.Build(x)).ToList();


        }

        public async Task<StudentModel> HandleStudentGetById(int id)
        {
            var result = await _studentRepository.GetStudentByID(id);
            return _studentBuilder.Build(result);
        }

        public async Task<bool> HandleStudentUpdateAsync(int id, StudentModel studentModel)
        {

            var dto = _studentBuilder.Build(studentModel);
            var st = await _studentRepository.GetStudentByID(id);
            if (st != null)
            {
                    return await _studentRepository.UpdateStudent(st.Id, dto);
            }
            else
            {
                _logger.LogError("Student data not found");
                return false;
            }
        }
    }
}
