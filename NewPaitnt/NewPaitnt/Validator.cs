using System.Text.RegularExpressions;


namespace NewPaitnt
{
    public class Validator
    {
        public string Name { get; set; }

            public string InputValidation()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "The input line is empty";
            }
            else if (Name.Length < 2 || Name.Length > 30)
            {
                return "The input line must contain more than 2 letters and be no longer than 30";
            }
            else if (!Regex.IsMatch(Name, @"^[A-Z][a-z]*$"))
            {
                return "The input line can contain only Latin characters and cannot contain invalid characters";
            }
            else
            {
                return  " "; 
            }
        }

        public string InputValidationEmail()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "The input line is empty";
            }
            else if (!Regex.IsMatch(Name, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$"))
            {
                return "The input line can contain only Latin characters and cannot contain invalid characters";
            }
            else
            {
                return " ";
            }
        }
    }
}
