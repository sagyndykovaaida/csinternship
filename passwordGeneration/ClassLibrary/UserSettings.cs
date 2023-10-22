using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary

{
    public class UserSettings
    {
        public bool Uppercase { get; set; }
        public bool Lowercase { get; set; }
        public bool Digits { get; set; }
        public bool SpecialSymbols { get; set; }
        public string ExcludedCharacters { get; set; }

        public UserSettings()
        {
            Uppercase = true;
            Lowercase = true;
            Digits = true;
            SpecialSymbols = true;
            ExcludedCharacters = "Il10Oo";
        }


        public string GeneratePassword(int length)
        {
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            PasswordGenerator passwordGenerator = new PasswordGenerator();
 
            string allowedChars = string.Empty;

            if (Uppercase)
                allowedChars += ExcludeSymbols(passwordGenerator.UppercaseChars);
            if (Lowercase)
                allowedChars += ExcludeSymbols(passwordGenerator.LowercaseChars);
            if (Digits)
                allowedChars += ExcludeSymbols(passwordGenerator.NumChars);
            if (SpecialSymbols)
                allowedChars += passwordGenerator.SpecialSymbols;

            if (allowedChars.Length == 0)
            {
                Console.WriteLine("Ошибка: Ни одна категория символов не выбрана.");
                return string.Empty;
            }

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, allowedChars.Length);
                password.Append(allowedChars[index]);
            }

            return password.ToString();
        }
        public string ExcludeSymbols(string input)
        {
            foreach (char c in ExcludedCharacters)
            {
                input = input.Replace(c.ToString(), string.Empty);
            }
            return input;
        }


        static bool GetUserChoice(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input == "1";
        }

        public void Category()
        {
            Uppercase = GetUserChoice("Включить заглавные буквы (1 - да, 0 - нет): ");
            Lowercase = GetUserChoice("Включить строчные буквы (1 - да, 0 - нет): ");
            Digits = GetUserChoice("Включить цифры (1 - да, 0 - нет): ");
            SpecialSymbols = GetUserChoice("Включить специальные символы (1 - да, 0 - нет): ");
        }
       



    }
}
