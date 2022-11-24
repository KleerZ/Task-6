using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;

namespace Task.Application.CommandQueries.Message.Commands.Create;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public CreateMessageCommandHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MessageDto> Handle(CreateMessageCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Name == request.Recipient, cancellationToken);

        if (user is null)
            throw new NullReferenceException($"user named {user.Name} does not exist");

        var message = new Domain.Message
        {
            Recipient = request.Recipient,
            Title = request.Title,
            Body = request.Body,
            Sender = request.Sender,
            Date = DateTime.Now,
            User = user
        };

        await _context.Messages.AddAsync(message, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MessageDto>(message);
    }
}