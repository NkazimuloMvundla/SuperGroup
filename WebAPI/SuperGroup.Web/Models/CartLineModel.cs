using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Web.Models
{
    public class CartLineModel
    {
        public long CartLineId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
