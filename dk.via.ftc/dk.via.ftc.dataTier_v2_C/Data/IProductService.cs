using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface IProductService
    {
        public Task<Product> GetProductAsyncByStrain(int strain_id);
        public Task<IList<Product>> GetProductsAsync();
        public Task UpdateProduct(Product product);
    }
}