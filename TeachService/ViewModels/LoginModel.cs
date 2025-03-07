namespace TeachService.ViewModels;

/// <summary>
/// Represents the login model with username and password.
/// </summary>
/// <param name="Username">The username of the user.</param>
/// <param name="Password">The password of the user.</param>
public record LoginModel(string Username, string Password);

/// <summary>
/// Represents a request to create or update a student.
/// </summary>
/// <param name="FirstName">The first name of the student.</param>
/// <param name="LastName">The last name of the student.</param>
/// <param name="Email">The email address of the student.</param>
public record StudentRequest(string FirstName, string LastName, string Email);

/// <summary>
/// Represents a response containing student information.
/// </summary>
/// <param name="Id">The unique identifier of the student.</param>
/// <param name="FirstName">The first name of the student.</param>
/// <param name="LastName">The last name of the student.</param>
/// <param name="Email">The email address of the student.</param>
/// <param name="TeacherId">The unique identifier of the teacher associated with the student.</param>
public record StudentResponse(int Id, string FirstName, string LastName, string Email, int TeacherId);