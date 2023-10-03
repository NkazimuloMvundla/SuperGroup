using System;
using System.Collections.Generic;
using System.Text;

namespace SuperGroup.Models.Models
{
   public class CartLineDomainModel
    {
        public long CartLineId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
