using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riddle.Bank.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [MaxLength(50)]
        public string AccountType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required]
        public DateTime DateOpened { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }
        public Branch Branch { get; set; }
    }

}
