using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcStore.Data;
using MvcStore.Models;
using MvcStore.Repo;
using MvcStore.Interface;

namespace MvcStore.Controllers
{
    public class PetController : Controller
    {
        private readonly MvcStoreContext _context;
        private readonly IItemRepository _Ritem;
        private readonly IShoppingCartRepository _cart;
        private readonly PetRepo _PetRepo = new PetRepo();



        public PetController(MvcStoreContext context, IItemRepository item, IShoppingCartRepository cart)
        {
            _context = context;
            _Ritem = item;
            _cart = cart;
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
            return View(data);
        }

        // GET: Pet/Details/5
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

        // GET: Pet/Create
        public IActionResult Create(int id) //this page is not showing and i am not sure why
        {
            
            var data = _Ritem.GetRepoItemById(id);
            CartItem temp = new CartItem();
            temp.item = data;
            temp.ItemId = data.Id;

            return View(temp);

        }

        // POST: Pet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfrimed(int id, int Quantity)
        {
            if (_cart.GetCartItemById(id) != null)
            {
               var item = _Ritem.GetRepoItemById(id); 
                item.QuantitySold += Quantity;
               _Ritem.SaveChanges();
               return RedirectToAction(nameof(Index));
            } 
            else
            {
                var item = _Ritem.GetRepoItemById(id);
                item.QuantitySold += Quantity -1;
                _cart.Add(item, Quantity);
                _cart.SaveChanges();
                return RedirectToAction(nameof(Index));
            } 
        }

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

        // GET: Pet/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int Quantity)
        {
            
               var pet = _context.Pet.Find(id); 
               pet.sub_Quantity(Quantity);
               if (pet.Quantity == 0)
               {
                   _context.Pet.Remove(pet);
               }
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
            
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.Id == id);
        }
    }
}
