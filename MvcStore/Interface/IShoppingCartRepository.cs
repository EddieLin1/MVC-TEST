using MvcStore.Models;
using MvcStore.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;


namespace MvcStore.Interface
{
    public interface IShoppingCartRepository
    {
       // Task<IEnumerable<Cart>> GetAllCartItemsAsync();
        CartItem GetCartItemById(int id);
        Cart GetAllCartItems();
        void Add(Item item);
        CartItem item2CartItem(Item item);
        void SaveChanges();


    }
}