using Libreforum.Models;
using Libreforum.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libreforum.Pages;

public class CreatePublication : PageModel
{
    private PublicationManager _publicationManager;
    private UserManager _userManager;

    public CreatePublication(PublicationManager publicationManager, UserManager userManager)
    {
        _publicationManager = publicationManager;
        _userManager = userManager;
    }

    public void OnPost(string title, string content)
    {
        var context = HttpContext.Request.HttpContext;
        var session = context.Session;
        var sus = session.GetInt32("UserId");
        if(sus == null) return;
        var user = _userManager.GetUserById(sus.Value);
        if(user == null) return;
        _publicationManager.CreatePublication(
            user,
            title,
            content,
            null);
    }
}