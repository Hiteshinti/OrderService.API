
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace OrderService.Core.Entities
{
    public class Order
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid OrdeId { get; set; }
        public Guid UserId { get; set; }

    }


}
