using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Windows.Forms;

namespace NewPaitnt.SQLWebRequester
{
    class Statistic
    {

        public int UserId { get; private set; }

        public HttpStatusCode httpStatusCode { get; private set; }

        public Statistic Get(int userId)
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/statistics?userid={userId}", Method = Method.GET };

            UserId = userId;
            RestClient restClient = new RestClient();
            var response = restClient.Execute(request);
            httpStatusCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK)
            {
             Statistic statistic = JsonConvert.DeserializeObject<Statistic>(response.Content);
             return statistic;
            }
            else
            {
                MessageBox.Show(response.Content);
                return null;
            }
        }
    }
}
