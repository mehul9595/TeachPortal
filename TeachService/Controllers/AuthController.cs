namespace TeachService.Controllers;

/// <summary>
/// Controller for handling authentication-related actions.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TeachPortalContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="configuration">The configuration settings.</param>
    public AuthController(TeachPortalContext context, IConfiguration configuration, ILogger<AuthController> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    /// <summary>
    /// Registers a new teacher.
    /// </summary>
    /// <param name="teacher">The teacher to register.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the registration.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Teacher teacher)
    {
        try
        {
            if (await _context.Teachers.AnyAsync(t => t.Username == teacher.Username || t.Email == teacher.Email))
            {
                return BadRequest("Username or Email already exists.");
            }

            teacher.PasswordHash = BCrypt.Net.BCrypt.HashPassword(teacher.PasswordHash);
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok("Registration successful.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while registering a new teacher.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Logs in a teacher.
    /// </summary>
    /// <param name="login">The login model containing the username and password.</param>
    /// <returns>An <see cref="IActionResult"/> containing the JWT token if login is successful.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        try
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Username == login.Username);
            if (teacher == null || !BCrypt.Net.BCrypt.Verify(login.Password, teacher.PasswordHash))
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = GenerateJwtToken(teacher);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging in.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Generates a JWT token for the specified teacher.
    /// </summary>
    /// <param name="teacher">The teacher for whom to generate the token.</param>
    /// <returns>The generated JWT token.</returns>
    private string GenerateJwtToken(Teacher teacher)
    {
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, teacher.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, teacher.Username),
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
