using student.domain.lib;
using Student.Model;

namespace StudentServices.Infrastructure.Builder.Interface
{
    public interface IStudentBuilder
    {
        StudentModel Build(StudentDto studentdto);

        StudentDto Build(StudentModel studentModel);
    }
}
