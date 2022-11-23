using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;

namespace Task.Application.CommandQueries.User.Queries.Login;

public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, string>
{
    private readonly IApplicationContext _context;

    public UserLoginQueryHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UserLoginQuery request,
        CancellationToken cancellationToken)
    {
        var isUserExist = await _context.Users
            .AnyAsync(u => u.Name == request.Name, cancellationToken);

        if (isUserExist)
            return request.Name;

        var user = new Domain.User { Name = request.Name };

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Name;
    }
}