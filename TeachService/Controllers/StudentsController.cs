// Controllers/StudentsController.cs
namespace TeachService.Controllers;

/// <summary>
/// StudentsController handles the API requests related to students.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly TeachPortalContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<StudentsController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentsController"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="mapper">The object mapper.</param>
    /// <param name="logger">The logger</param>
    public StudentsController(TeachPortalContext context, IMapper mapper, ILogger<StudentsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new student.
    /// </summary>
    /// <param name="studentViewModel">The student view model.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentRequest studentViewModel)
    {
        try
        {
            var username = User.Identity?.Name;
            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Username == username);

            if (teacher == null)
            {
                _logger.LogWarning("Unauthorized attempt to create a student for the user {UserName}", username);
                return Unauthorized();
            }

            var student = _mapper.Map<Student>(studentViewModel);
            student.Teacher = teacher;
            student.TeacherId = teacher.Id;

            _context.Students.Add(student);
            int result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return BadRequest("Failed to create student.");
            }

            return Ok(_mapper.Map<StudentResponse>(student));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a student.");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Gets the list of students for the authenticated teacher.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of students.</returns>
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        try
        {
            var username = User.Identity?.Name;
            var teacher = await _context.Teachers.Include(t => t.Students)
                                                 .SingleOrDefaultAsync(t => t.Username == username);

            if (teacher == null)
            {
                _logger.LogWarning("Unauthorized attempt to access students for the user {UserName}", username);
                return Unauthorized();
            }

            var studentResponses = _mapper.Map<IEnumerable<StudentResponse>>(teacher.Students);

            return Ok(studentResponses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving students for the user {UserName}", User.Identity?.Name);
            return StatusCode(500, "Internal server error");
        }
    }
}
