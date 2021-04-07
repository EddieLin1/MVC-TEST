using System.Collections.Generic;
using System.Web;
using MvcStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStore.Interface;

namespace MvcStore.Models
{    public class Cart
    {
        [NotMapped]
        public List<CartItem> ShoppingCart {get; set;}
        private readonly IShoppingCartRepository _CartRepo;
        public Cart(IShoppingCartRepository repository) {
            _CartRepo = repository;
        }
        public Cart(){
            
        }
        public void Add(CartItem toAdd){
            ShoppingCart.Add(toAdd);
        }
        

    }
}