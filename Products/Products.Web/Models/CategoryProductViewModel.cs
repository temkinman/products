namespace Products.Web.Models;

public record CategoryProductViewModel
{
    public CategoryProductViewModel( string category, string product)
    {
        Category = category;
        Product = product;
    }
    public string Category { get; init; }
    public string Product { get; init; }
}
