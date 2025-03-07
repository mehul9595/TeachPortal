using AutoMapper;
using TeachService.Models;
using TeachService.ViewModels;

namespace TeachService.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<StudentRequest, Student>();
        CreateMap<Student, StudentResponse>();
    }
}