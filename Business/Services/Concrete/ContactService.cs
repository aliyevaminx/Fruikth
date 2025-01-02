using Business.Services.Abstract;
using Business.ViewModels.Contact;
using Core.Entities;
using Data.Repositories.Abstract;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete;

public class ContactService : IContactService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IContactRepository _contactRepository;

	public ContactService(IUnitOfWork unitOfWork,
						  IContactRepository contactRepository)
    {
		_unitOfWork = unitOfWork;
		_contactRepository = contactRepository;
	}

	public async Task<ContactIndexVM> GetAllAsync()
	{
		return new ContactIndexVM
		{
			ContactMessages = await _contactRepository.GetAllAsync()
		};
	}

    public async Task<ContactMessageDetailsVM> GetAsync(int id)
    {
        var message = await _contactRepository.GetAsync(id);
		if (message is null) return null;

		var model = new ContactMessageDetailsVM
		{
			Name = message.Name,
			Email = message.Email,
			PhoneNumber = message.PhoneNumber,
			Subject = message.Subject,
			Message = message.Message,
			CreatedAt = message.CreatedAt
		};
		
		return model;
    }
    public async Task<bool> CreateMessageAsync(ContactMessageCreateVM model)
	{
		var message = new ContactMessage
		{
			Name = model.Name,
			Email = model.Email,
			PhoneNumber = model.PhoneNumber,
			Subject = model.Subject,
			Message = model.Message,
			CreatedAt = DateTime.Now,
		};

		await _contactRepository.CreateAsync(message);
		await _unitOfWork.CommitAsync();
		return true;
	}

	public async Task<bool> MakeSeenAsync(int id)
	{
		var message = await _contactRepository.GetAsync(id);
		if (message is null) return false;

		if (message.IsSeen)
			message.IsSeen = false;
		else 
			message.IsSeen = true;

		_contactRepository.Update(message);
		await _unitOfWork.CommitAsync();

		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var message =await _contactRepository.GetAsync(id);
		if (message is null) return false;

		_contactRepository.Delete(message);
		await _unitOfWork.CommitAsync();

		return true;
	}
}
