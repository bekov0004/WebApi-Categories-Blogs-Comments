namespace Domain.Dtos;

public class Comment
{
    public int Id { get; set; }
    public string CretedBy { get; set; }
    public DateTime CretedAt { get; set; }
    public string Message { get; set; }
    public string Email { get; set; }
    public int ReplyId { get; set; }
    public int BlogId { get; set; }
}