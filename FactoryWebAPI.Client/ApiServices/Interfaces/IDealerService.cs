using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryWebAPI.Client.Models;

namespace FactoryWebAPI.Client.ApiServices.Interfaces
{
    public interface IDealerService
    {
        Task<List<DealerListModel>> GetAllDealersAsync();
        Task<DealerListModel> GetDealerByIdAsync(int id);
        Task<List<DealerListModel>> GetDealersByAppUserId(int appUserId);
        Task AddDealerAsync(DealerAddModel model);
        Task UpdateDealerAsync(DealerListModel model);
        Task DeleteDealerAsync(int id);

    }
}