using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperGroup.Domain.Models
{
    public class ProductDomainModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
