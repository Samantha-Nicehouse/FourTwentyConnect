﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        private FTCDBContext fTCDBContext;

        public ProductService(FTCDBContext context)
        {
            fTCDBContext = context;
        }
        public async Task<IList<Product>> GetProductsAsyncByStrain(int strain_id)
        {

            IQueryable<Product> products = fTCDBContext.Products.Where(p => p.StrainId.Equals(strain_id)); // Todo: .Include("Strains"); When its relation is implemented;
            return products.ToList();

        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            List<Product> products;
            products = fTCDBContext.Products.ToList();
            await fTCDBContext.SaveChangesAsync();

            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            fTCDBContext.Update(product);
            Console.WriteLine(product.ProductName + " Updated");
            await fTCDBContext.SaveChangesAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            fTCDBContext.Products.Add(product);
            
            await fTCDBContext.SaveChangesAsync();
            
            Console.WriteLine(product.ProductName + " Added To DB");
        }
        
        public async Task AddProductsAsync(List<Product> products)
        {
            foreach (Product product in products)
            {
                
                if (!fTCDBContext.Products.Where(e => e.ProductId.Equals(product.ProductId)).Any())
                {
                    fTCDBContext.Products.Add(product);
                    Console.WriteLine(product.ProductId + " Added To DB");
                }
                else
                {
                    Console.WriteLine(product.ProductId + " Already exists!!");
                    
                }
                await fTCDBContext.SaveChangesAsync();
            }
        }
    }
}