using System.Text.RegularExpressions;


namespace NewPaitnt
{
    public class Validator
    {
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
       

        public string InputValidation()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return ErrorMessage = "The input line is empty";
            }
            else if (Name.Length <= 2 && Name.Length > 30)
            {
                return ErrorMessage = "The input line must contain more than 2 letters and be no longer than 30";
            }
            else if (!Regex.IsMatch(Name, @"^[A-Z]+[a-zA-Z""'\s-]*$"))
            {
                return ErrorMessage = "The input line can contain only Latin characters and cannot contain invalid characters";
            }
            else
            {
                return ErrorMessage = " "; 
            }
        }
    }
}
