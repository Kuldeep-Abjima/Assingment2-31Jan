using Student.DataInterface;
using Student.Model;
using StudentServices.Infrastructure.Builder.Interface;
using StudentServices.Infrastructure.Handlers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Infrastructure.Handlers
{
    public class StudentHandler : IStudentHandler
    {
        private readonly IStudentBuilder _studentBuilder;
        private readonly IStudentRepository _studentRepository;

        public StudentHandler(IStudentBuilder studentBuilder, IStudentRepository studentRepository) 
        
        {
            _studentBuilder = studentBuilder;
            _studentRepository = studentRepository;
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
            return await _studentRepository.UpdateStudent(id,dto);
        }
    }
}
