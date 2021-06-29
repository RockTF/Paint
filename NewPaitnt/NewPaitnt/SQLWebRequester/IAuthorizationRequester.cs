using System.Net;

namespace NewPaitnt.SQLWebRequester
{
    interface IAuthorizationRequester
    {
        int? UserId { get; }
        HttpStatusCode httpStatusCode { get; }
        int? Authorize(string login, string password);
    }
}
