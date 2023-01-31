using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Models;

public record class Category
{
    public Category(Guid id, string? name)
    {
        Id= id;
        Name= name;
    }
    public Category()
    {
        Id= Guid.NewGuid();
    }

    public Guid Id { get; init; }

    [Required(ErrorMessage = "Invalid category name")]
    [StringLength(50, ErrorMessage = "The name value cannot be less 2 characters. ", MinimumLength = 2)]
    public string? Name { get; init; }

    public ICollection<Product>? Products { get; set; }
}
