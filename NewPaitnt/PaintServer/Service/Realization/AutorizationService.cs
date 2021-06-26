using Microsoft.Data.SqlClient;
using PaintServer.DTO;
using PaintServer.Server.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Server.Realization
{
    public class AutorizationService : IAutorization
    {
        private string _connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=PaintBD;";
        private Persons _persons;
        private RegistrationDTO _registration;

        public Persons login(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Persons", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var a = reader["Email"];
                        var b = reader["Password"];

                        if (login == a.ToString() && password == b.ToString())
                        {
                            _persons = new Persons()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Lastname = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                Admin = Convert.ToInt32(reader["Admin"])
                            };

                            return _persons;
                        }
                    }

                    _persons = new Persons()
                    {
                        Id = 0,
                        Name = "",
                        Lastname = "",
                        Email = "",
                        Password = "111",
                        Admin = 2
                    };

                    return _persons;
                }
            }
        }

        public RegistrationDTO register(string login, string password, string Name, string lastName)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            {
                var queryString = $"INSERT INTO dbo.Persons (Name, Lastname, Email, Password, 2) VALUES ('{Name}','{lastName}','{login}','{password}')";
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        _registration = new RegistrationDTO()
                        {
                            Registration = true,
                            RegistrationMessage = "Good"
                        };

                        return _registration;

                    }
                    catch
                    {
                        _registration = new RegistrationDTO()
                        {
                            Registration = false,
                            RegistrationMessage = "Can't create such user"
                        };

                        return _registration;
                    }
                }
            }
        }
    }
}
