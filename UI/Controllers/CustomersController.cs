using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using Domain;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace UI.Controllers
{
    public class CustomersController : Controller
    {
        ApiInitializer _initializer = new ApiInitializer();
        // GET: Customers
        public async Task<ActionResult> Index()
        {
            List<Customer> customers = new List<Customer>();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Customers");
            if (response.IsSuccessStatusCode) {
                var result = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(result);
            }

            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Customer customer = new Customer();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Customers/" + $" { id} ");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Create(Customer body)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = _initializer.initial();
                //Convert body to Json Type
                //var test = body.ToDictionary();
                string contents = JsonConvert.SerializeObject(body);


                HttpResponseMessage response = await client.PostAsJsonAsync("api/Customers/", body);


               

                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("api/Customers", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["State"] = "Successfully created";
                   
                    return RedirectToAction("Index");
                   
                }

                return Content(response.ToString());
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["State"] = "Failed";
                return View();
            }
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Customer customer = new Customer();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Customers/" + $" { id} ");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer body)
        {
            try
            {
                // TODO: Add update logic here

                HttpClient client = _initializer.initial();
                //Convert body to Json Type
                //var test = body.ToDictionary();
                string contents = JsonConvert.SerializeObject(body);


                HttpResponseMessage response = await client.PutAsJsonAsync("api/Customers/" + $" { id} ", body);




                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("api/Customers", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["State"] = "Successfully Edited";
                    return RedirectToAction(nameof(Index));
                }

                return Content(response.ToString());
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["State"] = "Failed";
                return View();
            }
         
        }

        //[HttpGet]
        //GET: Customers/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        //POST: Customers/Delete/5
        [HttpGet]
        /*[ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                // TODO: Add delete logic here
                HttpClient client = _initializer.initial();

                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.DeleteAsync("api/Customers/" + $" { id} ");
                if (response.IsSuccessStatusCode)
                {
                    TempData["State"] = "Successfully Deleted";
                    return RedirectToAction(nameof(Index));
                }
                TempData["State"] = "Failed";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["State"] = "Failed";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}