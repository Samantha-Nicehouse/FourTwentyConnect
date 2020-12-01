using System;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Persistence;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class ProductService : IProductService
    {
        public async Task<Product> GetProductAsync(int strain_id)
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
    }
}