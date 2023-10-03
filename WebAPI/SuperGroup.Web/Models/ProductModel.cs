using System.ComponentModel.DataAnnotations.Schema;

namespace SuperGroup.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}