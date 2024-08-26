using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Riddle.Bank.Models
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public Account Account { get; set; }

        [Required]
        [MaxLength(20)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string CardType { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(4)]
        public string CVV { get; set; }
    }

}
