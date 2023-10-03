using SuperGroup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperGroup.Models.Models
{

    public class OrderDetailDomainModel
    {
        public OrderDomainModel Orders { get; set; }
        public CartLineDomainModel CartLines { get; set; }
        public ProductDomainModel Products { get; set; }
    }

}
