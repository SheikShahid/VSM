using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICustomerMasterRepository<CustomerMaster>
    {
        IEnumerable<CustomerMaster> GetAllCustomer();
        CustomerMaster GetCustomerById(int CustId);
        bool SaveCustomer(CustomerMaster customerMaster);
        bool DeleteCustomer(int CustId);
        bool UpdateCustomer(CustomerMaster customerMaster);
    }
}
