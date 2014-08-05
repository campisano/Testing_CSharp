using System.Collections.Generic;
using System.Linq;

namespace NLayer.Domain.Repository
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private IList<string> _customers;

        #region Constructors

        public InMemoryCustomerRepository(IList<string> customers)
        {
            _customers = new List<string>();

            foreach (var customer in customers)
            {
                _customers.Add(customer);
            }
        }

        #endregion

        #region Methods

        public IList<string> SearchCustomer(string query)
        {
            return _customers.Where(c => c.Contains(query)).ToList();
        }

        public IList<string> GetAllCustumers()
        {
            return _customers;
        }

        #endregion
    }
}
