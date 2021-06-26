using DAL.Models;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IDAL
    {
        IEnumerable<PersonModel> Get();
        PersonModel Get(int id);
        PersonModel Get(string email);
        void Create(UserRegistrationData userRegistrationData);
        void UpdatePassword(UserAutorizationData item);
        PersonModel Delete(int id);
    }
}
