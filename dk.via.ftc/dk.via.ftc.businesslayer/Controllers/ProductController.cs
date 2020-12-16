using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        // GET
        public ProductController(IProductService _productService)
        {
            this._productService = _productService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<ProductStrain>>> 
            GetProductsAll()

        {
            try
            {
                IList<ProductStrain> filteredProducts = await _productService.GetProductsAllProductsAsync();

                return Ok(filteredProducts);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}