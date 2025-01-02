using Business.Services.Abstract;
using Business.ViewModels.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ContactController : Controller
{
	private readonly IContactService _contactService;

	public ContactController(IContactService contactService)
    {
		_contactService = contactService;
	}

    public async Task<IActionResult> Index()
	{
		var model = await _contactService.GetAllAsync();
		return View(model);
	}

	public async Task<IActionResult> Details(int id)
	{
		var model = await _contactService.GetAsync(id);
		if (model is null) return BadRequest();

		return View(model);
	}

	public async Task<IActionResult> MakeSeen(int id)
	{
		var IsSucceeded = await _contactService.MakeSeenAsync(id);
		if (!IsSucceeded) return BadRequest();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
	{
		var IsSucceeded = await _contactService.DeleteAsync(id);
		if (!IsSucceeded) return BadRequest();

		return RedirectToAction(nameof(Index));
	}
}
