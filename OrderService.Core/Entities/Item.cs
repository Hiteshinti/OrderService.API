
using System.ComponentModel.DataAnnotations;

namespace OrderService.Core.Entities
{
    public class Item
    {

        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }


    }
}
