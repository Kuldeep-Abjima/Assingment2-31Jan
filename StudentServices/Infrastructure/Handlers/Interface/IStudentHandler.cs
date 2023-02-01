using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Infrastructure.Handlers.Interface
{
    public interface IStudentHandler
    {
        Task<bool> HandleStudentAddAsync(StudentModel studentModel);
        Task<bool> HandleStudentUpdateAsync(int id, StudentModel studentModel);

        Task<StudentModel> HandleStudentGetById(int id);

        Task<List<StudentModel>> HandleStudentGetAll();

        Task<bool> HandleStudentDeleteAsync(int id);

    }
}
