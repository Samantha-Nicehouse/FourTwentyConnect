using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IList<Product>>> GetProductsByStrain([FromRoute]int strain_id)
        {
            try
            {
                Console.WriteLine(strain_id+" GET REQUEST");
                IList<Product> products = await _productService.GetProductsAsyncByStrain(strain_id);
                Console.WriteLine(JsonConvert.SerializeObject(products));
                if(products != null)
                return Ok(products);
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
        [HttpPost]
        [Route("Post")]
        public async Task PutProduct([FromBody]Product product)
        {
            
            await _productService.AddProductAsync(product);
        }
        [HttpPost]
        [Route("List")]
        public async Task PutProducts([FromBody]List<Product> products)
        {
            
            await _productService.AddProductsAsync(products);
        }

        [HttpPatch]
        [Route("Patch/{id}")]
        public async Task PatchProduct([FromRoute]Product product,[FromRoute]int id)
        {
            if (id == product.ProductId)
            {
                await _productService.UpdateProduct(product);
            }
        }
    }
}