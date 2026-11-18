using OrderService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Interfaces
{
     public interface IOrderRepository  
     {
         void AddOrder(Order order,List<Item> items);  
         Task<List<Item>> GetOrdersById(string userId);   
    }
}
