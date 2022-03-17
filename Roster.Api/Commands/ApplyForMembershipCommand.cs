using Roster.Infrastructure;

namespace Roster.Core.Commands;

public class ApplyForMembershipCommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int? Age { get; set; }
}