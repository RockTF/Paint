using DAL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PaintServer.Controllers
{
    [Route("api/signup")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private IDAL _dal;

        public RegistrationController(IDAL dal)
        {
            _dal = dal;
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserRegistrationData userRegistrationData)
        {
     
            if (userRegistrationData == null)
            {
                return BadRequest();
            }

            _dal.Create(userRegistrationData);
            return Ok(_dal.Get(userRegistrationData.Login).Id);
        }
    }
}
