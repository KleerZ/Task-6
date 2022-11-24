using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task.Application.CommandQueries.Message.Commands.Create;
using Task.Application.CommandQueries.Message.Queries.GetAll;
using Task.Application.CommandQueries.User.Commands.UpdateConnectionId;
using Task.Application.CommandQueries.User.Queries;
using Task.Mvc.Models;

namespace Task.Mvc.Controllers;

[Authorize]
public class MessageController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MessageController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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

    [HttpPost]
    public async Task<IActionResult> SetConnectionId(string connectionId)
    {
        var command = new UpdateConnectionIdCommand
        {
            Name = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            ConnectionId = connectionId
        };
        await _mediator.Send(command);
        
        return Ok();
    }
}