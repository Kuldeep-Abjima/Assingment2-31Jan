using AutoMapper;
using student.domain.lib;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Infrastructure.Builder.MapperProfile
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<StudentModel, StudentDto>();
        }
    }
}
