using MediatR;

namespace Task.Application.CommandQueries.Message.Queries.GetAll;

public class GetMessageListQuery : IRequest<MessagesListVm>
{
    public string? Name { get; set; }
}