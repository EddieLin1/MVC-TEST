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
        public IActionResult OrderCreate(int CartId)
        {
            var temp = new Order();
            temp.CartId = CartId;
            return View(temp);
        }
        //int CartId, int UserId, string FirstName, string LastName, string Address, string City, string State_Province, string PostalCode, string Country, string Phone, string Email
        public IActionResult OrderCreateConfirmed(Order order)
        {
           
           if(ModelState.IsValid){
                Order newO = order;
                /*newO.CartId = CartId;
                newO.UserId = UserId;
                newO.FirstName = FirstName;
                newO.LastName = LastName;
                newO.Address = Address;
                newO.City = City;
                newO.State_Province = State_Province;
                newO.PostalCode = PostalCode;
                newO.Country = Country;
                newO.Phone = Phone;
                newO.Email = Email; */
                
                _OrderList.AddNew(newO);
                _OrderList.SaveChanges();
                return RedirectToAction("Index", "Store", "");
            }else{ 
            return View("failed", order);
            }
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