using NLayer.Domain.Repository;
using System.Collections.Generic;

namespace NLayer.Domain.Service.SystemOperation
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

        #region public

        public IEnumerable<string> SearchCustomer(string query)
        {
            return Repository.SearchCustomer(query);
        }

        public IEnumerable<string> GetAllCustumers()
        {
            return Repository.GetAllCustumers();
        }

        #endregion

        #endregion
    }
}
