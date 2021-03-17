using System.Collections.Generic;
using System.Web;
using MvcStore.Models;

namespace MvcStore.Models
{
    public class Cart
    {
        public IEnumerable<Item> ShoppingCart {get; private set;}
        public static readonly Cart CartInitial;

        static Cart(){
            CartInitial = new Cart();
            CartInitial.ShoppingCart = new List<Item>();
        }
        public void AddItem(int ItemId){
            Item item_new = new Item(ItemId);
        }

    }
}