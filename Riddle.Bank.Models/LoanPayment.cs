using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Riddle.Bank.Models
{
    public class LoanPayment
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("Loan")]
        public int LoanID { get; set; }
        public Loan Loan { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestPaid { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrincipalPaid { get; set; }
    }

}
