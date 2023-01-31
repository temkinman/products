
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Models;

public record Product
{
    public Product(string? name, string? description, decimal price)
    {
        Name = name;
        Description = description ?? string.Empty;
        Price = price;
    }

    public Product()
    {
        Id = Guid.NewGuid();
        Price = 0;
    }

    public Guid Id { get; init; }
    
    [Required(ErrorMessage = "Invalid product name")]
    [StringLength(50, ErrorMessage = "The name value cannot be less 2 characters. ", MinimumLength = 2)]
    public string? Name { get; init; }

    public string? Description { get; init; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; init; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}
