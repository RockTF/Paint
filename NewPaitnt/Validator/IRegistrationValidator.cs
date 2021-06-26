namespace Validator
{
    public interface IRegistrationValidator
    {
        public (bool, string) NameValidation(string name);
        public (bool, string) EmailValidation(string email);
        public (bool, string) PasswordValidation(string password);
    }
}
