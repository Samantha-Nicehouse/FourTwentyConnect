using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <summary>
        /// Gets Products by Strain ID
        /// </summary>
        /// <param name="strain_id"></param>  
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
        /// <summary>
        /// Gets Products by Vendor Id
        /// </summary>
        /// <param name="vendorId"></param>  
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
        
        /// <summary>
        /// Gets All Of The Products
        /// </summary>
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
        /// <summary>
        /// Updates Specific Product by Product Id.
        /// </summary>
        /// <param name="id"></param>  
        [HttpPatch] //only updates attributes that have changed
        [Route("{apikey}/Products/Patch/{id}")]
        public async Task<ActionResult> updateProduct([FromBody] Product product,[FromRoute] string apikey,[FromRoute] int id)
        {
            try
            {
                if (id == product.ProductId)
                {
                    await _productService.UpdateProduct(product);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        /// <summary>
        /// Adds a new Product.
        /// </summary>
        /// <param name="id"></param>  
        [HttpPost]
        [Route("{apikey}/Products/Post")]
        public async Task<ActionResult> PostProduct([FromBody] Product product)
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
        /// <summary>
        /// Adds a new Product.
        /// </summary>
        /// <param name="id"></param>  
        [HttpPost]
        [Route("{apikey}/Products/List")]
        public async Task<ActionResult> PostProducts([FromBody] List<Product> products)
        {
            try
            {
                await _productService.AddProductsAsync(products);
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