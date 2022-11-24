namespace Task.Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string? ConnectionId { get; set; }
    
    public List<Message> Messages { get; set; }
}