using NewPaint.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.SQLWebRequester
{
    class Authorization : IAuthorizationRequester
    {
        public int UserId { get; private set; }

        public HttpStatusCode httpStatusCode { get; private set; }

        public (bool, int) Authorize(string login, string password)
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/login", Method = Method.POST };

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
                    return (true, UserId);
                }
                catch
                {
                    UserId = -1;
                    return (false, UserId);
                }

            }
            else
            {
                UserId = -1;
                return (false, UserId);
            }
        }
    }
}
