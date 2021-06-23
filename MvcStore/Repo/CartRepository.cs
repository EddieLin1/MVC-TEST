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

        public bool? PurchaseCheck(int CartId){
            var check = _context.Cart.Find(CartId);
            return check.Purchased;
        }
        public bool? PurchaseCheckInit(){
            Cart check = new Cart();

            try
            {
                check = _context.Cart.Find(_context.Cart.Max(x => x.CartId));
            } 
            catch
            {
                return null;
            }
            
            return check.Purchased;
        }
        // need to add adding cart after purchasing with order mangger type shit and selecting purchased etc
    }
}