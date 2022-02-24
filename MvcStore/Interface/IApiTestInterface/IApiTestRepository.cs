using System.Collections.Generic;
using MvcStore.Models.ApiTestModel;


namespace MvcStore.Interface.IApiTestInterface
{
    public interface IApiTestRepository
    {
        IEnumerable<ApiTest> getAllApiTest();
        void addApiTest(ApiTest model);
        void updateApiTest(ApiTest model);
        void deleteApiTest(int Id);

        void SaveChanges();
    }
}