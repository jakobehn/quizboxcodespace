﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QBoxCore.Api.DTO;

namespace QBoxCore.Api.Client
{
    public class QBoxClient : IQBoxClient
    {
        private readonly string baseUrl;
        private readonly HttpClient httpClient;

        public QBoxClient()
        {
            httpClient = new HttpClient();
            this.baseUrl = $"http://localhost:55001";
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            string uri = $"{baseUrl}/category";
            var content = await httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<CategoryDTO>>(content);
        }

        public async Task<List<ScoreDTO>> GetHighscore()
        {
            string uri = $"{baseUrl}/highscore";
            var content = await httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<ScoreDTO>>(content);
        }

        public async Task PostHighScore(int gameId, string user)
        {
            string uri = $"{baseUrl}/highscore/{gameId}/{user}";

            var res = await httpClient.PostAsync(uri, new StringContent("")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (!res.IsSuccessStatusCode)
            {
                var errorMessage = ParseErrorResponse(textData);
                throw new Exception(errorMessage);
            }
        }

        public async Task<GameDTO> StartGame(string category, int nrQuestions)
        {
            string uri = $"{baseUrl}/game/start/{category}/{nrQuestions}";
            var res = await httpClient.PostAsync(uri, new StringContent("")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GameDTO>(textData);
            }
            var errorMessage = ParseErrorResponse(textData);
            throw new Exception(errorMessage);

        }

        public async Task<QuestionDTO> GetQuestion(int gameId, int questionNr)
        {
            string uri = $"{baseUrl}/game/{gameId}/{questionNr}";
            var content = await httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<QuestionDTO>(content);
        }

        public async Task SaveAnswer(int gameId, int questionNr, int selectedAnswer)
        {
            string uri = $"{baseUrl}/game/answer/{gameId}/{questionNr}/{selectedAnswer}";
            Console.WriteLine("Calling " + uri);
            var res = await httpClient.PostAsync(uri, new StringContent("", Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var response = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return;
            }

            var errorMessage = ParseErrorResponse(response);
            throw new Exception(errorMessage);
        }

        public async Task<GameResultDTO> FinishGame(int gameId)
        {
            string uri = $"{baseUrl}/game/finish/{gameId}";
            var res = await httpClient.PostAsync(uri, new StringContent("", Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var response = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GameResultDTO>(response);
            }

            var errorMessage = ParseErrorResponse(response);
            throw new Exception(errorMessage);
        }


        private static string ParseErrorResponse(string response)
        {
            return response;
            //var error = JsonConvert.DeserializeObject<HttpError>(response);
            //if (!String.IsNullOrEmpty(error.ExceptionMessage))
            //{
            //    throw new Exception(error.ExceptionMessage + " " + error.StackTrace);
            //}
            //string errorMessage = "";
            //foreach (var err in error)
            //{
            //    errorMessage += err.Key + ": " + err.Value + "\n";
            //}
            //return errorMessage;
        }
    }

    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
}
