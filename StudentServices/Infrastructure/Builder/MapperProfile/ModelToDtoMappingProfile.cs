using AutoMapper;
using student.domain.lib;
using Student.Model;

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
