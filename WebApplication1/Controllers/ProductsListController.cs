using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsListController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsListController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        // GET: api/ProductsList
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _ProductService.GetAllProductList();
        }

        // GET: api/ProductsList/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsList
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ProductsList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
