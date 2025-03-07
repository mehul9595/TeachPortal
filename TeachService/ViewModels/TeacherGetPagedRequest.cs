namespace TeachService.ViewModels;

public class TeacherGetPagedRequest
{
    public PageOptions PageOptions { get; set; } = new(1, 10);
}

public record PageOptions(int PageNumber, int PageSize);
