using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestJobApi.DataModels;
using TestJobApi.Repositories.Interface;

namespace TestJobApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpPost]
        [Authorize]
        [Route("api/Product/InsertProduct")]
        public IActionResult InsertProduct ([FromBody] Product model)
        {
            if (model == null)
                return BadRequest();


            var product = productRepository.InsertProduct(model);

            return CreatedAtAction("InsertProduct", product);
        }

    }
}
