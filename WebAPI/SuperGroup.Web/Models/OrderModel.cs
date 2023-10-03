using System;
using System.Collections.Generic;

namespace SuperGroup.Web.Models
{
    public class OrderModel
    {
        public long OrderId { get; set; }

        public string CustomerName { get; set; }
        public IEnumerable<CartLineModel> Products { get; set; }

        public string Address { get; set; }

        public bool Shipped { get; set; } = false;

        public DateTime OrderedDate { get; set; }
    }

}