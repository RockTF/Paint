using System;
using System.Collections.Generic;

namespace Validator
{
    public class ValidatorCondition : IRegistrationValidator
    {
        public (bool, string) NameValidation(string name)
        {
            char[] input = name.ToCharArray();
            if (input == null)
            {
                return (false, "Input is null!");
            }
            char ch;
            int index = 0;
            if (input.Length < 3 || input.Length > 20)
            {
                return (false, "The input line must contain more than 2 letters and be no longer than 30");
            }
            else
            {
                while (index < input.Length)
                {
                    ch = input[index];

                    if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || ch == '-')

                    {
                        index++;
                    }
                    else
                    {
                        return (false, "The input line must begin with a capital letter, contain only Latin characters");
                    }
                }
            }
            return (true, "");
        }

        public (bool, string) PasswordValidation(string password)
        {
            char[] input = password.ToCharArray();
            if (input == null)
            {
                return (false, "Input is null!");
            }
            char ch;
            int index = 0;
            if (input.Length < 6 || input.Length > 30)
            {
                return (false, "The password must contain more than 5 letters and be no longer than 30");
            }
            else
            {
                while (index < input.Length)
                {
                        ch = input[index];
                    if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
                                                || (ch >= '0' && ch <= '9') || ch == '_' || ch == '-'
                                                || ch == '+')

                    {
                        index++;
                    }
                    else
                    {
                        return (false, "The password must contain only Latin characters and cannot contain invalid characters");
                    }
                }
            }
            return (true, "");
        }

        public (bool, string) EmailValidation(string email)
        {
            char[] input = email.ToCharArray();
            if (input == null)
            {
                return (false, "Input is null!");
            }

            int state = 0;
            char ch;
            int index = 0;
            int mark = 0;
            String local = null;
            List<String> domain = new List<String>();

            while (index <= input.Length && state != -1)
            {

                if (index == input.Length)
                {
                    ch = '\0';
                }
                else
                {
                    ch = input[index];
                    if (ch == '\0')
                    {
                        return (false, "Invalid input!");
                    }
                }

                switch (state)
                {

                    case 0:
                        {
                            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
                                    || (ch >= '0' && ch <= '9') || ch == '_' || ch == '-'
                                    || ch == '+')
                            {
                                state = 1;
                                break;
                            }
                            state = -1;
                            break;
                        }

                    case 1:
                        {
                            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
                                    || (ch >= '0' && ch <= '9') || ch == '_' || ch == '-'
                                    || ch == '+')
                            {
                                break;
                            }
                            if (ch == '.')
                            {
                                state = 2;
                                break;
                            }
                            if (ch == '@')
                            {
                                local = new String(input, 0, index - mark);
                                mark = index + 1;
                                state = 3;
                                break;
                            }
                            state = -1;
                            break;
                        }

                    case 2:
                        {
                            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
                                    || (ch >= '0' && ch <= '9') || ch == '_' || ch == '-'
                                    || ch == '+')
                            {
                                state = 1;
                                break;
                            }
                            state = -1;
                            break;
                        }

                    case 3:
                        {
                            if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')
                                    || (ch >= 'A' && ch <= 'Z'))
                            {
                                state = 4;
                                break;
                            }
                            state = -1;
                            break;
                        }

                    case 4:
                        {
                            if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')
                                    || (ch >= 'A' && ch <= 'Z'))
                            {
                                break;
                            }
                            if (ch == '-')
                            {
                                state = 5;
                                break;
                            }
                            if (ch == '.')
                            {
                                domain.Add(new String(input, mark, index - mark));
                                mark = index + 1;
                                state = 5;
                                break;
                            }
                            if (ch == '\0')
                            {
                                domain.Add(new String(input, mark, index - mark));
                                state = 6;
                                break;
                            }
                            state = -1;
                            break;
                        }

                    case 5:
                        {
                            if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')
                                    || (ch >= 'A' && ch <= 'Z'))
                            {
                                state = 4;
                                break;
                            }
                            if (ch == '-')
                            {
                                break;
                            }
                            state = -1;
                            break;
                        }

                    case 6:
                        {
                            break;
                        }
                }
                index++;
            }
            if (state != 6)
            {
                return (false, "Email is not valid!");
            }

            if (domain.Count < 2)
            {
                return (false, "Email`s domain is not valid!");
            }

            if (local.Length > 64)
            {
                return (false, "Email is too long!");
            }

            if (input.Length > 254)
            {
                return (false, "Email is too long!");
            }

            index = input.Length - 1;
            while (index > 0)
            {
                ch = input[index];
                if (ch == '.' && input.Length - index > 2)
                {
                    return (true, "");
                }
                if (!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')))
                {
                    return (false, "The input line can contain only Latin characters and cannot contain invalid characters");
                }
                index--;
            }
            return (true, "");
        }
    }
}
