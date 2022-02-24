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
            var check = _context.Cart.Find(CartId);
            return check.Purchased;
        }
        public bool PurchaseCheckInit(){
            Cart check = new Cart();
            check = _context.Cart.Find(_context.Cart.Max(x => x.CartId));
            return check.Purchased;
        }
        // need to add adding cart after purchasing with order mangger type and selecting purchased etc
        public void add_update_cart(Cart model){
            if (_context.Cart.Find(model.CartId) != null)
                {
                    _context.Add(model);
                } 
                else
                {
                    var data = _context.Cart.Update(model);
                } 
                SaveChanges();
        }

        public Cart get_cart(int cart_id){
            return _context.Cart.Find(cart_id);
        }

        public int get_current_cartnum(){
            return _context.Cart.Max(x => x.CartId);
        }

        public void SaveChanges(){
            _context.SaveChanges();
        }
    }
}