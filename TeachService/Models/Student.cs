namespace TeachService.Models;

/// <summary>
/// Represents a student in the teaching service.
/// </summary>
public class Student
{
    /// <summary>
    /// Gets or sets the unique identifier for the student.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the student.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the student.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the student.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the teacher associated with the student.
    /// </summary>
    public int TeacherId { get; set; }

    /// <summary>
    /// Gets or sets the teacher associated with the student.
    /// </summary>
    public Teacher Teacher { get; set; } = null!;
}
