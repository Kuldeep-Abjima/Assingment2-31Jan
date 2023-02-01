using AutoMapper;
using student.domain.lib;
using Student.Model;
using StudentServices.Infrastructure.Builder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Infrastructure.Builder
{
    public class StudentBuilder : IStudentBuilder
    {
        private readonly IMapper _mapper;

        public StudentBuilder(IMapper mapper)
        {
           _mapper = mapper;
        }
        public StudentModel Build(StudentDto studentdto)
        {
              return _mapper.Map<StudentModel>(studentdto);
        }

        public StudentDto Build(StudentModel studentModel)
        {
                return _mapper.Map<StudentDto>(studentModel);   
        }
    }
}
