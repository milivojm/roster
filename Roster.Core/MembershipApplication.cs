namespace Roster.Core;

public class MembershipApplication
{
    string? _hashedPassword;
    bool _accepted;

    public static MembershipApplication Submit(
        string username,
        string plainTextPassword,
        string email,
        string? firstName,
        string? lastName,        
        string? phoneNumber,
        int? age,
        string? flexfield)
    {
        MembershipApplication app = new(username, email);
        app.FirstName = firstName;
        app.LastName = lastName;
        app.Age = age;
        app.PhoneNumber = phoneNumber;
        app.Flexfield = flexfield;

        PasswordHasher passwordHasher = new();
        string hashedPassword = passwordHasher.HashPassword(plainTextPassword);
        app.StorePassword(hashedPassword);

        return app;
    }

    public MembershipApplication(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; private set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? Age { get; set; }
    public bool Accepted => _accepted;
    public string? Flexfield { get; set; }

    public void StorePassword(string hashedPassword)
    {
        _hashedPassword = hashedPassword;
    }

    public void Accept()
    {
        _accepted = true;
    }
}
