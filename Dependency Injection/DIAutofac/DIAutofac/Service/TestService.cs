using DIAutofac.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAutofac.Service
{
    public class TestService : ITestService
    {
        public List<TestModel> GettestList()
        {
            List<TestModel> list = new List<TestModel>
            {
                 new TestModel { Id = 1, Name = "Test1" },
                 new TestModel { Id = 1, Name = "Test2" },
                 new TestModel { Id = 1, Name = "Test3" },
                 new TestModel { Id = 1, Name = "Test4" },
                 new TestModel { Id = 1, Name = "Test5" },
                 new TestModel { Id = 1, Name = "Test6" },
                 new TestModel { Id = 1, Name = "Test7" },
                 new TestModel { Id = 1, Name = "Test8" },
                 new TestModel { Id = 1, Name = "Test9" },
                 new TestModel { Id = 1, Name = "Test10" },
                 new TestModel { Id = 1, Name = "Test11" },
                 new TestModel { Id = 1, Name = "Test12" }

            };

            return list;           
        }
    }
}
