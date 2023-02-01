using Dapper;
using student.domain.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
