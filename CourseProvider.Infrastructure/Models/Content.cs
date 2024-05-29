namespace CourseProvider.Infrastructure.Models;

public class Content
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<ProgramDetailItem>? ProgramDetails { get; set; }
}
