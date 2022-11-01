using Domain.Models;

namespace Domain.DTOs;

public class SubPageCreationDto {
    public string Name { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
}