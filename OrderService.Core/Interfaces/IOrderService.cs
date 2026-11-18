using OrderService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Interfaces
{
    public interface IOrderService
    {
         Task<List<Item>> GetOrderById(string userId);    
    }

}
