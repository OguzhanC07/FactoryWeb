using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryWebAPI.Client.Models;

namespace FactoryWebAPI.Client.ApiServices.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetByIdProductAsync(int id);
        Task<bool> AddProductAsync(ProductAddModel model);
        Task<string> UpdateProductAsync(ProductUpdateModel model);
        Task<string> DeleteProductAsync(int id);
    }
}