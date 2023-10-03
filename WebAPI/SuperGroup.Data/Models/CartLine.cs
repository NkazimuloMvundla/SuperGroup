using System.ComponentModel.DataAnnotations;

namespace SuperGroup.Data.Models
{
    public class CartLine
    {
        public long CartLineId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
        public long OrderId { get;  set; }
    }
}