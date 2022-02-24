using MvcStore.Interface;
using MvcStore.Data;
using System.Linq;
using MvcStore.Models;


namespace MvcStore.Repo

{
    public class CartRepository : ICartRepository
    {
       private readonly StoreDBContext _context;
        public CartRepository(StoreDBContext context)
        {
            _context = context;
        } 

        public bool PurchaseCheck(int CartId){
            if (_context.Cart.FirstOrDefault() == null){
                return false;
            }else{
                var check = _context.Cart.FirstOrDefault(x => x.CartId == CartId);
                return check.Purchased;
                
            }
            
        }
        public bool PurchaseCheckInit(){
            Cart check = new Cart();
            check = _context.Cart.Find(_context.Cart.Max(x => x.CartId));
            return check.Purchased;
        }
        // need to add adding cart after purchasing with order mangger type and selecting purchased etc
        public void add_cart(Cart model){
            _context.Cart.Add(model);
           
            SaveChanges();
        }

        public Cart get_cart(int cart_id){
            return _context.Cart.Find(cart_id);
        }


        public int get_current_cartnum(){
            if (_context.Cart.FirstOrDefault() == null){
                return 0;
            }else{
                return _context.Cart.Max(x => x.CartId) + 1;
            }
            
        }

        public void SaveChanges(){
            _context.SaveChanges();
        }
    }
}