namespace TeachService.ViewModels;

/// <summary>
/// Represents a request to get a paged list of teachers.
/// </summary>
public class TeacherGetPagedRequest
{
    /// <summary>
    /// Gets or sets the page options for the request.
    /// </summary>
    public PageOptions PageOptions { get; set; } = new(1, 10);
}

/// <summary>
/// Represents pagination options.
/// </summary>
/// <param name="PageNumber">The number of the page to retrieve.</param>
/// <param name="PageSize">The number of items per page.</param>
public record PageOptions(int PageNumber, int PageSize);
