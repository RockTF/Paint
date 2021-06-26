using DAL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaintServer.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController : ControllerBase
    {
       
        private IDAL _dal;

        public LogInController(IDAL dal)
        {
            _dal = dal;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAutorizationData userAutorizationData)
        {

            if (userAutorizationData == null)
            {
                return BadRequest();
            }

            PersonModel personModel = _dal.Get(userAutorizationData.Login);

            if (personModel == null)
            {
                throw new Exception("Not found");
            }

            if (personModel.Password == userAutorizationData.Password)
            {
                return Ok(_dal.Get(userAutorizationData.Login).Id);
            }
            else
            {
                throw new Exception("Password not validation");
            }
           
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserAutorizationData userAutorizationData)
        {

            if (userAutorizationData == null)
            {
                return BadRequest();
            }

            PersonModel personModel = _dal.Get(userAutorizationData.Login);

            if (personModel == null)
            {
                throw new Exception("Not found");
            }
            else 
            {
                _dal.UpdatePassword(userAutorizationData);
                return Ok(personModel.Id);
            }
        }
    }
 
}
