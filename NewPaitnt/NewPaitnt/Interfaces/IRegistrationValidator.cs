using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    public interface IRegistrationValidator
    {
        public (bool, string) NameValidation(string name);
        public (bool, string) EmailValidation(string email);
        public (bool, string) PasswordValidation(string password);
    }
}
