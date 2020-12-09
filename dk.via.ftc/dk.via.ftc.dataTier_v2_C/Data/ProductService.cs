using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Persistence;
using Microsoft.EntityFrameworkCore;


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
        public async Task<Product> GetProductAsyncByStrain(int strain_id)
        {

            foreach (Product product in fTCDBContext.Products)
            {
                if (product.StrainId == strain_id)
                {
                    return product;
                }

                Console.WriteLine(product.ProductName);
            }

            return null;

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
            Console.WriteLine("updated");
            await fTCDBContext.SaveChangesAsync();
        }
    }
}