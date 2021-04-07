using MvcStore.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;
using MvcStore.Models;

namespace MvcStore.Repo
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreDBContext _context;
        public ItemRepository(StoreDBContext context)
        {
            _context = context;
        }
         public IEnumerable<Item> GetAllRepoItems()
        {
            return _context.ItemsRepo.ToList();
        }
        public Item GetRepoItemById(int id)
        {
            return  _context.ItemsRepo.Find(id);
        }
        public void SaveChanges(){
            _context.SaveChanges();
        }
       /* public Cart GetAllRepoItemsCart()
        {
            Cart _temp = new Cart();
            var itemList = _context.ItemsRepo.ToList();
            foreach(var item in itemList){   
               
           }
            return ErrorViewModel;
        } */
        
    }
}