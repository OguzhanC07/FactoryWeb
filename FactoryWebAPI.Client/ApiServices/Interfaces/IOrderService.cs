using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryWebAPI.Client.Models;

namespace FactoryWebAPI.Client.ApiServices.Interfaces
{
    public interface IOrderService
    {
        Task<string> AddOrder(AddOrderModel model);
        Task<List<OrderDetailListModel>> GetAllOrders();
        Task<List<OrderDetailListModel>> GetAllOrdersByAppUserIdAsync(int id);
    }
}