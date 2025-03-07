namespace TeachService.ViewModels;

public record LoginModel(string Username, string Password);

public record StudentRequest(string FirstName, string LastName, string Email);

public record StudentResponse(int Id, string FirstName, string LastName, string Email, int TeacherId);