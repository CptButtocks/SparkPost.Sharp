using Newtonsoft.Json;
using SparkPost.Sharp.Data.Interfaces;
using SparkPost.Sharp.Exceptions;
using SparkPost.Sharp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SparkPost.Sharp.Services.Abstract
{
    public abstract class SparkPostService
    {
        private readonly ISparkPostConfiguration _configuration;
        private readonly HttpClient _httpClient;

        protected string Host => _configuration.Host;
        protected string Key => _configuration.ApiKey;
        protected string SenderAddress => _configuration.SenderAddress;
        protected string SenderName => _configuration.SenderName;
        protected string ReplyTo => _configuration.ReplyTo;

        protected HttpClient Client => _httpClient;

        public SparkPostService(ISparkPostConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_configuration.Host)
            };

            string formattedApiKey = $"{_configuration.ApiKey}:";
            byte[] apiKeyBytes = Encoding.UTF8.GetBytes(formattedApiKey);
            string apiBase64 = Convert.ToBase64String(apiKeyBytes);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", apiBase64);
        }

        protected async Task<TData> Post<TData, TRequest>(string url, TRequest request) where TRequest : class where TData : class
        {
            string requestContentString = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            StringContent content = new StringContent(requestContentString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            await ValidateResponseOrThrow(response);
            return await GetDataFromResponse<TData>(response);
        }

        protected async Task Post<TRequest>(string url, TRequest request) where TRequest : class
        {
            string requestContentString = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            StringContent content = new StringContent(requestContentString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            await ValidateResponseOrThrow(response);
        }

        private async Task<TData> GetDataFromResponse<TData>(HttpResponseMessage response) where TData : class
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            TData? responseData = JsonConvert.DeserializeObject<TData>(responseContent);
            if (responseData == null)
                throw new InvalidCastException($"Could not deserialize response to type: {typeof(TData).Name}");

            return responseData;
        }

        private async Task ValidateResponseOrThrow(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            string responseContent = await response.Content.ReadAsStringAsync();
            throw new SparkPostHttpException(responseContent);
        }
    }
}
