using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace AppServiceLayer.Controllers
{
    [Route("api/CustomerMaster")]
    public class CustomerMasterController : ApiController
    {
        CustomerMasterDAL customerMasterDAL = new CustomerMasterDAL();
        [HttpGet]
        [Route("GetCustomers")]
        public HttpResponseMessage GetAllCustomer()
        {
           var customers =  customerMasterDAL.GetAllCustomer();
            return Request.CreateResponse(HttpStatusCode.OK, customers);    
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public HttpResponseMessage GetCustomerById(int CustId)
        {
            var customer = customerMasterDAL.GetCustomerById(CustId);
            return Request.CreateResponse(HttpStatusCode.OK,customer);
        }

        [HttpPost]
        [Route("SaveCustomer")]
        public HttpResponseMessage SaveCustomer([FromBody]CustomerMaster saveCustomer)
        {
            customerMasterDAL.SaveCustomer(saveCustomer);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{CustId}")]
        public HttpResponseMessage DeleteCustomer(int CustId)
        {
            customerMasterDAL.DeleteCustomer(CustId);
            return Request.CreateResponse(HttpStatusCode.Gone);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public HttpResponseMessage UpdateCustomer([FromBody]CustomerMaster updateCustomer)
        {
            customerMasterDAL.UpdateCustomer(updateCustomer);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
