namespace Domain.Dtos;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public DateTime CreateDate { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string Content { get; set; }

}