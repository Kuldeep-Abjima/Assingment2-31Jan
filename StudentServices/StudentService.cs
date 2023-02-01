using Student.Model;
using Student.serviceInterFace;
using StudentServices.Infrastructure.Handlers.Interface;

namespace StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentHandler _studentHandler;

        public StudentService(IStudentHandler studentHandler)
        {
            _studentHandler = studentHandler;
        }

        public async Task<bool> AddStudentAsync(StudentModel studentModel)
        {
            var result = await _studentHandler.HandleStudentAddAsync(studentModel);
            return result;
        }

        public async Task<bool> DeletStudentAsync(int id)
        {
            return await _studentHandler.HandleStudentDeleteAsync(id);
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
            return await _studentHandler.HandleStudentGetAll();
        }

        public async Task<StudentModel> GetStudentByID(int id)
        {
            return await _studentHandler.HandleStudentGetById(id);
        }

        public async Task<bool> Update(int id, StudentModel studentModel)
        {
            return await _studentHandler.HandleStudentUpdateAsync(id, studentModel);
        }
    }
}