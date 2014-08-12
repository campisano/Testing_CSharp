using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class CustomerSearchPresenter
    {
        private CustomerService _service;
        private ICustomerSearchView _view;

        #region Constructors

        public CustomerSearchPresenter(ICustomerSearchView view)
        {
            _service = CustomerService.Instance;
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
            _view.SearchResults.Clear();

            foreach (var item in _service.GetAllCustumers())
            {
                _view.SearchResults.Add(item);
            }
        }

        public void SearchCustomerOperation()
        {
            _view.SearchResults.Clear();

            foreach (var item in _service.SearchCustomer(_view.SearchQuery))
            {
                _view.SearchResults.Add(item);
            }
        }

        #endregion
    }
}
