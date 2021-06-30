using DTO;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace NewPaitnt.SQLWebRequester
{
    class SaveLoad
    {
        public int UserId { get; private set; }
        public HttpStatusCode httpStatusCode { get; private set; }

        public void SaveToServer(PictureDTO picture) 
        {

            var request = new RestRequest { Resource = $"http://localhost:9090/api/picture", Method = Method.POST };

            request.AddJsonBody(picture);

            RestClient restClient = new RestClient();
            var response = restClient.Execute(request);
            httpStatusCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                MessageBox.Show(response.Content);
            }
        }

        public PictureListDTO LoadPictureListForUser(int userId)
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/picture?userid={userId}", Method = Method.GET };
            UserId = userId;
            RestClient restClient = new RestClient();
            var response = restClient.Execute(request);
            httpStatusCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PictureListDTO>(response.Content);
            }
            else
            {
                MessageBox.Show(response.Content);
                return null;
            }
        }

        public PictureToClientDTO LoadFromServer(int pictureId) 
        {
            var request = new RestRequest { Resource = $"http://localhost:9090/api/picture/{pictureId}", Method = Method.GET };

            RestClient restClient = new RestClient();
            var response = restClient.Execute(request);
            httpStatusCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PictureToClientDTO>(response.Content);
            }
            else
            {
                MessageBox.Show(response.Content);
                return null;
            }
        }
    }
}
