using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.CommandQueries.User.Queries.Login;
using Task.Mvc.Models;

namespace Task.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var query = new UserLoginQuery { Name = model.Name };
        var username = await _mediator.Send(query);

        return RedirectToAction("Index", "Message", username);
    }
}