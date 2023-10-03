using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Web.Models
{
    public class ProductsListModel
    {
        public IReadOnlyCollection<ProductModel> Products { get; set; }

        public int TotalRowCount { get; set; }
    }
}
