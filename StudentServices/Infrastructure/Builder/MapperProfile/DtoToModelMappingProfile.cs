using AutoMapper;
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
