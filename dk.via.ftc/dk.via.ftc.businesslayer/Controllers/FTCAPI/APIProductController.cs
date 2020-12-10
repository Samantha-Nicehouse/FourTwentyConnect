using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Data.FTCAPI;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dk.via.ftc.businesslayer.Controllers.FTCAPI
{
    [Route("ftc/api")]
    [ApiController]
    public class APIProductController : ControllerBase

    {
        private IAPIProductService _productService;

        public APIProductController(IAPIProductService _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        [Route("{apikey}/Products/Strain/{strain_id}")]
        public async Task<ActionResult<IList<Product>>> GetProductByStrain([FromRoute] string apikey,[FromRoute] int strain_id)
        {
            try
            {
                Console.WriteLine(strain_id + " GET REQUEST "+apikey);
                IList<Product> products = await _productService.GetProductsAsyncByStrain(strain_id);
                string strOut = JsonConvert.SerializeObject(products);
                if (products != null)
                    return Ok(strOut);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{apikey}/Products/Vendor/{vendorId}")]
        public async Task<ActionResult<IList<Product>>>
            GetProductsByVendor([FromRoute] string apikey,[FromRoute] string? vendorId)

        {
            IList<Product> products;
            try
            {
                if (vendorId != null)
                {
                    Console.WriteLine("GET REQUEST BY VENDOR apikey " + apikey);
                    IList<Product> filteredProducts = await _productService.GetProductsAsync();
                    products = filteredProducts.Where(p =>
                        p.VendorId.Equals(vendorId)).ToList();
                }
                else
                {
                    return NotFound();
                }
                string strOut = JsonConvert.SerializeObject(products);
                return Ok(strOut);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{apikey}/Products/All")]
        public async Task<ActionResult<IList<Product>>>
            GetProductsAll([FromRoute] string apikey)

        {
            try
            {
                Console.WriteLine("GET REQUEST BY ALL Products apikey " + apikey);
                IList<Product> products = await _productService.GetProductsAsync();
                string strOut = JsonConvert.SerializeObject(products);
                return Ok(products);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /*[HttpPatch] //only updates attributes that have changed
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
        [Route("Product/Put")]
        public async Task<ActionResult> PutProduct([FromRoute] Product product)
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
        }*/ //Todo: Implement updateProduct, addProduct fully
    }
}