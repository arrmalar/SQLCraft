using Riddle.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PurchaseOrder
{
    [Key]
    public int PurchaseOrderID { get; set; }

    [ForeignKey("Supplier")]
    public int SupplierID { get; set; }
    public Supplier Supplier { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; }

    public DateTime? ExpectedDeliveryDate { get; set; }

    public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
}
