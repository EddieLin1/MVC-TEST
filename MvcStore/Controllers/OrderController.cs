using Microsoft.AspNetCore.Mvc;
using MvcStore.Interface;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _OrderList;
        public OrderController(IOrderRepository OrderList){
            _OrderList = OrderList;
        }
        public IActionResult OrderCreate(Cart model)
        {
            return RedirectToAction(nameof(OrderCreateConfirmed), model);
        }
        public IActionResult OrderCreateConfirmed(Cart model, string Fname, string Lname, string Address, string City, string State_Province, string PostalCode, string Country, string Phone, string Email)
        {
            return View();
        }
        public IActionResult DisplayOrder()
        {
            return View();
        }


    }
}