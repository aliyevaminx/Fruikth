using Business.ViewModels.Contact;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract;

public interface IContactService
{
	Task<ContactIndexVM> GetAllAsync();
	Task<ContactMessageDetailsVM> GetAsync(int id);	
	Task<bool> CreateMessageAsync(ContactMessageCreateVM model);
	Task<bool> MakeSeenAsync(int id);
	Task<bool> DeleteAsync(int id);
}
