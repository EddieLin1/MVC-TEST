using Microsoft.AspNetCore.Mvc;
using MvcStore.Interface;
using MvcStore.Models;
using Microsoft.AspNetCore.Identity;

namespace MvcStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _OrderList;
        //private readonly SignInManager<IdentityUser> _signInManager;

        public OrderController(IOrderRepository OrderList){
            _OrderList = OrderList;
        }
        public IActionResult OrderCreate(Cart model)
        {
            var temp = new Order();
            return View(temp);
        }
        public IActionResult OrderCreateConfirmed(Cart model, string Fname, string Lname, string Address, string City, string State_Province, string PostalCode, string Country, string Phone, string Email)
        {
            return View();
        }
        public IActionResult DisplayOrder()
        {
            return View();
        }
        public IActionResult test(Cart model)
        {
            return View(model);
        }


    }
}