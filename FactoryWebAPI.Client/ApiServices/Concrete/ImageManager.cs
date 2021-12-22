using System;
using System.Net.Http;
using System.Threading.Tasks;
using FactoryWebAPI.Client.ApiServices.Interfaces;

namespace FactoryWebAPI.Client.ApiServices.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly HttpClient _httpClient;
        public ImageManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new System.Uri("http://localhost:58546/api/files/");
        }
        public async Task<string> GetProductImageById(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetImageByProductId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetProfileImageById(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetProfileImage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg:base64,{Convert.ToBase64String(bytes)}";
            }
            else
            {
                return null;
            }
        }
    }
}