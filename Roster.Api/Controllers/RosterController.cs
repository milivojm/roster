using Microsoft.AspNetCore.Mvc;
using Roster.Core;
using Roster.Infrastructure;
using Roster.Api.Commands;

namespace Roster.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RosterController : ControllerBase
{
    readonly RosterContext _context;
    readonly ILogger<RosterController> _logger;

    public RosterController(RosterContext rosterContext, ILogger<RosterController> logger)
    {
        _context = rosterContext;
        _logger = logger;
    }

    [HttpGet("membership-applications")]
    public IEnumerable<MembershipApplication> GetMemershipApplications()
    {
        return _context.MembershipApplications;
    }

    [HttpGet("membership-applications/{username}")]
    public MembershipApplication GetMembershipApplication(string username)
    {
        return _context.MembershipApplications.Find(username);
    }

    [HttpPost("apply")]
    public IActionResult Apply([FromBody] ApplyForMembershipCommand command)
    {
        MembershipApplication app = MembershipApplication.Submit(
            command.Username,
            command.PlainTextPassword,
            command.Email,
            command.FirstName,
            command.LastName,
            command.PhoneNumber,
            command.Age,
            command.Flexfield);

        _context.MembershipApplications.Add(app);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPost("accept/{username}")]
    public IActionResult Accept(string username)
    {
        MembershipApplication membershipApplication = _context.MembershipApplications.Find(username);
        membershipApplication.Accept();

        _context.SaveChanges();

        return Ok();
    }

    [HttpPost("clear")]
    public IActionResult Clear()
    {
        var all = _context.MembershipApplications;
        _context.MembershipApplications.RemoveRange(all);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("delete/{username}")]
    public IActionResult Delete(string username)
    {
        var membershipApplication = _context.MembershipApplications.Find(username);
        _context.MembershipApplications.Remove(membershipApplication);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPatch("update")]
    public IActionResult Update([FromBody] UpdateMembershipApplicationCommand command)
    {
        var membershipApplication = _context.MembershipApplications.Find(command.Username);
        membershipApplication.FirstName = command.FirstName;
        membershipApplication.LastName = command.LastName;
        membershipApplication.Email = command.Email;
        membershipApplication.PhoneNumber = command.PhoneNumber;
        membershipApplication.Age = command.Age;
        membershipApplication.Flexfield = command.Flexfield;
        _context.SaveChanges();

        return Ok();
    }
}
