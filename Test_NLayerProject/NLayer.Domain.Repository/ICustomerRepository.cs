using System.Collections.Generic;

namespace NLayer.Domain.Repository
{
    public interface ICustomerRepository
    {
        IList<string> SearchCustomer(string query);
        IList<string> GetAllCustumers();
    }
}
