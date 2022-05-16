using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


//IEnumerable<Product> products = orm.GetProducts()
//var prodsOver25 = products.Where(p=>p.Cost >= 25)
//result in a query "select * from product"


//IQueryable<Product> products = orm.GetProducts()
//var prodsOver25 = products.Where(p=>p.Cost >= 25)
//result in a query "select * from product Where Costo >=25"

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private ProductsDBContext productsContext;

        public ProductsController(ProductsDBContext context)
        {
            productsContext = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public IActionResult Get(String? sortByName, int? pageNumber)
        {
            IQueryable<Product> sortedProducts;
            IQueryable<Product> pagingProducts;
            int currentPageNumber = pageNumber ?? 1;
            int pagesize = 10;


            switch (sortByName)
            {
                case "desc":
                    sortedProducts = productsContext.Products.OrderByDescending(p => p.productName);
                    pagingProducts = sortedProducts.Skip((currentPageNumber - 1) * pagesize).Take(pagesize);
                    break;

                case "asc":
                    sortedProducts = productsContext.Products.OrderByDescending(p => p.productName);
                    pagingProducts = sortedProducts.Skip((currentPageNumber - 1) * pagesize).Take(pagesize);
                    break;

                default:
                    sortedProducts = productsContext.Products.OrderByDescending(p => p.productName);
                    pagingProducts = sortedProducts.Skip((currentPageNumber - 1) * pagesize).Take(pagesize);
                    break;
            }
            return Ok(pagingProducts);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var product = productsContext.Products.Find(id);

            if (product == null)
            {
                return NotFound("There's no product with ID provided");
            }
            else
            {
                return Ok(product);
            }

        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            productsContext.Products.Add(product);
            productsContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product product)
        {
            var uProduct = productsContext.Products.Find(id);
            if (uProduct == null)
            {
                return NotFound("There's no product with ID provided");
            }
            else
            {
                uProduct.productName = product.productName;
                uProduct.quantity = product.quantity;
                uProduct.productImage = product.productImage;
                productsContext.SaveChanges();
                return Ok("Product updated successfully...");
            }

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var dProduct = productsContext.Products.Find(id);

            if (dProduct == null)
            {
                return NotFound("There's no product with ID provided");
            }
            else
            {
                productsContext.Products.Remove(dProduct);
                productsContext.SaveChanges();
                return Ok("Product deleted successfully..");
            }

        }



        //int departmentCode or Id
        //h ttps://localhost:44345/api/Products/byDept?pageNumber=2
        //[HttpGet("[action]/")]
        //public IActionResult byDept(int? pageNumber, int? departmentId)
        //{
        //    IQueryable<Product> sortedProducts;
        //    IQueryable<Product> pagingProducts;
        //    int currentPageNumber = pageNumber ?? 1;
        //    int pagesize = 10;

        //    sortedProducts = productsContext.Products.Where(p => p.productName.Contains(departmentId));
        //    sortedProducts = sortedProducts.OrderByDescending(p => p.productName);
        //    pagingProducts = sortedProducts.Skip((currentPageNumber - 1) * pagesize).Take(pagesize);

        //    return Ok(pagingProducts);
        //}


    }
}
