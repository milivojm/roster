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
        MembershipApplication app = MembershipApplication.Submit(
            command.FirstName,
            command.LastName,
            command.Username,
            command.PlainTextPassword,
            command.Email,
            command.PhoneNumber,
            command.Age);

        _context.MembershipApplications.Add(app);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPatch("accept")]
    public IActionResult Accept([FromBody] string username)
    {
        MembershipApplication membershipApplication = _context.Find<MembershipApplication>(username);
        membershipApplication.Accept();

        _context.SaveChanges();

        return Ok();
    }
}
