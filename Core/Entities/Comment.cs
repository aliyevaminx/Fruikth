using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Comment : BaseEntity
{
    public User User { get; set; }
    public string UserId { get; set; }
    public News News { get; set; }
    public int NewsId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
