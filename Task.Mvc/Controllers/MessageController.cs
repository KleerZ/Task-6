using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task.Application.CommandQueries.Message.Queries.GetAll;
using Task.Application.CommandQueries.User.Queries.GetUserName;

namespace Task.Mvc.Controllers;

[Authorize]
public class MessageController : Controller
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        var query = new GetMessageListQuery { Name = username };
        var result = await _mediator.Send(query);

        var messages = result.Messages.ToList();
        
        return View(messages);
    }

    [HttpPost]
    public async Task<IActionResult> GetUserNames()
    {
        var query = new GetUserNameListQuery();
        var result = await _mediator.Send(query);

        return Ok(result.UserNames.ToList());
    }
}