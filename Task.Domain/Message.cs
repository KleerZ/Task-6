namespace Task.Domain;

public class Message
{
    public int Id { get; set; }
    public string Sender { get; set; }
    public string Recipient { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public User User { get; set; }
}