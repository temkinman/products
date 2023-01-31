
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Models;

public record Product
{
    public Product(Guid id, string? name, string? description, decimal? price)
    {
        Id = id;
        Name = name;
        Description = description ?? string.Empty;
        Price = price ?? 0;
    }

    public Guid Id { get; init; }
    
    [Required(ErrorMessage = "Invalid product name")]
    [StringLength(2, ErrorMessage = "The name value cannot be less 2 characters. ")]
    public string? Name { get; init; }

    public string? Description { get; init; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Price { get; init; }

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
