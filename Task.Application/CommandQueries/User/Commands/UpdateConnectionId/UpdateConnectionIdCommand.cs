using MediatR;

namespace Task.Application.CommandQueries.User.Commands.UpdateConnectionId;

public class UpdateConnectionIdCommand : IRequest
{
    public string? Name { get; set; }
    public string ConnectionId { get; set; }
}