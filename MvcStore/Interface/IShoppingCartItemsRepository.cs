using MvcStore.Models;
using MvcStore.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;


namespace MvcStore.Interface
{
    public interface IShoppingCartItemsRepository
    {
       // Task<IEnumerable<Cart>> GetAllCartItemsAsync();
        CartItem GetCartItemById(int id);
        Cart GetAllCartItems();
        void AddNew(Item item, int Quantity);
        CartItem item2CartItem(Item item, int Quantity);
        void SaveChanges();
        void Remove(CartItem item);
        void AddMore(int id, int Quantity);


    }
}