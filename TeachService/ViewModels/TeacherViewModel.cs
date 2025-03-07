namespace TeachService.ViewModels;

/// <summary>
/// Represents a view model for a teacher.
/// </summary>
public class TeacherViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the teacher.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the teacher.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the teacher.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the first name of the teacher.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the teacher.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of students assigned to the teacher.
    /// </summary>
    public int StudentCount { get; set; }
}