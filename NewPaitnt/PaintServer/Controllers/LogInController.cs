using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PaintServer.DTO;
using PaintServer.Server.Realization;
using PaintServer.ServerRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaintServer.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        [HttpPost]
        //[Route("login")]
        public IActionResult Login([FromBody] UserAutorizationData userAutorizationData)
        {
            //Persons autorizationResultData = new Login().AutorizeUser(userAutorizationData);

            AutorizationService autorizationService = new AutorizationService();

            Persons person = autorizationService.login(userAutorizationData.Login, userAutorizationData.Password); //переделать на обьект параметры метода

            int userId = person.Id;

            return Ok(userId);
        }
    }
 
}
