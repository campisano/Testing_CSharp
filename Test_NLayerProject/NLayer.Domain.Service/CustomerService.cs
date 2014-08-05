using NLayer.Domain.Repository;
using System.Collections.Generic;

namespace NLayer.Domain.Service
{
    public class CustomerService
    {
        private static CustomerService _instance;

        #region Properties

        public ICustomerRepository Repository { private get; set; }

        public static CustomerService Instance
        {
            get { if (_instance == null) _instance = new CustomerService(); return _instance; }
        }

        #endregion

        #region Constructors

        private CustomerService()
        {
        }

        #endregion

        #region Methods

        public IList<string> SearchCustomer(string query)
        {
            return Repository.SearchCustomer(query);
        }

        public IList<string> GetAllCustumers()
        {
            return Repository.GetAllCustumers();
        }

        #endregion
    }
}
