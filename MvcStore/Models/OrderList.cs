using System.Collections.Generic;
using System.Web;
using MvcStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStore.Interface;
using MvcStore.Data;
using System.Linq;

namespace MvcStore.Models
{
    public class OrderList
    {
        [NotMapped]
        public List<Order> _OrderList {get; set;}
    }
}