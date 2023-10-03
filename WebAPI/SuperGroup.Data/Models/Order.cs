using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperGroup.Data.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<CartLine> Products { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool Shipped { get; set; } = false;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Updated { get; set; }
    }
}