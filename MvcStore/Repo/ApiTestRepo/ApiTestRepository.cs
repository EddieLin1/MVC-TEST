using MvcStore.Data;
using MvcStore.Models.ApiTestModel;
using System.Collections.Generic;
using System.Linq;
using MvcStore.Interface.IApiTestInterface;
using Microsoft.EntityFrameworkCore;

// crud operations GET(read), POST(create), PUT(update), DELETE(delete)
// in order to fix error have to create new migration type
namespace MvcStore.Repo.ApiTestRepo
{
    public class ApiTestRepository : IApiTestRepository
    {
        private readonly StoreDBContext _context;

        public ApiTestRepository(StoreDBContext context){
            _context = context;
        }

        public IEnumerable<ApiTest> getAllApiTest(){
            return _context.ApiTest.ToList();
        }
        
        public void addApiTest(ApiTest model){
            _context.ApiTest.Add(model);
            SaveChanges();
        }

        public void updateApiTest(ApiTest model){
            var upd = _context.ApiTest.Find(model.Id);
            upd.message = model.message;
            if (upd != null) {
                _context.ApiTest.Update(upd);
            }else{
                addApiTest(model);
            }
            SaveChanges();
        }

        public void deleteApiTest(int Id){
            var del =  _context.ApiTest.Find(Id);
            if (del != null) {
                _context.ApiTest.Remove(del);
            }
            SaveChanges();
        }

        public void SaveChanges(){
            _context.SaveChanges();
        } 
    }
}