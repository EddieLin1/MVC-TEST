using Microsoft.AspNetCore.Mvc;
using MvcStore.Models.ApiTestModel;
using System.Collections.Generic;
using MvcStore.Interface.IApiTestInterface;

// this file is used for Postman api testing, not for use in store application
//  TO DO: w/ postman
// build a new sql database for testing
// build new model and repository for testing
// create CRUD operations for testing
// displays and utilizes Json data for 
namespace MvcStore.Controllers
{
    [Produces("applications/json")]
    [Route("api/[controller]")]

    public class ApiTestController : Controller
    {
        private readonly IApiTestRepository _ApiTest;
        public ApiTestController(IApiTestRepository ApiTest)
        {
            _ApiTest = ApiTest;
        }

        public ActionResult Index(){
            return Content("works");
        }

        [Route("~/api/GetAllApiTest")]
        [HttpGet]
        public ActionResult GetAllApiTest(){
            return Json(_ApiTest.getAllApiTest());
        }

        [Route("~/api/AddApiTest")]
        [HttpPost]
        public void AddApiTest([FromBody]ApiTest model){
            _ApiTest.addApiTest(model);
        }

        [Route("~/api/UpdateApiTest")]
        [HttpPut]
        public void UpdateApiTest([FromBody]ApiTest model){
            _ApiTest.updateApiTest(model);
        }

        [Route("~/api/DeleteApiTest/{id}")]
        [HttpDelete]
        public void DeleteApiTest(int Id){
            _ApiTest.deleteApiTest(Id);
        }


    }
}