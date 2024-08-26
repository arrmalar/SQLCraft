using Riddle.Warehouse.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PurchaseOrderDetail
{
    [Key]
    public int PurchaseOrderDetailID { get; set; }

    [ForeignKey("PurchaseOrder")]
    public int PurchaseOrderID { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; }

    [ForeignKey("Product")]
    public int ProductID { get; set; }
    public Product Product { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }
}
