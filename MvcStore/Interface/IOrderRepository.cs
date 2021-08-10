using MvcStore.Models;
using System.Collections.Generic;

namespace MvcStore.Interface

{
    public interface IOrderRepository 
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void SaveChanges();
        void Remove(Order order);
        void AddNew(Order order);
    }
}