using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechnicalAssessment.Client.Models;

namespace TechnicalAssessment.Client
{
    public class ApiServiceClient
    {
        private const string apiUrl = "https://localhost:44364";
        private readonly HttpClient client;

        public ApiServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
        }

        //public Task CreateUser(UserCreateModel model)
        //{
        //    var request = new 
        //}
    }
}
