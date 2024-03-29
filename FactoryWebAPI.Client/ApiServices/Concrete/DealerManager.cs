using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FactoryWebAPI.Client.ApiServices.Interfaces;
using FactoryWebAPI.Client.Extensions;
using FactoryWebAPI.Client.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FactoryWebAPI.Client.ApiServices.Concrete
{
    public class DealerManager : IDealerService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly HttpClient _httpClient;
        public DealerManager(IHttpContextAccessor accessor, HttpClient httpClient)
        {
            _accessor = accessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("http://localhost:58546/api/dealers/");
        }

        public async Task<List<DealerListModel>> GetAllDealersAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.GetAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<DealerListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<DealerListModel> GetDealerByIdAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.GetAsync($"{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<DealerListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DealerListModel>> GetDealersByAppUserId(int appUserId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.GetAsync($"GetDealersByAppUserId/{appUserId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<DealerListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task AddDealerAsync(DealerAddModel model)
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();

            formDataContent.Add(new StringContent(model.Name), nameof(model.Name));
            formDataContent.Add(new StringContent(model.Address), nameof(model.Address));
            formDataContent.Add(new StringContent(model.Email), nameof(model.Email));
            formDataContent.Add(new StringContent(model.PhoneNumber), nameof(model.PhoneNumber));

            var user = _accessor.HttpContext.Session.GetObject<AppUserViewModel>("activeUser");
            model.AppUserId = user.Id;
            formDataContent.Add(new StringContent(model.AppUserId.ToString()), nameof(model.AppUserId));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync("", formDataContent);

        }


        public async Task UpdateDealerAsync(DealerListModel model)
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();

            formDataContent.Add(new StringContent(model.Id.ToString()), nameof(model.Id));
            formDataContent.Add(new StringContent(model.Name), nameof(model.Name));
            formDataContent.Add(new StringContent(model.Address), nameof(model.Address));
            formDataContent.Add(new StringContent(model.Email), nameof(model.Email));
            formDataContent.Add(new StringContent(model.PhoneNumber), nameof(model.PhoneNumber));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"{model.Id}", formDataContent);
        }


        public async Task DeleteDealerAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));
        
            var responseMessage = await _httpClient.DeleteAsync($"{id}");
        }

    }
}