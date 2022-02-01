using System.ComponentModel.DataAnnotations;

namespace EvaTrader
{
    public class User
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
