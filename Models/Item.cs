using System.ComponentModel.DataAnnotations.Schema;

namespace ProductInventoryAPI.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}