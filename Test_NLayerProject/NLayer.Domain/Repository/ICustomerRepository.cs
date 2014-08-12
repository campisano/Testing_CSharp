using System.Collections.Generic;

namespace NLayer.Domain.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<string> SearchCustomer(string query);
        IEnumerable<string> GetAllCustumers();
    }
}
