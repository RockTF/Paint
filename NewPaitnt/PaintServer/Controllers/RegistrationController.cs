using DAL;
using DAL.Models;
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
        public IActionResult Register([FromBody] DTO.UserRegistrationData userRegistrationData)
        {
            //Persons autorizationResultData = new Login().AutorizeUser(userAutorizationData);

            //AutorizationService autorizationService = new AutorizationService();

            //RegistrationDTO registration = autorizationService.register(userRegistrationData.Login, userRegistrationData.Password, userRegistrationData.Name, userRegistrationData.LastName); //переделать на обьект параметры метода

            if (userRegistrationData == null)
            {
                return BadRequest();
            }

            PersonModel person = new PersonModel()
            {
                Name = userRegistrationData.Name,
                Lastname = userRegistrationData.LastName,
                Email = userRegistrationData.Login,
                Password = userRegistrationData.Password,
                Admin = false,
                RegisterDate = DateTime.Now,
                LastVisitDate = DateTime.Now
            };

            _dal.Create(person);
            //return CreatedAtRoute("GetTodoItem", new { id = person.Id }, userRegistrationData);
            return Ok();
        }

        //public static bool ChekForus(string username, string connectionString)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM dbo.Persons WHERE Name = @Name", connection);
        //        sqlCom.Parameters.AddWithValue("@Name", username);
        //        connection.Open();
        //        return 1 == sqlCom.ExecuteNonQuery();
        //    }
        //}
    }
}
