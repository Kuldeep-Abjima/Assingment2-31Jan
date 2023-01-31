using Student.Model;

namespace Student.serviceInterFace
{
    public interface ISudentService
    {
        Task<StudentModel> GetStudentByID(int id);

        Task<IEnumerable<StudentModel>> GetAllStudents();

        Task<int> AddStudentAsync(StudentModel studentModel);


        Task Update(int id, StudentModel studentModel);

        Task DeletStudentAsync(int id);



    }
}