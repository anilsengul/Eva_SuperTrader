using System.ComponentModel.DataAnnotations;

namespace EvaTrader
{
    public class Share
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string ShareName { get; set; }
        [Required]
        [StringLength(3)]
        public string ShareSymbol { get; set; }
        [Required]
        public decimal BuyPrice { get; set; }
        [Required]
        public decimal SellPrice { get; set; }
    }
}
