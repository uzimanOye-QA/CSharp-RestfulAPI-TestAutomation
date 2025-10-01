using Newtonsoft.Json;
using RestfulAPITestAutomationFramework.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPITestAutomationFramework.SetUp
{
    public class Context
    {

        String baseUrl = "https://restful-booker.herokuapp.com/";
        private string? _token;
        public string content = string.Empty;
        //public string _token = string.Empty;

        public string statusCode = string.Empty;
        public string? AuthToken { get; set; }

        public void GetMethod(string resource) {
            var client = new RestClient(baseUrl); 
            var request = new RestRequest(resource, Method.Get);
            request.AddHeader("Accept", "application/json");
            var result = client.Execute(request);
            content = result.Content ?? string.Empty; 
            statusCode = result.StatusCode.ToString();


        }
       

        public void PostMethod(string resource, object payload)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Post);

            string jsonBody = JsonConvert.SerializeObject(payload, Formatting.Indented);
            request.AddStringBody(jsonBody, DataFormat.Json);  
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
            content = result.Content ?? string.Empty;
        }
        public void PutMethod(string resource, object payload) {

            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            if (!string.IsNullOrEmpty(AuthToken))
                request.AddHeader("Cookie", $"token={AuthToken}");
            request.AddJsonBody(payload);
            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
            content = result.Content ?? string.Empty;

          

        }

        public void PatchMethod(string resource, object payload)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Patch);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrEmpty(AuthToken))
                request.AddHeader("Cookie", $"token={AuthToken}");

            string jsonBody = JsonConvert.SerializeObject(payload, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            request.AddStringBody(jsonBody, DataFormat.Json);

            var result = client.Execute(request);
            statusCode = result.StatusCode.ToString();
            content = result.Content ?? string.Empty;
        }
       

        public void DeleteMethod(string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Delete);

            // Add headers BEFORE executing the request
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrEmpty(AuthToken))
                request.AddHeader("Cookie", $"token={AuthToken}");

            var result = client.Execute(request);

            statusCode = result.StatusCode.ToString();
            content = result.Content ?? string.Empty;
        }
        public void DeleteMethodNoAuth(string resource)
        {

            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.Delete);
            var result = client.Execute(request);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
           
            statusCode = result.StatusCode.ToString();
            content = result.Content ?? string.Empty;
        }


        public async Task CreateAuthToken()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("auth", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { username = "admin", password = "password123" });
            var response = await client.ExecuteAsync(request);

            var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content ?? string.Empty);
            if (tokenResponse != null && tokenResponse.ContainsKey("token"))
            {
                AuthToken = tokenResponse["token"];
            }
        }

    }
}
