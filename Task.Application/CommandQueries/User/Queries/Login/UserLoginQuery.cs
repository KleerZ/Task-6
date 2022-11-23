using MediatR;

namespace Task.Application.CommandQueries.User.Queries.Login;

public class UserLoginQuery : IRequest<string>
{
    public string Name { get; set; }
}