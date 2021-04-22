using System.Collections.Generic;
using System.Web;
using MvcStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStore.Interface;
using MvcStore.Data;
using System.Linq;

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