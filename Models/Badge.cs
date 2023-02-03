using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreforum.Models;

public class Badge
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public DateOnly CreationDate { get; set; }

    public Badge(string name, DateOnly creationDate, string? description = null)
    {
        Name = name;
        Description = description;
        CreationDate = creationDate;
    }
}
