using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.SQLWebRequester
{
    interface IAuthorizationRequester
    {
        int UserId { get; }
        HttpStatusCode httpStatusCode { get; }
        int? Authorize(string login, string password);
    }
}
