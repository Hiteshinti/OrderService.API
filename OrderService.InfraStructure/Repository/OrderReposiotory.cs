using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using OrderService.InfraStructure.Context;


namespace OrderService.InfraStructure.Repository
{
     public class OrderRepository :IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
       
         public OrderRepository(AppDbContext appDbContext) 
         {
            _appDbContext = appDbContext;
           
        }


        public void AddOrder(Order order, List<Item> items)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.Items.AddRange(items);
            _appDbContext.SaveChanges();

        }

        public async Task<List<Item>> GetOrdersById(string userId)
        {
            
            var items = _appDbContext.Orders.Where(o => o.UserId.ToString() == userId)
                .Join(_appDbContext.Items, o => o.OrdeId, i => i.OrderId, (o, i) => i)
                .ToList();

            return items;
        }
    }
}
