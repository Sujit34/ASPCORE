using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIAutofac.Model;

namespace DIAutofac.Service
{
    public interface ITestService
    {
        List<TestModel> GettestList();
    }
}
