using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;

namespace dk.via.ftc.web.Data
{
    public interface IProductService
    {
        public Task<IList<ProductStrain>> GetProductsAllProductsAsync();
    }
}