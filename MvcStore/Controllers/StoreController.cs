using Microsoft.AspNetCore.Mvc;
using MvcStore.Models;
using MvcStore.Interface;


namespace MvcStore.Controllers
{
    public class StoreController : Controller
    {

        private readonly IItemRepository _Ritem;
        private readonly IShoppingCartItemsRepository _cart;

        private readonly ICartRepository _cartPurch;
        private int CartId {get; set;}


        public StoreController(IItemRepository item, IShoppingCartItemsRepository cart, ICartRepository cartpurch)
        {
            _Ritem = item;
            _cart = cart;
            _cartPurch = cartpurch;
        }

        public IActionResult ShopView()
        {
            var data =  _Ritem.GetAllRepoItems();
            return View(data);
        } 


        // GET: Pet
        public IActionResult Index()
        {
            var data =  _cart.GetAllCartItems();
            data.CartTotal = data._CartTotal();
            return View(data);
        }

        // GET: Store/Create
        public IActionResult Create(int id) //this page is not showing and i am not sure why
        {
            
            var data = _Ritem.GetRepoItemById(id);
            CartItem temp = new CartItem();
            temp.item = data;
            temp.ItemId = data.Id;

            return View(temp);

        } 

        // POST: Store/Create/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfrimed(int ItemId, int Quantity)
        {
            if(ModelState.IsValid)
            {   
                //if (_cartPurch.get_cart)

                if (_cart.GetCartItemById(ItemId) != null)
                {
                    var item = _Ritem.GetRepoItemById(ItemId); 
                    item.QuantitySold += Quantity;
                    _Ritem.SaveChanges();
                    _cart.AddMore(ItemId, Quantity);
                    _cart.SaveChanges();
                    return RedirectToAction(nameof(Index));
                } 
                else
                {
                    var item = _Ritem.GetRepoItemById(ItemId);
                    item.QuantitySold += Quantity;
                    _cart.AddNew(item, Quantity, _cart.CurrentCartNum(_cartPurch.PurchaseCheck(CartId)));
                    _Ritem.SaveChanges();
                    _cart.SaveChanges();
                    return RedirectToAction(nameof(Index));
                } 
            }
            else
            {
                return RedirectToAction(nameof(Index));
            } 
             
            
        }
        

        // GET: Store/Delete/5
        public IActionResult Delete(int id)
        {

            var data = _cart.GetCartItemById(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, int Quantity)
        {
            if(ModelState.IsValid){
                 var data = _cart.GetCartItemById(id); 
               var itemdata = _Ritem.GetRepoItemById(id);
               if(itemdata.QuantitySold <= Quantity){
                   itemdata.QuantitySold -= itemdata.QuantitySold;
                   _Ritem.SaveChanges();
               }else{   
                   itemdata.QuantitySold -= Quantity;
                   _Ritem.SaveChanges();
               }
               
               data.Quantity -= Quantity;
               
               if (data.Quantity == 0)
               {
                   _cart.Remove(data);
               }
               _cart.SaveChanges();
               return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            } 

            
              
            
        }
        public IActionResult StockManage()
        {
            var data =  _Ritem.GetAllRepoItems();
            return View(data);
        }

        public IActionResult test(){
            var data = _cartPurch.get_current_cartnum().ToString();
            return Content(data);
        }

    }
}
