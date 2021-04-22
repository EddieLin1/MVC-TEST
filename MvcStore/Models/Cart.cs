using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcStore.Models
{    public class Cart
    {
        [NotMapped]
        public List<CartItem> ShoppingCart {get; set;}
        [NotMapped]
        public float CartTotal{
            get{return _CartTotal();}
            }

        public float _CartTotal(){
            float data = 0;
            foreach(CartItem item in ShoppingCart){
                data += item.TotalPrice;
            }
            return data;
        }

    }
}