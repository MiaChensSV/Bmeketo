using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    private readonly ContactService _contactService;

    public ContactsController(ContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel viewmodel)
    {
        if (ModelState.IsValid)
        {
            await _contactService.RegisterAsync(viewmodel);
            return RedirectToAction("Index");
        }else
        {
            ModelState.AddModelError("", ModelState.ValidationState.ToString());
        }
        return View(viewmodel);

    }
}
