namespace Task.Application.CommandQueries.Message.Queries.GetAll;

public class MessagesListVm
{
    public IEnumerable<Domain.Message> Messages { get; set; }
}