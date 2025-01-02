using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class ContactMessage : BaseEntity
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public string Subject { get; set; }
	public string Message { get; set; }
    public bool IsSeen { get; set; }
}
