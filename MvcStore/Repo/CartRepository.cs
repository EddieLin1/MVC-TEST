using MvcStore.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Data;
using Microsoft.EntityFrameworkCore;
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
    }
}