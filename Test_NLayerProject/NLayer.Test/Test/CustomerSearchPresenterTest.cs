using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer.Domain.InMemoryRepository;
using NLayer.Domain.Repository;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using NLayer.Test.Mock;
using System.Collections.Generic;

namespace NLayer.Test.Test
{
    //from http://msdn.microsoft.com/en-us/magazine/cc188690.aspx

    [TestClass]
    public class CustomerSearchPresenterTest
    {
        [TestMethod]
        public void ShouldViewOpenReturnAllCustomers()
        {
            List<string> customers = new List<string>();
            customers.Add("Agremis");
            customers.Add("Bruno");
            customers.Add("Riccardo");
            customers.Add("Robert");
            customers.Add("Rodrigo");
            customers.Add("Michel");
            ICustomerRepository repository = new InMemoryCustomerRepository(customers);
            CustomerService.Instance.Repository = repository;

            ICustomerSearchView view = new CustomerSearchViewMock();
            {
                CustomerSearchPresenter presenter = new CustomerSearchPresenter(view);
            }

            Assert.AreEqual(customers.Count, view.SearchResults.Count);
            CollectionAssert.AreEqual(customers, (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void ShouldViewDoSearchEmptyReturnAllCustomers()
        {
            List<string> customers = new List<string>();
            customers.Add("Agremis");
            customers.Add("Bruno");
            customers.Add("Riccardo");
            customers.Add("Robert");
            customers.Add("Rodrigo");
            customers.Add("Michel");
            ICustomerRepository repository = new InMemoryCustomerRepository(customers);
            CustomerService.Instance.Repository = repository;

            ICustomerSearchView view = new CustomerSearchViewMock();
            {
                CustomerSearchPresenter presenter = new CustomerSearchPresenter(view);
            }

            view.SearchQuery = string.Empty;
            view.DoSearch.Execute();

            Assert.AreEqual(customers.Count, view.SearchResults.Count);
            CollectionAssert.AreEqual(customers, (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void ShouldViewDoSearchAgremisReturnAgremis()
        {
            List<string> customers = new List<string>();
            customers.Add("Agremis");
            customers.Add("Bruno");
            customers.Add("Riccardo");
            customers.Add("Robert");
            customers.Add("Rodrigo");
            customers.Add("Michel");
            ICustomerRepository repository = new InMemoryCustomerRepository(customers);
            CustomerService.Instance.Repository = repository;

            ICustomerSearchView view = new CustomerSearchViewMock();
            {
                CustomerSearchPresenter presenter = new CustomerSearchPresenter(view);
            }

            view.SearchQuery = "Agremis";
            view.DoSearch.Execute();

            Assert.AreEqual(1, view.SearchResults.Count);
            Assert.AreEqual("Agremis", view.SearchResults[0]);
        }

        [TestMethod]
        public void ShouldViewResetAfterDoSearchReturnAllCustomers()
        {
            List<string> customers = new List<string>();
            customers.Add("Agremis");
            customers.Add("Bruno");
            customers.Add("Riccardo");
            customers.Add("Robert");
            customers.Add("Rodrigo");
            customers.Add("Michel");
            ICustomerRepository repository = new InMemoryCustomerRepository(customers);
            CustomerService.Instance.Repository = repository;

            ICustomerSearchView view = new CustomerSearchViewMock();
            {
                CustomerSearchPresenter presenter = new CustomerSearchPresenter(view);
            }

            view.SearchQuery = "Agremis";
            view.DoSearch.Execute();
            view.DoReset.Execute();

            Assert.AreEqual(customers.Count, view.SearchResults.Count);
            CollectionAssert.AreEqual(customers, (List<string>)view.SearchResults);
        }

        //TODO [BSA]: dividir o test em unidades base (service / presenter / view)
    }
}
