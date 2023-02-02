using Student.Model;

namespace Student.serviceInterFace
{
    public interface IStudentService
    {
        public Task<StudentModel> GetStudentByID(int id);

        public Task<List<StudentModel>> GetAllStudents();

        public Task<bool> AddStudentAsync(StudentModel studentModel);


        public Task<bool> Update(int id, StudentModel studentModel);

        public Task<bool> DeletStudentAsync(int id);



    }
}