using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcStore.Models
{    public class Cart
    {
        [NotMapped]
        public List<CartItem> ShoppingCart {get; set;}
        [NotMapped]
        public double CartTotal{
            get{return _CartTotal();}
            }

        public double _CartTotal(){
            double data = 0;
            foreach(CartItem item in ShoppingCart){
                data += item.TotalPrice;
            }
            return data;
        }

    }
}