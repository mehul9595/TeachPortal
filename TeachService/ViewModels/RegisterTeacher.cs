namespace TeachService.ViewModels;

/// <summary>
/// Represents a view model for a teacher.
/// </summary>
public class RegisterTeacher
{
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
    /// Gets or sets the password of the teacher.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
