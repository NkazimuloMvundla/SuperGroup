using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Web.Models
{
    public class OrderDetailModel
    {
        public OrderModel Orders { get; set; }
        public CartLineModel CartLines { get; set; }
        public ProductModel Products { get; set; }
    }
}
