using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreClasslib
{
    public class InventoryItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public Product Prod { set; get; }
        public int Quantity { set; get; }
        [ForeignKey("StoreFrontId")]
        public int StoreFrontId { set; get; }
    }
}
