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
            //_cart.ShoppingCart = _context.ShoppingCartItems.Where(x => x.CartId == CurrentCartNum())
            // _cart.ShoppingCart = _context.ShoppingCartItems.Where(j => j.CartId.Equals(2)).ToList();
            Cart _cart = new Cart();
           _cart.ShoppingCart = _context.ShoppingCartItems.ToList();
           
                        //.ToList();
            populate(_cart);
            return _cart;
        }
        public int CurrentCartNum(bool? purchased_check) // need cart repo to verify if this is current cart num / not purchased yet or not thing
        {
            int _CartId = 0;   

            if(purchased_check == false){
                _CartId = _context.ShoppingCartItems.Max(x => x.CartId);
            }else if(purchased_check == true){
                _CartId = _context.ShoppingCartItems.Max(x => x.CartId) + 1;
            }
            
            return _CartId;
        }
        public Cart test()
        {
            Cart _cart = new Cart();
            var _CartId = _context.ShoppingCartItems.Max(x => x.CartId) + 1;
            var query = _context.ShoppingCartItems.Where(x => x.CartId == _CartId)
                        .ToList();
            
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
        public void AddNew(Item item, int Quantity, int _cartId){
            var data = item2CartItem(item, Quantity);
            data.CartId = _cartId;
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