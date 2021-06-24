using Microsoft.AspNetCore.Mvc;
using PaintServer.DTO;
using PaintServer.Server.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Controllers
{
    [Route("api/signup")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] UserRegistrationData userRegistrationData)
        {
            //Persons autorizationResultData = new Login().AutorizeUser(userAutorizationData);

            AutorizationService autorizationService = new AutorizationService();

            //1. Проверить в базе по эмейлу, если есть, вернуть соотв. статус-код
            //2. Если нет, то добавить его в базу и добавить дату регистрации
            //3. Достать у вновь созданого юзера его ИД и вернуть в качестве ответа



            Persons person = autorizationService.register(userRegistrationData.Login, userRegistrationData.Password, userRegistrationData.Name, userRegistrationData.LastName); //переделать на обьект параметры метода

            int userId = person.Id;

            return Ok(userId);
        }
    }
}
