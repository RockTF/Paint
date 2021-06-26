using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Server.Interfase
{
    public interface IAutorization
    {
        Persons login(string login, string password);
        RegistrationDTO register(string login, string password, string firstName, string lastName);
    }
}
