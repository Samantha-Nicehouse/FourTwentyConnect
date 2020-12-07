using dk.via.ftc.businesslayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.FTCAPI
{
    public interface IAPIProductService
    {
        public Task<IList<Product>> GetProductsAsyncByStrain(int strain_id);
        public Task<IList<Product>> GetProductsAsync();

        public Task UpdateProduct(Product product);

        public Task AddProductAsync(Product product);
    }
}
