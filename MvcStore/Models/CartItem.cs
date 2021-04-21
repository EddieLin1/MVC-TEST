using System.Collections.Generic;
using System.Web;
using MvcStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStore.Interface;
using System.ComponentModel.DataAnnotations;

namespace MvcStore.Models
{
    public class CartItem
    {

        [NotMapped]
        public Item item {get; set;}
        public int Id {get; set;}
        public int ItemId{get; set;}
        [Range(1,100, ErrorMessage = "Please pick an int between 1-100")]
        public int Quantity {get; set;}
         
        public string Description {
            get {return item.Description; }
        }
        public float TotalPrice {
            get{return item.Price * Quantity; }
        }

    }

}