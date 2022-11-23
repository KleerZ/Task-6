using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.CommandQueries.Message.Queries.GetAll;

namespace Task.Mvc.Controllers;

public class MessageController : Controller
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(string username)
    {
        var query = new GetMessageListQuery { Name = username };
        var result = await _mediator.Send(query);

        var messages = result.Messages.ToList();
        
        return View(messages);
    }
}