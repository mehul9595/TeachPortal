using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TeachService.Models;
using TeachService.Repositories;
using TeachService.ViewModels;

namespace TeachService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TeachPortalContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(TeachPortalContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Teacher teacher)
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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Username == login.Username);
        if (teacher == null || !BCrypt.Net.BCrypt.Verify(login.Password, teacher.PasswordHash))
        {
            return Unauthorized("Invalid credentials.");
        }

        var token = GenerateJwtToken(teacher);
        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(Teacher teacher)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, teacher.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, teacher.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
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
