using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Models;

public record class Category
{
    public Category(Guid id, string? name)
    {
        Id= id;
        Name= name;
    }
    public Guid Id { get; init; }

    [Required(ErrorMessage = "Invalid category name")]
    [StringLength(2, ErrorMessage = "The name value cannot be less 2 characters. ")]
    public string? Name { get; init; }

    public ICollection<Product>? Products { get; set; }
}
