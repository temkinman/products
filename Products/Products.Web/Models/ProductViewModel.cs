using Products.Domain.Models;

namespace Products.Web.Models;

public class ProductViewModel
{
    public Product Product { get; set; }
    public List<Category> Categories { get; set; } = new();
}
