using System.ComponentModel.DataAnnotations;

namespace EvaTrader
{
    public class Portfolio
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ShareID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string ShareName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
