using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface IProductService
    {
        public Task<Product> GetProductAsync(int strain_id);
    }
}