using Crow.Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crow.Shop.Services
{
    public interface IProductService
    {
        Task<List<ProductItem>> GetAll();
        Task<Product> Get(int id);
        Task Update(Product product);
        Task Create(Product product);
        Task Delete(int id);
        bool CheckIfExists(int id);
    }
}
