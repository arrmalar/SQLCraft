using Riddle.Warehouse.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductStock
{
    [ForeignKey("Product")]
    public int ProductID { get; set; }
    public Product Product { get; set; }

    [ForeignKey("StockLocation")]
    public int LocationID { get; set; }
    public StockLocation StockLocation { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Key]
    [Column(Order = 0)]
    public int ProductStockID { get; set; }
}
