
namespace Products.Domain.Models;

public class GroupProduct
{
    public string Category { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
