using Microsoft.AspNetCore.Mvc;
using Task.Mvc.Models;

namespace Task.Mvc.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(UserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        return RedirectToAction("Index", "Message");
    }
}