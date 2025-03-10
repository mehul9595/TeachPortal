// Controllers/TeachersController.cs
namespace TeachService.Controllers;

/// <summary>
/// TeachersController handles the API requests related to teachers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TeachersController : ControllerBase
{
    private readonly TeachPortalContext _context;
    private readonly ILogger<TeachersController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeachersController"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger instance.</param>
    /// <param name="mapper">The mapper instance.</param>
    public TeachersController(TeachPortalContext context, ILogger<TeachersController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets the list of all teachers.
    /// </summary>
    /// <returns>A list of <see cref="TeacherViewModel"/>.</returns>
    [HttpGet]
    public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers()
    {
        try
        {
            var teachersList = await _context.Teachers.Include(t => t.Students).ToListAsync();

            var teachers = _mapper.Map<List<TeacherViewModel>>(teachersList);

            return Ok(teachers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the list of teachers.");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Gets a paginated list of teachers.
    /// </summary>
    /// <param name="request">The pagination request.</param>
    /// <returns>A paginated list of <see cref="TeacherViewModel"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the request is null.</exception>
    [HttpPost("paged")]
    public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers(TeacherGetPagedRequest request)
    {
        if (request is null)
        {
            _logger.LogError("Pagination request is null.");
            throw new ArgumentNullException(nameof(request));
        }

        try
        {
            var pageNumber = request.PageOptions.PageNumber;
            var pageSize = request.PageOptions.PageSize;

            var query = _context.Teachers.Include(t => t.Students)
                                         .Select(t => new TeacherViewModel
                                         {
                                             Id = t.Id,
                                             Username = t.Username,
                                             FirstName = t.FirstName,
                                             LastName = t.LastName,
                                             StudentCount = t.Students.Count
                                         });

            var totalCount = await query.CountAsync();
            var teachers = await query.Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

            var pagedResult = new PagedResult<TeacherViewModel>(teachers, totalCount, pageNumber, pageSize);

            return Ok(pagedResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the paginated list of teachers.");
            return StatusCode(500, "Internal server error");
        }
    }
}