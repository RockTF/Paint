using PaintServer.DTO;
using PaintServer.Server.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.ServerRequest
{
    public class Login
    {
        public Persons AutorizeUser(UserAutorizationData userAutorizationData)
        {

            AutorizationService autorizationDAL = new AutorizationService();

            Persons autorizationResultData = autorizationDAL.login(userAutorizationData.Login, userAutorizationData.Password);

            return autorizationResultData;
        }
    }
}
