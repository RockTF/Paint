using DTO;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt.SQLWebRequester
{
    class Registration
    {
        public int? UserId { get; private set; }

        public HttpStatusCode httpStatusCode { get; private set; }
        public async Task<int?> RegisterAsync(string name, string lastname, string login, string password)
        {
            UserId = await Task.Run(() => Register(name, lastname, login, password));
            return UserId;
        }

        public int? Register(string name, string lastname, string login, string password)
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/auth", Method = Method.POST };
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
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                MessageBox.Show(response.Content);
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
