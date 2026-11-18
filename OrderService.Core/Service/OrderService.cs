using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Service
{
    public class OrderService :IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService (IOrderRepository orderRepository)
        {

            _orderRepository = orderRepository; 

        }
        public async Task<List<Item>> GetOrderById(string userId)
        {
            return  await _orderRepository.GetOrdersById(userId);
        }
    }
}
