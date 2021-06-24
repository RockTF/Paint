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
    [Route("api/registr")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        //[Route("registr")]
        public IActionResult Login([FromBody] UserRegistrationData userRegistration)
        {
            //Persons autorizationResultData = new Login().AutorizeUser(userAutorizationData);

            AutorizationService autorizationService = new AutorizationService();

            RegistrationDTO registration = autorizationService.register(userRegistration.Login, userRegistration.Password, userRegistration.Name, userRegistration.LastName, userRegistration.Admin); //переделать на обьект параметры метода

            return Ok(registration);
        }
    }
 
}
