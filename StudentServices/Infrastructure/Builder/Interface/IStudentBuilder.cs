using student.domain.lib;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Infrastructure.Builder.Interface
{
    public interface IStudentBuilder
    {
        StudentModel Build(StudentDto studentdto);

        StudentDto Build(StudentModel studentModel);
    }
}
