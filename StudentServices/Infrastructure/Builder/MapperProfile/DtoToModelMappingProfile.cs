using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student.domain.lib;
using Student.Model;

namespace StudentServices.Infrastructure.Builder.MapperProfile
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {

            CreateMap<StudentDto, StudentModel>();
                
        }
    }
}
