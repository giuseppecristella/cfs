using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;

namespace Shop.Core.BusinessDelegate
{
    public partial class BusinessDelegate
    {
        public Customer GetCustomerById(int id)
        {
            return _repository.GetCustomerById(id);
        }

        public List<CustomerAddress> GetCustomerAddresses(int customerId)
        {
            return _repository.GetCustomerAddresses(customerId);
        }
    }
}
