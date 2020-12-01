using System;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Data;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/[controller]")]
    public class ProductController: ControllerBase

    {
        private IProductService _productService;
        
        public ProductController(IProductService _productService)
        {
            this._productService = _productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int strain_id)
        {
            try
            {
                Product product = await _productService.GetProductAsync(strain_id);
                if(product != null)
                return Ok(product);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        
    }
}