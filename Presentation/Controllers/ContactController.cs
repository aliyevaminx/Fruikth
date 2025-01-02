using Business.Services.Abstract;
using Business.ViewModels.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
public class ContactController : Controller
{
	private readonly IContactService _contactService;

	public ContactController(IContactService contactService)
    {
		_contactService = contactService;
	}

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(ContactMessageCreateVM model)
    {
        var IsSucceeded = await _contactService.CreateMessageAsync(model);
        if (!IsSucceeded) return BadRequest();

        return RedirectToAction(nameof(Index));
    }
}
