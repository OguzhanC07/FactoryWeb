using System.Threading.Tasks;

namespace FactoryWebAPI.Client.ApiServices.Interfaces
{
    public interface IImageService
    {
        Task<string> GetProductImageById(int id);
        Task<string> GetProfileImageById(int id);
    }
}