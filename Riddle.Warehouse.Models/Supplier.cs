using Riddle.Warehouse.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Supplier
{
    [Key]
    public int SupplierID { get; set; }

    [Required]
    [MaxLength(100)]
    public string SupplierName { get; set; }

    [MaxLength(100)]
    public string ContactName { get; set; }

    [MaxLength(200)]
    public string Address { get; set; }

    [MaxLength(100)]
    public string City { get; set; }

    [MaxLength(20)]
    public string PostalCode { get; set; }

    [MaxLength(50)]
    public string Country { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
}
