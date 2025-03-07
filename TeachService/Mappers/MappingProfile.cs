namespace TeachService.Mappers;

/// <summary>
/// Defines the mapping profile for the application.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// Configures the mappings between different objects.
    /// </summary>
    public MappingProfile()
    {
        /// <summary>
        /// Maps <see cref="StudentRequest"/> to <see cref="Student"/>.
        /// </summary>
        CreateMap<StudentRequest, Student>();

        /// <summary>
        /// Maps <see cref="Student"/> to <see cref="StudentResponse"/>.
        /// </summary>
        CreateMap<Student, StudentResponse>();
    }
}