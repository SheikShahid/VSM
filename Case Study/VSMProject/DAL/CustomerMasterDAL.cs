using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerMasterDAL : ICustomerMasterRepository<CustomerMaster>
    {
        public bool DeleteCustomer(int CustId)
        {

            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var customer = dbContext.CustomerMasters.Where(x => x.CustId ==  CustId).FirstOrDefault();
                    dbContext.CustomerMasters.Remove(customer);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<CustomerMaster> GetAllCustomer()
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var customers = dbContext.CustomerMasters.ToList();
                    return customers;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerMaster GetCustomerById(int CustId)
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var customer = dbContext.CustomerMasters.Where(x => x.CustId == CustId).FirstOrDefault();
                    return customer;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveCustomer(CustomerMaster customerMaster)
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    dbContext.CustomerMasters.Add(customerMaster);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCustomer(CustomerMaster customerMaster)
        {
            try
            {
                using (VSMEntities dbContext = new VSMEntities())
                {
                    var oldCustomer = dbContext.CustomerMasters.Where(x => x.CustId == customerMaster.CustId).FirstOrDefault();
                    oldCustomer.CustId = customerMaster.CustId;
                    oldCustomer.FirstName = customerMaster.FirstName;
                    oldCustomer.LastName = customerMaster.LastName;
                    oldCustomer.Country = customerMaster.Country;
                    oldCustomer.State = customerMaster.State;
                    oldCustomer.City = customerMaster.City;
                    oldCustomer.ContactNo = customerMaster.ContactNo;
                    oldCustomer.Email = customerMaster.Email;
                    dbContext.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
