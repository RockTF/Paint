using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IDAL
    {
        IEnumerable<PersonModel> Get();
        PersonModel Get(int id);
        void Create(PersonModel item);
        void Update(PersonModel item);
        PersonModel Delete(int id);
    }
}
