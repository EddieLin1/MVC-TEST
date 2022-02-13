using Microsoft.AspNetCore.Mvc;
using MvcStore.Models.ApiTestModel;
using System.Collections.Generic;
using MvcStore.Interface.IApiTestInterface;

// this file is used for Postman api testing, not for use in store application
//  TO DO: w/ postman
// build a new sql database for testing
// build new model and repository for testing
// create CRUD operations for testing
namespace MvcStore.Controllers
{
    [Produces("applications/json")]
    [Route("api/Test")]

    public class ApiTestController : Controller
    {
        private readonly IApiTestRepository _ApiTest;
        public ApiTestController(IApiTestRepository ApiTest)
        {
            _ApiTest = ApiTest;
        }

        [Route("~/api/GetAllApiTest")]
        [HttpGet]
        public IEnumerable<ApiTest> GetAllApiTest(){
            return _ApiTest.getAllApiTest();
        }

        [Route("~/api/AddApiTest")]
        [HttpPost]
        public void AddApiTest(ApiTest model){
            _ApiTest.addApiTest(model);
        }

        [Route("~/api/UpdateApiTest")]
        [HttpPost]
        public void UpdateApiTest(ApiTest model){
            _ApiTest.updateApiTest(model);
        }

        [Route("~/api/DeleteApiTest/{id}")]
        [HttpDelete]
        public void DeleteApiTest(int Id){
            _ApiTest.deleteApiTest(Id);
        }


    }
}