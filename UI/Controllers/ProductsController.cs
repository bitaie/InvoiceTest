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
    public class ProductsController : Controller
    {
        ApiInitializer _initializer = new ApiInitializer();
        // GET: Products
        public async Task<ActionResult> Index()
        {
            List<Product> Products = new List<Product>();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Products");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Products = JsonConvert.DeserializeObject<List<Product>>(result);
            }

            return View(Products);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Product Product = new Product();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Products/" + $" { id} ");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Product = JsonConvert.DeserializeObject<Product>(result);
            }
            return View(Product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Create(Product body)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = _initializer.initial();
                //Convert body to Json Type
                //var test = body.ToDictionary();
                string contents = JsonConvert.SerializeObject(body);


                HttpResponseMessage response = await client.PostAsJsonAsync("api/Products/", body);




                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("api/Products", content);
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

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Product Product = new Product();
            HttpClient client = _initializer.initial();
            HttpResponseMessage response = await client.GetAsync("api/Products/" + $" { id} ");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Product = JsonConvert.DeserializeObject<Product>(result);
            }
            return View(Product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product body)
        {
            try
            {
                // TODO: Add update logic here

                HttpClient client = _initializer.initial();
                //Convert body to Json Type
                //var test = body.ToDictionary();
                string contents = JsonConvert.SerializeObject(body);


                HttpResponseMessage response = await client.PutAsJsonAsync("api/Products/" + $" { id} ", body);




                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpResponseMessage response = await client.PostAsync("api/Products", content);
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
        //GET: Products/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        //POST: Products/Delete/5
        [HttpGet]
        /*[ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                // TODO: Add delete logic here
                HttpClient client = _initializer.initial();

                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.DeleteAsync("api/Products/" + $" { id} ");
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