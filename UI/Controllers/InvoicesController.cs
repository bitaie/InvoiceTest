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
using UI.ViewModels;

namespace UI.Controllers
{
    public class InvoicesController : Controller
    {
        ApiInitializer _initializer = new ApiInitializer();
        // GET: Invoices
        public async Task<ActionResult> Index()
        {
            List<Invoice> Invoices = new List<Invoice>();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Invoices");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Invoices = JsonConvert.DeserializeObject<List<Invoice>>(result);
            }

            return View(Invoices);
        }

        // GET: Invoices/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Invoice Invoice = new Invoice();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Invoices/" + $" { id} ");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Invoice = JsonConvert.DeserializeObject<Invoice>(result);
            }
            return View(Invoice);
        }

        // GET: Invoices/Create
<<<<<<< HEAD
        public async Task<ActionResult> Create(int id)
        {
            CreateInvoiceViewModel vm = new CreateInvoiceViewModel();
            HttpClient client = _initializer.initial();
            HttpResponseMessage customerResponse = await client.GetAsync("api/Customers/" + $" { id} ");
            HttpResponseMessage productsResponse = await client.GetAsync("api/ProductsList");
            if (customerResponse.IsSuccessStatusCode && productsResponse.IsSuccessStatusCode)
            {
                var customerResult = customerResponse.Content.ReadAsStringAsync().Result;
                string productsResult = productsResponse.Content.ReadAsStringAsync().Result;
                vm.Customer = JsonConvert.DeserializeObject<Customer>(customerResult);
                vm.Products = JsonConvert.DeserializeObject<List<string>>(productsResult);
                vm.Items = new List<Item>();
                vm.Item = new Item();
                //vm.Item.Price = 12;
                //vm.Item.Quantity = 12;
                //vm.Items.Add(vm.Item);
                //vm.Products = new List<Product>();
            }
=======
        public async Task<ActionResult> Create(int? id)
        {
            CreateInvoiceViewModel vm = new CreateInvoiceViewModel();
           
            HttpClient client = _initializer.initial();
            HttpResponseMessage customerResponse = await client.GetAsync("api/Customers/24008" );
            HttpResponseMessage productsResponse = await client.GetAsync("api/Products/" );
            if (customerResponse.IsSuccessStatusCode && productsResponse.IsSuccessStatusCode)
            {
                var customerResult = customerResponse.Content.ReadAsStringAsync().Result;
                var productsResult = productsResponse.Content.ReadAsStringAsync().Result;
                vm.customer = JsonConvert.DeserializeObject<Customer>(customerResult);
                vm.products = JsonConvert.DeserializeObject<List<Product>>(productsResult);
                vm.items = new List<Item>();
            }
            else
            {
                TempData["State"] = "Failed";
            }
            
>>>>>>> test_branch
            return View(vm);
        }

        // POST: Invoices/Create
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Create(Invoice body)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = _initializer.initial();
                //Convert body to Json Type
                //var test = body.ToDictionary();
                string contents = JsonConvert.SerializeObject(body);


                HttpResponseMessage response = await client.PostAsJsonAsync("api/Invoices/", body);




                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("api/Invoices", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["State"] = "Successfully created";

                    return RedirectToAction("Index");

                }

                return Content(response.ToString());
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["State"] = "Failed";
                return View();
            }
        }

        // GET: Invoices/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Invoice Invoice = new Invoice();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Invoices/" + $" { id} ");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Invoice = JsonConvert.DeserializeObject<Invoice>(result);
            }
            return View(Invoice);
        }

        // POST: Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Invoice body)
        {
            try
            {
                // TODO: Add update logic here

                HttpClient client = _initializer.initial();
                //Convert body to Json Type
                //var test = body.ToDictionary();
                string contents = JsonConvert.SerializeObject(body);


                HttpResponseMessage response = await client.PutAsJsonAsync("api/Invoices/" + $" { id} ", body);




                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("api/Invoices", content);
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
        //GET: Invoices/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        //POST: Invoices/Delete/5
        [HttpGet]
        /*[ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                // TODO: Add delete logic here
                HttpClient client = _initializer.initial();

                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.DeleteAsync("api/Invoices/" + $" { id} ");
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