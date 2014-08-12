using NLayer.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.Domain.InMemoryRepository
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private IList<string> _customers;

        #region Constructors

        public InMemoryCustomerRepository(IList<string> customers)
        {
            _customers = new List<string>();

            foreach (var item in customers)
            {
                _customers.Add(item);
            }
        }

        #endregion

        #region Methods

        public IEnumerable<string> SearchCustomer(string query)
        {
            return _customers.Where(c => c.Contains(query));
        }

        public IEnumerable<string> GetAllCustumers()
        {
            return _customers;
        }

        #endregion
    }
}
