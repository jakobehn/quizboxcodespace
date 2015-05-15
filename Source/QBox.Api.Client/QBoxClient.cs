using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QBox.Api.DTO;

namespace QBox.Api.Client
{
    public class QBoxClient : IQBoxClient
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public QBoxClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            string uri = $"{_baseUrl}/category";
            var content = await _httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<CategoryDTO>>(content);
        }

        public async Task<GameDTO> StartGame(int categoryId)
        {
            string uri = $"{_baseUrl}/game/{categoryId}";
            var content = await _httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<GameDTO>(content);
        }
        //public async Task<HttpResponseMessage> PostContent(WebContentDTO webContent)
        //{
        //    string uri = _baseUrl + "/webcontent/";
        //    return await _httpClient.PostAsync(uri, new StringContent(JObject.FromObject(webContent).ToString(), Encoding.UTF8, "application/json")).ConfigureAwait(false);
        //}

        //        private static string ParseErrorResponse(string response)
        //{
        //    var error = JsonConvert.DeserializeObject<HttpError>(response);
        //    if (!String.IsNullOrEmpty(error.ExceptionMessage))
        //    {
        //        throw new Exception(error.ExceptionMessage + " " + error.StackTrace);
        //    }
        //    string errorMessage = "";
        //    foreach (var err in error)
        //    {
        //        errorMessage += err.Key + ": " + err.Value + "\n";
        //    }
        //    return errorMessage;
        //}
    }
}
