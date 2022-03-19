namespace Roster.Api.Commands;

public class UpdateMembershipApplicationCommand
{
    public string Username { get; set; }    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int? Age { get; set; }
    public string Flexfield { get; set; }
}