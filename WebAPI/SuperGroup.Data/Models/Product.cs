using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperGroup.Data.Models
{
    public class Product
    {
        [Key, Column(Order = 1)]
        public long Id { get; set; }

        [Column(Order = 2), Required]
        public string Name { get; set; }

        [Column(Order = 3)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)", Order = 4), Required]
        public decimal Price { get; set; }

        [Column(Order = 5), Required]
        public DateTime Created { get; set; }

        [Column(Order = 6), Required]
        public DateTime Updated { get; set; }
    }

}