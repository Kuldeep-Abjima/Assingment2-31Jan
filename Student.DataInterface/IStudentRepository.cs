using student.domain.lib;

namespace Student.DataInterface
{
    public interface IStudentRepository
    {
        public Task<StudentDto> GetStudentByID(int id);
        public Task<List<StudentDto>> GetAll();
        public Task<bool> AddStudentAsync(StudentDto studentDto);

        public Task<bool> UpdateStudent(int id,StudentDto studentDto);

        public Task<bool> DeleteStudent(int id);



    }
}
