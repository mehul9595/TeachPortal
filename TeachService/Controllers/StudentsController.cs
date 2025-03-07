// Controllers/StudentsController.cs
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachService.Models;
using TeachService.Repositories;
using TeachService.ViewModels;

namespace TeachService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly TeachPortalContext _context;
    private readonly IMapper _mapper;

    public StudentsController(TeachPortalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentRequest studentViewModel)
    {
        var username = User.Identity.Name;
        var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Username == username);

        if (teacher == null)
        {
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

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var username = User.Identity.Name;
        var teacher = await _context.Teachers.Include(t => t.Students)
                                             .SingleOrDefaultAsync(t => t.Username == username);

        if (teacher == null)
        {
            return Unauthorized();
        }

        var studentResponses = _mapper.Map<IEnumerable<StudentResponse>>(teacher.Students);

        return Ok(studentResponses);
    }
}
