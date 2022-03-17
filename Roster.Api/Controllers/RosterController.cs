using Microsoft.AspNetCore.Mvc;
using Roster.Core;
using Roster.Infrastructure;
using Roster.Core.Commands;

namespace Roster.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RosterController : ControllerBase
{
    readonly RosterContext _context;

    public RosterController(RosterContext rosterContext)
    {
        _context = rosterContext;
    }

    [HttpGet("membership-applications")]
    public IEnumerable<MembershipApplication> GetMemershipApplications()
    {
        return _context.MembershipApplications;
    }

    [HttpPost("apply")]
    public IActionResult Apply([FromBody] ApplyForMembershipCommand command)
    {
        MembershipApplication app = new(command.FirstName, command.LastName, command.Username, command.Email, "");
        app.Age = command.Age;
        app.PhoneNumber = command.PhoneNumber;
        _context.MembershipApplications.Add(app);
        _context.SaveChanges();
        
        return Ok();
    }
}
