// Controllers/TeachersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachService.Repositories;

namespace TeachService.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TeachersController : ControllerBase
{
    private readonly TeachPortalContext _context;

    public TeachersController(TeachPortalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeachers()
    {
        var teachers = await _context.Teachers.Include(t => t.Students)
                                              .Select(t => new
                                              {
                                                  t.Id,
                                                  t.Username,
                                                  t.FirstName,
                                                  t.LastName,
                                                  StudentCount = t.Students.Count
                                              })
                                              .ToListAsync();

        return Ok(teachers);
    }
}