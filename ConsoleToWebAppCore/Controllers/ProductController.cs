using ConsoleToWebAppCore.Models;
using ConsoleToWebAppCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository1;
        private readonly IProductRepository _productRepository2;

        public ProductController(IProductRepository productRepository1, IProductRepository productRepository2)
        {
            _productRepository1 = productRepository1;
            _productRepository2 = productRepository2;
        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody]ProductModel model)
        {
            _productRepository1.AddProduct(model);
            var products = _productRepository2.GetProducts();
            return Ok(products);
        }

        [HttpGet("")]
        public IActionResult GetName()
        {            
            var name = _productRepository1.GetName();
            return Ok(name);
        }
    }
}
