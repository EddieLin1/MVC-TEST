using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcStore.Models
{
    public class OrderList
    {
        [NotMapped]
        public List<Order> _OrderList {get; set;}
    }
}