using MediatR;

namespace Task.Application.CommandQueries.Message.Commands.Create;

public class CreateMessageCommand : IRequest<MessageDto>
{
    public string? Sender { get; set; }
    public string Recipient { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}