using OrderService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.CosumerModels
{
    public class OrderMessage
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public List<Item>? Items { get; set; }
    }

  
    
}
