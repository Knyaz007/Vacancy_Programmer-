using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TransliterationClient
{
    public class ApiTransliterationClient : ITransliterationClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ApiTransliterationClient(string apiUrl)
        {
            _httpClient = new HttpClient();
            _apiUrl = apiUrl;
        }

        public string Transliterate(string text)
        {
            try
            {
                var response = _httpClient.GetAsync($"{_apiUrl}?text={Uri.EscapeDataString(text)}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception during Transliterate: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Handle other exceptions or rethrow if needed
                throw;
            }
        }
    }
}