using Riddle.Warehouse.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShipmentDetail
{
    [Key]
    public int ShipmentDetailID { get; set; }

    [ForeignKey("Shipment")]
    public int ShipmentID { get; set; }
    public Shipment Shipment { get; set; }

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
