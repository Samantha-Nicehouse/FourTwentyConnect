using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Data;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase

    {
        private IProductService _productService;
        
        public ProductController(IProductService _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        [Route("Strain/{strain_id}")]
        public async Task<ActionResult<Product>> GetProductByStrain(int strain_id)
        {
            try
            {
                Console.WriteLine(strain_id+" GET REQUEST");
                Product product = await _productService.GetProductAsyncByStrain(strain_id);
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
        
        [HttpGet]
        public async Task<ActionResult<IList<Product>>> 
            GetProductsByVendor([FromQuery] string? vendorId)

        {
            IList<Product> products;
            try
            {
                if (vendorId != null)
                {
                    IList<Product> filteredProducts = await _productService.GetProductsAsync();
                    products = filteredProducts.Where(p =>
                        p.VendorId == vendorId).ToList();
                }
                else
                {
                    return NotFound();
                }

                return Ok(products);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("Products/All")]
        public async Task<ActionResult<IList<Product>>> 
            GetProductsAll()

        {
            try
            {
                IList<Product> filteredProducts = await _productService.GetProductsAsync();

                return Ok(filteredProducts);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch] //only updates attributes that have changed
        public async Task<ActionResult> updateProduct([FromBody]Product product)
        {
            try
            {
                 await _productService.UpdateProduct(product);
                 return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}