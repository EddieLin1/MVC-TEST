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

        

    }
}