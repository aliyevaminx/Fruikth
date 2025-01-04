using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
	private readonly AppDbContext _context;

	public CommentRepository(AppDbContext context) : base(context)
    {
		_context = context;
	}

	public Task<List<Comment>> GetCommentsByNewsId(int id)
	{
		return _context.Comments.Where(c => c.NewsId == id) .ToListAsync();
	}
}
