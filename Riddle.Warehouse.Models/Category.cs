using Riddle.Warehouse.Models;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; }

    public ICollection<Product> Products { get; set; }
}
