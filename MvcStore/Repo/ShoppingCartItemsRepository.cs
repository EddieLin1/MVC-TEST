using MvcStore.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;
using MvcStore.Models;

namespace MvcStore.Repo
{
    public class ShoppingCartItemsRepository : IShoppingCartItemsRepository
    {
        private readonly StoreDBContext _context;
        public ShoppingCartItemsRepository(StoreDBContext context)
        {
            _context = context;
        }
        public Cart GetAllCartItems()
        {
            Cart _cart = new Cart();
           // _cart.ShoppingCart = _context.ShoppingCartItems.Where(j => j.CartId.Equals(2)).ToList();
           _cart.ShoppingCart = _context.ShoppingCartItems.ToList();
            populate(_cart);
            return _cart;
        }
        public CartItem GetCartItemById(int id)
        {
            var data = _context.ShoppingCartItems.FirstOrDefault(x => x.ItemId == id);
            if(data != null){
                data.item = _context.ItemsRepo.Find(id);
            }
            
            return data;
            
        }
        public void AddNew(Item item, int Quantity){
            var data = item2CartItem(item, Quantity);
            _context.ShoppingCartItems.Add(data);
            _context.SaveChanges();
        }
        public void AddMore(int id, int Quantity){
            var data = _context.ShoppingCartItems.SingleOrDefault(j => j.ItemId == id);
            data.Quantity += Quantity;
            SaveChanges(); 
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
        public void Remove(CartItem item){
            _context.ShoppingCartItems.Remove(item);
        }
        public void populate(Cart Cart){
            foreach(CartItem item in Cart.ShoppingCart){
                item.item = _context.ItemsRepo.Find(item.ItemId);
            }
        }
            
        }
 }