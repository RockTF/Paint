using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PaintServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaintServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LogInController(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        //public IActionResult Index()
        //{
        //    var items = GetPersons();
        //    return (IActionResult)items;
        //}

        // GET: api/<LogInController>
        [HttpGet]
        public IEnumerable<Persons> Get()
        {
            //if (login.Length != 0 && password.Length != 0)
            //{
            //    return new string[] { "You are logged in" };
            //}
            //else
            //{
            //    return new string[] { $"You are not logged in" };
            //}
            var items = GetPersons();
            return items;
        }

        // GET api/<LogInController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogInController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LogInController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogInController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private List<Persons> GetPersons()
        {
            using (IDbConnection connection = Connection())
            {
                var result = connection.Query<Persons>("SELECT * FROM Persons").ToList();
                return result;
            }
        }
    }
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Admin { get; set; }
    }
}
