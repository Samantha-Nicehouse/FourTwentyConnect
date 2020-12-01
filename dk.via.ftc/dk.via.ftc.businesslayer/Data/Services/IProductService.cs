using dk.via.ftc.businesslayer.Models;
using System.Threading.Tasks;

namespace dk.via.businesslayer.Data.Services
{
    public interface IProductService
    {
        public Task<Product> GetProductAsyncByStrain(int strain_id);
    }
}