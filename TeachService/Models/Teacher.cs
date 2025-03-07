namespace TeachService.Models;

/// <summary>
/// Represents a teacher in the teaching service.
/// </summary>
public class Teacher
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
    /// Gets or sets the hashed password of the teacher.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of students associated with the teacher.
    /// </summary>
    public ICollection<Student> Students { get; set; } = [];
}
