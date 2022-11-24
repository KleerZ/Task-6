using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Task.Application.CommandQueries.Message.Commands.Create;
using Task.Application.Common.Interfaces;

namespace Task.Application.Common.Hubs.Message;

public class MessageHub : Hub
{
    private readonly IMediator _mediator;
    private readonly IApplicationContext _context;

    public MessageHub(IMediator mediator, IApplicationContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    public async System.Threading.Tasks.Task Send(string sender, string body, 
        string recipient, string title)
    {
        var command = new CreateMessageCommand
        {
            Sender = sender,
            Body = body,
            Recipient = recipient,
            Title = title
        };

        var message = await _mediator.Send(command);

        var isUserExist = await _context.Users
            .AnyAsync(u => u.Name == recipient);

        if (!isUserExist)
            throw new NullReferenceException($"User named {recipient} does not exist");

        await Clients.User(recipient).SendAsync("Send", message);
    }
}