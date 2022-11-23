using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Task.Application.CommandQueries.User.Commands.Login;
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

        var command = new UserLoginCommand { Name = model.Name };
        var identity = await _mediator.Send(command);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Message");
    }
}