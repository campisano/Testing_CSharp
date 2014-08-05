using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer.Domain.Repository;
using NLayer.Domain.Service;
using NLayer.Presentation;
using NLayer.Test.Mock;
using System.Collections.Generic;

namespace NLayer.Test.Test
{
    //from http://msdn.microsoft.com/en-us/magazine/cc188690.aspx

    [TestClass]
    public class ViewCustomerPresenterTest
    {
        [TestMethod]
        public void ShouldViewDoSearchReturnCustomers()
        {
            List<string> customers = new List<string>();
            customers.Add("Agremis");
            customers.Add("Bruno");
            customers.Add("Riccardo");
            customers.Add("Robert");
            customers.Add("Rodrigo");
            customers.Add("Michel");
            InMemoryCustomerRepository repository = new InMemoryCustomerRepository(customers);
            CustomerService.Instance.Repository = repository;

            ICustomerSearchView mockCustomerSearchView = new CustomerSearchViewMock();
            {
                CustomerSearchPresenter presenter = new CustomerSearchPresenter(mockCustomerSearchView);
            }

            Assert.AreEqual(customers.Count, mockCustomerSearchView.SearchResults.Count);
            CollectionAssert.AreEqual(customers, (List<string>)mockCustomerSearchView.SearchResults);
        }

        //TODO [BSA]: dividir o test em unidades base (service / presenter / view)
    }
}
