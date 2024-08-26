using Riddle.Warehouse.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class StockLocation
{
    [Key]
    public int LocationID { get; set; }

    [Required]
    [MaxLength(100)]
    public string LocationName { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    public ICollection<ProductStock> ProductStocks { get; set; }
}
