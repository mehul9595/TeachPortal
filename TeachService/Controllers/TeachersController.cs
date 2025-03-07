// Controllers/TeachersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachService.Helpers;
using TeachService.Repositories;
using TeachService.ViewModels;

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
    public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers()
    {
        var teachers = await _context.Teachers.Include(t => t.Students)
                                              .Select(t => new TeacherViewModel
                                              {
                                                  Id = t.Id,
                                                  Username = t.Username,
                                                  FirstName = t.FirstName,
                                                  LastName = t.LastName,
                                                  Email = t.Email,
                                                  StudentCount = t.Students.Count
                                              })
                                              .ToListAsync();

        return Ok(teachers);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers(int pageNumber = 1, int pageSize = 10)
    {
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
}