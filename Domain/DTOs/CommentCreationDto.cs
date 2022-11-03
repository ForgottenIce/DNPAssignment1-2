namespace Domain.DTOs;

public class CommentCreationDto {
    public string Title { get; set; }
    public string Body { get; set; }
    public string AuthorId { get; set; }
}