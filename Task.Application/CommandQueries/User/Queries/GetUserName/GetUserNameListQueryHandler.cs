using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;

namespace Task.Application.CommandQueries.User.Queries.GetUserName;

public class GetUserNameListQueryHandler : IRequestHandler<GetUserNameListQuery, UserNameListVm>
{
    private readonly IApplicationContext _context;

    public GetUserNameListQueryHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<UserNameListVm> Handle(GetUserNameListQuery request,
        CancellationToken cancellationToken)
    {
        var usernames = await _context.Users
            .Select(u => u.Name).ToListAsync(cancellationToken);

        return new UserNameListVm { UserNames = usernames };
    }
}