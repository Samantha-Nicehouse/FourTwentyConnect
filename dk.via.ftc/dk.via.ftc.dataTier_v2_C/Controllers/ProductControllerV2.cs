using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Data;
using dk.via.ftc.dataTier_v2_C.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/Products")]
    [ApiController]
    public class ProductControllerV2 : ControllerBase

    {
        private IProductDBService _productService;

        public ProductControllerV2(IProductDBService _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        [Route("Strain/{strain_id}")]
        public async Task<ActionResult<IList<Product>>> GetProductByStrain([FromQuery]int strain_id)
        {
            try
            {
                Console.WriteLine(strain_id + " GET REQUEST");
                IList<Product> products = await _productService.GetProductsAsyncByStrain(strain_id);
                if (products != null)
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
        [Route("Vendor/{vendorId}")]
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
        [Route("All")]
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
        public async Task<ActionResult> updateProduct([FromBody] Product product)
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
        [HttpPut]
        [Route("Product/{strain_id}")]
        public async Task<ActionResult> PutStrain([FromRoute] Product product)
        {
            try
            {
                await _productService.AddProductAsync(product);
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