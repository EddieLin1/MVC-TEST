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
        public Cart GetAllCartItems(int id)
        {
            //_cart.ShoppingCart = _context.ShoppingCartItems.Where(x => x.CartId == CurrentCartNum())
            // _cart.ShoppingCart = _context.ShoppingCartItems.Where(j => j.CartId.Equals(2)).ToList();
            Cart _cart = new Cart();
           //_cart.ShoppingCart = _context.ShoppingCartItems.ToList();
           _cart.ShoppingCart = _context.ShoppingCartItems.Where(x => x.CartId == id).ToList();
           
                        //.ToList();
            populate(_cart, id);
            return _cart;
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
        public void populate(Cart Cart, int id){
            foreach(CartItem item in Cart.ShoppingCart){
                if (item.CartId == id){
                    item.item = _context.ItemsRepo.Find(item.ItemId);
                }
                
            }
        }

        // will have check cart purchased, if true then max id + 1 else base
        public int CurrentCartNum() // need cart repo to verify if this is current cart num / not purchased yet or not thing
        {
            return _context.Cart.Max(x => x.CartId) + 1;
            /*
            if(purchased_check){
                return _context.Cart.Max(x => x.CartId) + 1;
            }else
            {
                if (_context.ShoppingCartItems.FirstOrDefault() == null){
                    return 0;
                }
                else{
                    return _context.ShoppingCartItems.Max(x => x.CartId);
                }
                
            } */
            
        }
      
            
        }
 }