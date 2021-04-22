using System.Collections.Generic;
using System.Web;
using MvcStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStore.Interface;
using MvcStore.Data;
using System.Linq;

namespace MvcStore.Models
{
    public class Order
    {
        public int OrderId {get; set;}
        public string FirstName  { get; set; }
        public string LastName   { get; set; }
        public string Address    { get; set; }
        public string City       { get; set; }
        public string State_Province  { get; set; }
        public string PostalCode { get; set; }
        public string Country    { get; set; }
        public string Phone      { get; set; }
        public string Email      { get; set; }

        public float Total     { 
            get{return OrderCart.CartTotal;}
        }
        [NotMapped]
        public Cart OrderCart {get; set;}

    }
}