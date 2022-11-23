using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;

namespace Task.Application.CommandQueries.User.Commands.Login;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ClaimsIdentity>
{
    private readonly IApplicationContext _context;

    public UserLoginCommandHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<ClaimsIdentity> Handle(UserLoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name, cancellationToken);

        if (user is null)
        {
            user = new Domain.User { Name = request.Name };
            
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        var claims = new List<Claim>
        {
            new("Username", user.Name),
        };

        var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", 
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }
}