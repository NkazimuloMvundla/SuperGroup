using System;
using System.Collections.Generic;
using System.Text;

namespace SuperGroup.Models.Models
{
    public class OrderDomainModel
    {
        public long OrderId { get; set; }

        public string CustomerName { get; set; }
        public IEnumerable<CartLineDomainModel> Products { get; set; }

        public string Address { get; set; }

        public bool Shipped { get; set; } = false;
        public DateTime OrderedDate { get; set; }
    }
}
