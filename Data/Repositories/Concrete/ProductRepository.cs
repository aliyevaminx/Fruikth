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

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProductsWithCategoriesAsync()
    {
        return await _context.Products.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).ToListAsync();
    }

    public async Task<Product> GetProductByTitleAsync(string title)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<Product> GetProductWithCategoriesAsync(int id)
    {
        return await _context.Products.Include(p => p.ProductCategories)
                                      .ThenInclude(pc => pc.Category)
                                      .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetLastThreeProducts()
    {
        return await _context.Products.OrderByDescending(p => p.CreatedAt).Take(3).ToListAsync();
    }

    public IQueryable<Product> FilterByName(string name)
    {
        return name != null ? _context.Products.Include(p => p.ProductCategories)
                                      .ThenInclude(pc => pc.Category).Where(p => p.Title.Contains(name)) :
                                      _context.Products.Include(p => p.ProductCategories)
                                      .ThenInclude(pc => pc.Category);

	}

    public IQueryable<Product> FilterByCount(IQueryable<Product> products, int? minCount, int? maxCount)
    {
        return products.Where(p => (minCount != null ? p.StockCount >= minCount : true) &&
                                (maxCount != null ? p.StockCount <= maxCount : true));
    }

    public IQueryable<Product> FilterByPrice(IQueryable<Product> products, int? minPrice, int? maxPrice)
    {
        return products.Where(p => (minPrice != null ? p.Price >= minPrice : true) &&
                                   (maxPrice != null ? p.Price <= maxPrice : true));
    }
}
