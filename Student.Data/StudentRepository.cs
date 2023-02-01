using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Management.SqlParser.MetadataProvider;
using student.domain.lib;
using Student.DataInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Data
{
    public class StudentRepository : BaseRepository<StudentDto>, IStudentRepository
    {
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(ILogger<StudentRepository> logger, IDataBaseFactory dataBaseFactory) 
        : base (logger,dataBaseFactory)
        {
            _logger = logger;
        }
        public async Task<bool> AddStudentAsync(StudentDto studentDto)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@StudentName", studentDto.StudentName);
            parameter.Add("@ContactNumber", studentDto.ContactNumber);
            parameter.Add("@FatherName", studentDto.FatherName);
            parameter.Add("@Class", studentDto.Class);
            var result = await Datacontext.QueryFirstOrDefaultAsync<int>($"StudentAdd", parameter, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            var result = await Datacontext.QueryFirstOrDefaultAsync<int>($"StudentDelete", param, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<List<StudentDto>> GetAll()
        {
            var res = await Datacontext.QueryAsync<StudentDto>($"select * from Student", commandType: CommandType.Text);
            return res.ToList();
        }

        public async Task<StudentDto> GetStudentByID(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            var result = await Datacontext.QueryFirstOrDefaultAsync<StudentDto>($"GetStudentById", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<bool> UpdateStudent(int id,StudentDto studentDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@Sname", studentDto.StudentName);
            parameters.Add("@ContactNumber", studentDto.ContactNumber);
            parameters.Add("@Fname", studentDto.FatherName);
            parameters.Add("@class", studentDto.Class);

            var result =  await Datacontext.QueryFirstOrDefaultAsync<int>($"StudentEdit", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
