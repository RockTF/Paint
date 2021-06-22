using NewPaitnt.Interfaces;
using System.Text.RegularExpressions;


namespace NewPaitnt
{
    public class ValidatorRegEx : IRegistrationValidator
    {
        
        public (bool, string) NameValidation(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (false, "The input line is empty");
            }
            else if (name.Length < 2 || name.Length > 30)
            {
                return (false, "The input line must contain more than 2 letters and be no longer than 30");
            }
            else if (!Regex.IsMatch(name, @"^[A-Z][a-z]*$"))
            {
                return (false, "The input line must begin with a capital letter, contain only Latin characters");
            }
            else
            {
                return (true, ""); 
            }
        }

        public (bool, string) EmailValidation(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return (false, "The input line is empty");
            }
            else if (!Regex.IsMatch(email, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$"))
            {
                return (false, "The input line can contain only Latin characters and cannot contain invalid characters");
            }
            else
            {
                return (true, "");
            }
        }

        public (bool, string) PasswordValidation(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return (false, "The input line is empty");
            }
            else if (password.Length < 6 || password.Length > 30)
            {
                return (false, "The password must contain more than 5 letters and be no longer than 30");
            }
            else if (!Regex.IsMatch(password, @"^(?=.*?[A-Z0-9][a-z0-9'+\-_']).{6,}$")) 
            {
                return (false, "The input line can contain only Latin characters and cannot contain invalid characters");
            }
            else
            {
                return (true, "");
            }
        }
    }
}
