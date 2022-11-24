using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;

namespace Task.Application.CommandQueries.User.Commands.UpdateConnectionId;

public class UpdateConnectionIdCommandHandler : IRequestHandler<UpdateConnectionIdCommand, Unit>
{
    private readonly IApplicationContext _context;

    public UpdateConnectionIdCommandHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateConnectionIdCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name, cancellationToken);

        if (user is null)
            return Unit.Value;

        user.ConnectionId = request.ConnectionId;

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}