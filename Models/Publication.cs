using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreforum.Models;

public class Publication
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Rating { get; set; }

    public string Title { get; set; }
    public string? Contents { get; set; }
    public string? Thumbnail { get; set; }

    public Publication(int userId, string title, string? contents = null, string? thumbnail = null)
    {
        UserId = userId;
        Rating = 0;
        Title = title;
        Contents = contents;
        Thumbnail = thumbnail;
    }
}
