using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace MvcStore.Models
{    public class Cart
    {
        [Key]
        public double CartId {get; set;}
        //public double SessionId{get; set;}
        public Boolean? Purchased {get; set;} = null;
        
        public double CartTotal{ get; set;}
        [NotMapped]
        public List<CartItem> ShoppingCart {get; set;}
            

        public double _CartTotal(){
            double data = 0;
            foreach(CartItem item in ShoppingCart){
                data += item.TotalPrice;
            }
            return data;
        }

    }
}