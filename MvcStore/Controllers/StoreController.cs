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

        /*// GET: Pet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }
*/
        // GET: Pet/Create
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
                    _cart.AddNew(item, Quantity, _cart.CurrentCartNum(_cartPurch.PurchaseCheckInit()));
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
        
        
/*
        // GET: Pet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        } 

        // POST: Pet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Desc")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }
*/
        // GET: Pet/Delete/5
        public IActionResult Delete(int id)
        {

            var data = _cart.GetCartItemById(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: Pet/Delete/5
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

/*
        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.Id == id);
        } */
    }
}
