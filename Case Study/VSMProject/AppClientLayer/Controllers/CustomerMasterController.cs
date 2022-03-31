using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
 
namespace AppClientLayer.Controllers
{
    [Route("CustomerMaster/")]
    public class CustomerMasterController : Controller
    {
        // GET: CustomerMaster
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<ActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50594/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get customers
                HttpResponseMessage response = await client.GetAsync("GetCustomers");

                if (response.IsSuccessStatusCode)
                {
                    var customers = await response.Content.ReadAsAsync<CustomerMaster[]>();
                    return View(customers);
                }else
                {
                    return Content("No Data");
                }
            }
        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<ActionResult> GetCustomerById(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50594/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync($"GetById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var cust = await response.Content.ReadAsAsync<CustomerMaster>();

                    return View(cust);
                }
                else
                {
                    return Content("No Data");
                }

            }
        }

        [HttpPost]
        [Route("SaveCustomer")]
        public async Task<ActionResult> SaveCustomer(CustomerMaster customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50594/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PostAsJsonAsync("SaveCustomer", customer);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllCustomer");
                }
                else
                {
                    return View("SaveCustomer");
                }

            }
        }

        [HttpPost]
        [Route("DeleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(int CustId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50594/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync($"DeleteCustomer/{CustId}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("DeleteCustomer");
                }
                else
                {
                    return View("DeleteCustomer");
                }

            }

        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer(CustomerMaster customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50594/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateCustomer", customer);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllCustomer");
                }
                else
                {
                    return View("UpdateCustomer");
                }

            }
        }
    }
}