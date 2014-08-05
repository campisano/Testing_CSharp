using NLayer.Domain.Service;
using NLayer.Common.Pattern.Command;
using System.Collections.Generic;

namespace NLayer.Presentation
{
    public class CustomerSearchPresenter
    {
        private ICustomerSearchView _view;

        #region Constructors

        public CustomerSearchPresenter(ICustomerSearchView view)
        {
            _view = view;
            _view.DoReset = new SimpleCommand(ShowAllCustomersOperation);
            _view.DoSearch = new SimpleCommand(SearchCustomerOperation);
            _view.SearchQuery = "";
            _view.SearchResults = new List<string>();

            _view.DoReset.Execute();
        }

        #endregion

        #region Methods

        public void ShowAllCustomersOperation()
        {
            _view.SearchResults = CustomerService.Instance.GetAllCustumers();
        }

        public void SearchCustomerOperation()
        {
            _view.SearchResults = CustomerService.Instance.SearchCustomer(_view.SearchQuery);
        }

        #endregion
    }
}
