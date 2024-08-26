using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Riddle.Bank.Models
{
    public class CreditScore
    {
        [Key]
        public int CreditScoreID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime DateChecked { get; set; }
    }

}
