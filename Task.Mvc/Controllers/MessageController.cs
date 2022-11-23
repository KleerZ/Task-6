using Microsoft.AspNetCore.Mvc;

namespace Task.Mvc.Controllers;

public class MessageController : Controller
{
    public IActionResult Index(string username)
    {
        return View();
    }
}