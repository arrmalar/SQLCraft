using Riddle.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Shipment
{
    [Key]
    public int ShipmentID { get; set; }

    [Required]
    public DateTime ShipmentDate { get; set; } = DateTime.Now;

    [MaxLength(100)]
    public string Carrier { get; set; }

    [MaxLength(50)]
    public string TrackingNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } // np. 'Shipped', 'In Transit', 'Delivered'

    public ICollection<ShipmentDetail> ShipmentDetails { get; set; }
}
