 using MvcStore.Interface;
using MvcStore.Data;
using System.Collections.Generic;
using MvcStore.Models;
using System.Linq;

namespace MvcStore.Repo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDBContext _context;
        public OrderRepository(StoreDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.OrderList.ToList();
        }
        public Order GetOrderById(int id)
        {
            return  _context.OrderList.Find(id);
        }
        public void SaveChanges(){
            _context.SaveChanges();
        }
        public void Remove(Order order){
            _context.OrderList.Remove(order);
        }
        public void AddNew(Order order){
            _context.OrderList.Add(order);
        }

        
    }
}