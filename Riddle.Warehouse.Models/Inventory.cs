using System.ComponentModel.DataAnnotations;

namespace Riddle.Warehouse.Models
{
    public class Inventory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int SupplierID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
    }
}
