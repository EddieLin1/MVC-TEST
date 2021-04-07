using System.Collections.Generic;
using System.Web;
using MvcStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStore.Interface;

namespace MvcStore.Models
{
    public class CartItem
    {

        [NotMapped]
        public Item item {get; set;}
        public int Id {get; set;}
        public int ItemId{get; set;}
        public int Quantity {get; set;}
        public string Description {
            get {return item.Description; }
        }
        public float TotalPrice {
            get{return item.Price * Quantity; }
        }

    }

}