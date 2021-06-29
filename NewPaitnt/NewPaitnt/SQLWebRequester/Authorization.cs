using DTO;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewPaitnt.SQLWebRequester
{
    class Authorization : IAuthorizationRequester
    {
        public int? UserId { get; private set; }

        public HttpStatusCode httpStatusCode { get; private set; }

        public async Task<int?> AuthorizeAsync(string login, string password)
        {
            UserId = await Task.Run(() => Authorize( login, password));
            return UserId;
        }
        public async Task<int?> UpdateAsync(string login, string password)
        {
            UserId = await Task.Run(() => Update(login, password));
            return UserId;
        }

        public int? Authorize(string login, string password)
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/auth/login", Method = Method.POST };

            UserAutorizationData userAutorizationData = new UserAutorizationData();
            userAutorizationData.Login = login;
            userAutorizationData.Password = password;

            request.AddJsonBody(userAutorizationData);
            var abc = JsonSerializer.Serialize(userAutorizationData);
            RestClient restClient = new RestClient();
            var response = restClient.Execute(request);
            httpStatusCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    UserId = Int32.Parse(response.Content);
                    return UserId;
                }
                catch
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public int? Update(string login, string password) 
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/login", Method = Method.PUT };

            UserAutorizationData userAutorizationData = new UserAutorizationData();
            userAutorizationData.Login = login;
            userAutorizationData.Password = password;

            request.AddJsonBody(userAutorizationData);

            RestClient restClient = new RestClient();
            var response = restClient.Execute(request);
            httpStatusCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    UserId = Int32.Parse(response.Content);
                    return UserId;
                }
                catch
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}
