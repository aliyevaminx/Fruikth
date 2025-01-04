using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Product;

public class ProductIndexVM
{
    public string? Name { get; set; }
    public int? MinCount { get; set; }
    public int? MaxCount { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public List<Core.Entities.Product> Products { get; set; }
}
