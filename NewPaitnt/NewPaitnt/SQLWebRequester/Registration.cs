using DTO;
using RestSharp;
using System;
using System.Net;

namespace NewPaitnt.SQLWebRequester
{
    class Registration
    {
        public int UserId { get; private set; }

        public HttpStatusCode httpStatusCode { get; private set; }

        public int? Register(string name, string lastname, string login, string password)
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/signup", Method = Method.POST };
            UserRegistrationData userRegistrationData = new UserRegistrationData();

            userRegistrationData.Name = name;
            userRegistrationData.LastName = lastname;
            userRegistrationData.Login = login;
            userRegistrationData.Password = password;

            request.AddJsonBody(userRegistrationData);

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
