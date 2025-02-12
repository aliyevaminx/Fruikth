﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Comment;

public class CommentCreateVM
{
	[Required(ErrorMessage = "Name is required")]
	public string Name { get; set; }
	
	[Required(ErrorMessage = "Email is required")]
	public string Email { get; set; }
	
	[Required(ErrorMessage = "Message is required")]
	public string Message { get; set; }
    public int NewsId { get; set; }
}
