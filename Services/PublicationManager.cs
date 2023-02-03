using Libreforum.Data;
using Libreforum.Models;


namespace Libreforum.Services;

public class PublicationManager
{
    private readonly DatabaseContext _databaseContext;

    public PublicationManager(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Publication? CreatePublication(User user, string title, string? contents = null, string? thumbnail = null)
    {
        var tempPublication = new Publication(
            0,
            title,
            contents,
            thumbnail
            );
        var publication = _databaseContext.Publications.Add(tempPublication).Entity;
        _databaseContext.SaveChanges();
        return publication;
    }

    public Publication? GetPublication(int id)
        => _databaseContext.Publications.Find(id);
        
    
}