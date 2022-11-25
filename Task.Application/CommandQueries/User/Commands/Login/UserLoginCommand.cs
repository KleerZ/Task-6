using System.Security.Claims;
using MediatR;

namespace Task.Application.CommandQueries.User.Commands.Login;

public class UserLoginCommand : IRequest<ClaimsIdentity>
{
    public string Name { get; set; }
}