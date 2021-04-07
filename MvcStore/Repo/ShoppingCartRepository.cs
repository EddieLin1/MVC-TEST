using MvcStore.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;
using MvcStore.Models;

namespace MvcStore.Repo
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly StoreDBContext _context;
        public ShoppingCartRepository(StoreDBContext context)
        {
            _context = context;
        }
        public Cart GetAllCartItems()
        {
            Cart _cart = new Cart();
            _cart.ShoppingCart = _context.ShoppingCart.ToList();
            return _cart;
        }
        public CartItem GetCartItemById(int id)
        {
            return _context.ShoppingCart.Find(id);
        }
        public void Add(Item item, int Quantity){
            var data = item2CartItem(item, Quantity);
            _context.ShoppingCart.Add(data);
            _context.SaveChanges();
        }
        
        public CartItem item2CartItem(Item item, int Quantity){
            CartItem temp = new CartItem();
            temp.item = item;
            temp.ItemId = item.Id;
            temp.Quantity = Quantity;
            return temp;
        }
        public void SaveChanges(){
            _context.SaveChanges();
        }
            
        }
 }