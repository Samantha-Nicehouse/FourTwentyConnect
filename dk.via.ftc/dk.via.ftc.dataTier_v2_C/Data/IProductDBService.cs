using dk.via.ftc.dataTier_v2_C.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface IProductDBService
    {
        public Task<IList<Product>> GetProductsAsyncByStrain(int strain_id);
        public Task<IList<Product>> GetProductsAsync();
        public Task UpdateProduct(Product product);
        public Task AddProductAsync(Product product);
    }
}