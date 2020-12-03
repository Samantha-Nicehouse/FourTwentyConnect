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

        public async Task<Product> GetProductAsyncByStrain(int strain_id)
        {
            using (FTCDBContext ftcdbContext = new FTCDBContext())
            {
                foreach (Product product in ftcdbContext.Products)
                {
                    if (product.StrainId == strain_id)
                    {
                        return product;
                    }

                    Console.WriteLine(product.ProductName);
                }

                return null;

            }
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            List<Product> products;
            using (FTCDBContext ftcdbContext = new FTCDBContext())
            {
                products = ftcdbContext.Products.ToList();
                await ftcdbContext.SaveChangesAsync();
            }

            return products;
        }

        public async Task UpdateProduct(Product product)
        {

            await using (FTCDBContext ftcdbContext = new FTCDBContext())
            {
                ftcdbContext.Update(product);
                Console.WriteLine("updated");
                await ftcdbContext.SaveChangesAsync();

            }
        }
    }
}

