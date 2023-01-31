using Products.Domain.Models;

namespace Products.Web.Models;

public class GroupProductViewModel
{
    public string Category { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
